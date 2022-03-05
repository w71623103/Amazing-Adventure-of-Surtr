using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EGStateDamage2 : EnemyGeneralStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.5f;
    public override void EnterState(EnemyCore em)
    {
        frameCounter = 0f;
    }

    public override void Update(EnemyCore em)
    {
        em.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(em.gameObject.GetComponent<SpriteRenderer>().color, Color.white, frameCounter / maxFrameNum);

        if (frameCounter > 0.5f)
        {
            em.ChangeGeneralState(em.model.gStateDefault);
        }

        //Change hit box according to frameCount;
        //Debug.Log("attackA Behavior");
        //=======================================

        frameCounter += Time.deltaTime;
    }

    public override void LeaveState(EnemyCore em)
    {

    }
}
