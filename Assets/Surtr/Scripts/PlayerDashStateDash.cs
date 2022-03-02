using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerDashStateDash : PlayerDashStateBase
{
    [SerializeField] private float frameCounter;
    [SerializeField] private float maxFrameNum = 0.417f;
    //[SerializeField] private GameObject dashTargetPos;
    private Vector3 targetPosVect;

    public override void EnterState(PlayerCore pl)
    {
        frameCounter = 0f;
        targetPosVect = new Vector3(pl.transform.position.x + pl.transform.localScale.x * 0.6f, pl.transform.position.y, pl.transform.position.z);
        //pl.model.isVulnerable = false;
        pl.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //pl.model.playerRB.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        /*pl.model.playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;*/
        pl.model.playerAnim.SetBool(pl.model.isDashHash, true);
        //pl.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(pl.model.dashSpeed * pl.gameObject.transform.localScale.x, 0), ForceMode2D.Impulse);
        //pl.transform.Find("don't want to crash").GetComponent<BoxCollider2D>().enabled = true;
    }
    public override void Update(PlayerCore pl)
    {
        frameCounter += Time.deltaTime;
        RaycastHit2D hit = Physics2D.Raycast(pl.transform.position, new Vector2(pl.transform.localScale.x,0), 0.6f, LayerMask.GetMask("noPass"));
        if (hit.collider != null) targetPosVect = hit.point;
        pl.transform.position = Vector3.Lerp(pl.transform.position, targetPosVect, frameCounter / maxFrameNum);
        if (frameCounter > maxFrameNum)
        {
            pl.ChangeDashState(pl.model.dStateDefault);
        }
    }
    public override void LeaveState(PlayerCore pl)
    {
        //pl.transform.Find("don't want to crash").GetComponent<BoxCollider2D>().enabled = false;
        //pl.model.isVulnerable = true;
        pl.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        pl.model.playerAnim.SetBool(pl.model.isDashHash, false);
        //pl.model.playerRB.constraints = RigidbodyConstraints2D.None;
        //pl.model.playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
