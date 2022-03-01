using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PAStateB : PlayerAttackStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.333f;
    [SerializeField] private bool hasCombo = false;
    [SerializeField] private GameObject attackB;

    public override void EnterState(PlayerCore pl)
    {
        frameCounter = maxFrameNum;
        hasCombo = false;
        pl.model.attackAanim = true;
        pl.model.playerAnim.SetBool(pl.model.isAttackBHash, pl.model.attackAanim);
        attackB.SetActive(true);
    }

    public override void Update(PlayerCore pl)
    {
        if (pl.model.attackInput) hasCombo = true;

        if (frameCounter <= 0f)
        {
            if (hasCombo) pl.ChangeAttackState(pl.model.atkStateC);
            else pl.ChangeAttackState(pl.model.atkStateT);
        }

        //Change hit box according to frameCount;
        //Debug.Log("attackB Behavior");
        //=======================================

        frameCounter -= Time.deltaTime;
    }

    public override void LeaveState(PlayerCore pl)
    {
        pl.model.comboCount = 2;
        pl.model.attackAanim = false;
        pl.model.playerAnim.SetBool(pl.model.isAttackBHash, pl.model.attackAanim);
        attackB.SetActive(false);
    }
}
