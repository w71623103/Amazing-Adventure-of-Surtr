using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PAStateA : PlayerAttackStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.417f;
    [SerializeField] private bool hasCombo = false;
    [SerializeField] private GameObject attackA;

    public override void EnterState(PlayerCore pl)
    {
        frameCounter = maxFrameNum;
        hasCombo = false;
        pl.model.attackAanim = true;
        pl.model.playerAnim.SetBool(pl.model.isAttackAHash, pl.model.attackAanim);
        attackA.SetActive(true);
    }

    public override void Update(PlayerCore pl)
    {
        if(pl.model.attackInput) hasCombo = true;

        if (frameCounter <= 0f)
        {
            if (hasCombo) pl.ChangeAttackState(pl.model.atkStateB);
            else pl.ChangeAttackState(pl.model.atkStateT);
        }

        //Change hit box according to frameCount;
        //Debug.Log("attackA Behavior");
        //=======================================

        frameCounter -= Time.deltaTime;
    }

    public override void LeaveState(PlayerCore pl)
    {
        attackA.SetActive(false);
        pl.model.comboCount = 1;
        pl.model.attackAanim = false;
        pl.model.playerAnim.SetBool(pl.model.isAttackAHash, pl.model.attackAanim);
    }
}
