using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PAStateC : PlayerAttackStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.417f;
    //[SerializeField] private bool hasCombo = false;
    [SerializeField] private GameObject attackC;

    public override void EnterState(PlayerCore pl)
    {
        frameCounter = maxFrameNum;
        //hasCombo = false;
        pl.model.attackAanim = true;
        pl.model.playerAnim.SetBool(pl.model.isAttackCHash, pl.model.attackAanim);
        attackC.SetActive(true);
    }

    public override void Update(PlayerCore pl)
    {
        //if (pl.model.attackInput) hasCombo = true;

        if (frameCounter <= 0f)
        {
            /*if (hasCombo) pl.ChangeAttackState(pl.model.atkStateA);
            else pl.ChangeAttackState(pl.model.atkStateT);*/
            pl.ChangeAttackState(pl.model./*atkStateDefault*/atkStateT);
        }

        //Change hit box according to frameCount;
        //Debug.Log("attackC Behavior");
        //=======================================

        frameCounter -= Time.deltaTime;
    }

    public override void LeaveState(PlayerCore pl)
    {
        pl.model.comboCount = 3;
        pl.model.attackAanim = false;
        pl.model.playerAnim.SetBool(pl.model.isAttackCHash, pl.model.attackAanim);
        attackC.SetActive(false);
    }
}
