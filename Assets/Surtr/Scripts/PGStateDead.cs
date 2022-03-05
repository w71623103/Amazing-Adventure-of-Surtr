using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PGStateDead : PlayerGeneralStateBase
{
    /*[SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.333f;*/
    public override void EnterState(PlayerCore pl) 
    {
        pl.model.hp = pl.model.maxhp;
        SceneManager.LoadScene("first");
        /*frameCounter = maxFrameNum; ;
        //pl.model.playerAnim.SetBool(pl.model.isDeadHash, true);
        pl.model.horizontalMovement = 0f;
        pl.model.characterRB.velocity = Vector2.zero;
        pl.model.characterRB.constraints = RigidbodyConstraints2D.FreezeAll;*/
    }

    public override void Update(PlayerCore pl) 
    {
        /*pl.model.characterRB.velocity = Vector2.zero;
        if (frameCounter <= 0f)
        {
            *//*MonoBehaviour.Destroy(pl.gameObject);*//*
            pl.gameObject.SetActive(false);
        }*/

        //Change hit box according to frameCount;
        //Debug.Log("attackA Behavior");
        //=======================================

        /*frameCounter -= Time.deltaTime;*/
    }

    public override void LeaveState(PlayerCore pl) 
    { 

    }
}
