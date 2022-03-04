using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PAStateT : PlayerAttackStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.5f;
    [SerializeField] private bool hasCombo = false;

    public override void EnterState(PlayerCore pl)
    {
        frameCounter = maxFrameNum;
        hasCombo = false;
        pl.model.attackAanim = true;
        pl.model.playerAnim.SetBool(pl.model.isAttackTHash, pl.model.attackAanim);
    }
    public override void Update(PlayerCore pl)
    {
        if (pl.model.attackInput) hasCombo = true;
        if (frameCounter <= 0f)
        {
            pl.ChangeAttackState(pl.model.atkStateDefault);
        }
        if (hasCombo && pl.model.inventory["combo"])
        {
            switch (pl.model.comboCount)
            {
                case 1:
                    pl.ChangeAttackState(pl.model.atkStateB);
                    break;
                case 2:
                    pl.ChangeAttackState(pl.model.atkStateC);
                    break;
            }
        }
/*        else 
        {
            pl.ChangeAttackState(pl.model.atkStateDefault);
        }*/

        frameCounter -= Time.deltaTime;
    }
    public override void LeaveState(PlayerCore pl)
    {
        pl.model.comboCount++;
        pl.model.attackAanim = false;
        pl.model.playerAnim.SetBool(pl.model.isAttackTHash, pl.model.attackAanim);
    }
}
