using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    public PlayerModel model = new PlayerModel();
    private PlayerController controller;

    public void ChangeAttackState(PlayerAttackStateBase newState)
    {
        if (model.attackState != null)
        {
            model.attackState.LeaveState(this);
        }

        model.attackState = newState;

        if (model.attackState != null)
        {
            model.attackState.EnterState(this);
        }
    }

    public void ChangeDashState(PlayerDashStateBase newState)
    {
        if (model.dashState != null)
        {
            model.dashState.LeaveState(this);
        }

        model.dashState = newState;

        if (model.dashState != null)
        {
            model.dashState.EnterState(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = new PlayerController(model);
        model.attackState = model.atkStateDefault;

        model.playerAnim = GetComponent<Animator>();
        model.isAttackAHash = Animator.StringToHash("isAttackA");
        model.isAttackBHash = Animator.StringToHash("isAttackB");
        model.isAttackCHash = Animator.StringToHash("isAttackC");
        model.isAttackTHash = Animator.StringToHash("isAttackT");

        model.playerRB = GetComponent<Rigidbody2D>();
        model.isMovingHash = Animator.StringToHash("isMoving");

        model.isJumpHash = Animator.StringToHash("isGrounded");
        model.isDashHash = Animator.StringToHash("isDashing");
        model.dashState = model.dStateDefault;
    }

    // Update is called once per frame
    void Update()
    {
        //Timers========================================
        model.jumpTimer -= Time.deltaTime;
        
        //==============================================

        model.playerAnim.SetBool(model.isJumpHash, model.isGrounded);

        model.attackInput = Input.GetKeyDown(KeyCode.J);
        model.dashInput = Input.GetKeyDown(KeyCode.Space);

        model.attackState.Update(this);
        

        if (model.dashState == model.dStateDefault)
        {
            if (model.attackState == model.atkStateDefault)
            {
                //If not in attack, normal move, jump, and dash
                model.horizontalMovement = Input.GetAxisRaw("Horizontal") * model.moveSpeed * 1;
            }
            else
            {
                //If is attacking, half move speed, no jump, dash break attack chain
                model.horizontalMovement = Input.GetAxisRaw("Horizontal") * model.moveSpeed * model.attackingMovingFactor;
            }
        }
        

        model.playerAnim.SetBool(model.isMovingHash, model.horizontalMovement != 0);

        //Sprite facing Left/Right
        controller.scaleControl();
        var scale = transform.localScale;
        if (model.isLeft)
            transform.localScale = new Vector3(scale.x < 0 || model.horizontalMovement == 0 ? scale.x : -scale.x, scale.y, scale.z);
        else
            transform.localScale = new Vector3(scale.x > 0 || model.horizontalMovement == 0 ? scale.x : -scale.x, scale.y, scale.z);
    }

    //Rigidbody action goes to fixedUpdate
    private void FixedUpdate()
    {
        controller.hMovement();
        controller.Jump();
        //model.isDashing = controller.Dash();
        model.dashState.Update(this);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //grounding the player
        if (collision.gameObject.tag == "ground")
        {
            model.isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            model.isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //player taking off when jumping
        if (collision.gameObject.tag == "ground")
        {
            model.isGrounded = false;
        }
    }
}
