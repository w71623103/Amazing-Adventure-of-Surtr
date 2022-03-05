using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PGStateDamage2 : PlayerGeneralStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.5f;
    public override void EnterState(PlayerCore pl)
    {
        frameCounter = 0f;
    }

    public override void Update(PlayerCore pl)
    {
        pl.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(pl.gameObject.GetComponent<SpriteRenderer>().color, Color.white, frameCounter / maxFrameNum);

        if (frameCounter > 0.5f)
        {
            pl.ChangeGeneralState(pl.model.gStateDefault);
        }

        //Change hit box according to frameCount;
        //Debug.Log("attackA Behavior");
        //=======================================

        frameCounter += Time.deltaTime;
    }

    public override void LeaveState(PlayerCore pl)
    {

    }
}
