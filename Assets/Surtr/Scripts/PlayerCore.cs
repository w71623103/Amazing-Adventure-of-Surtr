using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ChangeGeneralState(PlayerGeneralStateBase newState)
    {
        if (model.generalState != null)
        {
            model.generalState.LeaveState(this);
        }

        model.generalState = newState;

        if (model.generalState != null)
        {
            model.generalState.EnterState(this);
        }
    }

/*    private void Awake()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "second":
                transform.position = new Vector3(1.15999997f, 0.213f, 0);
                break;
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        controller = new PlayerController(model);
        model.attackState = model.atkStateDefault;

        model.playerAnim = GetComponent<Animator>();
        model.isAttackAHash = Animator.StringToHash("isAttackA");
        model.isAttackBHash = Animator.StringToHash("isAttackB");
        model.isAttackCHash = Animator.StringToHash("isAttackC");
        model.isAttackTHash = Animator.StringToHash("isAttackT");

        model.characterRB = GetComponent<Rigidbody2D>();
        model.isMovingHash = Animator.StringToHash("isMoving");

        model.isJumpHash = Animator.StringToHash("isGrounded");
        model.isDashHash = Animator.StringToHash("isDashing");
        model.dashState = model.dStateDefault;

        model.inventory.Add("heal", false);
        model.inventory.Add("combo", false);
        model.hp = 30;

        model.generalState = model.gStateDefault;
    }

    // Update is called once per frame
    void Update()
    {
        
        model.generalState.Update(this);
        if (model.generalState != model.gStateDead)
        {
            //Timers========================================
            model.jumpTimer -= Time.deltaTime;
            model.healTimer -= Time.deltaTime;
            //==============================================

            model.playerAnim.SetBool(model.isJumpHash, model.isGrounded);

            model.attackInput = Input.GetKeyDown(KeyCode.J);
            model.dashInput = Input.GetKeyDown(KeyCode.Space);

            model.attackState.Update(this);
            model.dashState.Update(this);

            if (Input.GetKeyDown(KeyCode.F))
            {
                controller.collectItem(this);
            }

            if (Input.GetKeyDown(KeyCode.R) && model.dashState == model.dStateDefault && model.attackState == model.atkStateDefault)
            {
                controller.heal(this);
            }

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
        
    }

    //Rigidbody action goes to fixedUpdate
    private void FixedUpdate()
    {
        controller.hMovement();
        controller.Jump();
        //model.isDashing = controller.Dash();
        

    }

    public float getHpPer()
    {
        return model.hp <= 0? 0.1f : model.hp / model.maxhp;
    }

    public void takeDamage(float dmg, float x)
    {
        if (model.hp - dmg >= 0) model.hp -= dmg;
        else model.hp = 0;
        model.characterRB.velocity = Vector2.zero;
        model.characterRB.AddForce(new Vector2(Mathf.Sign(transform.position.x - x), 1) * model.hitForce, ForceMode2D.Impulse);
        ChangeGeneralState(model.gStateDamage1);
    }
}
