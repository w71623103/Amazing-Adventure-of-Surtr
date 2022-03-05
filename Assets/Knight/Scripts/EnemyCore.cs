using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour 
{
    public EnemyModel model = new EnemyModel();
    private EnemyController controller;

    public void ChangeAttackState(EnemyAttackStateBase newState)
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

    public void ChangeGeneralState(EnemyGeneralStateBase newState)
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

    // Start is called before the first frame update
    void Start()
    {
        model.hp = model.maxhp;
        controller = new EnemyController(model);
        model.attackState = model.atkStateDefault;
        model.generalState = model.gStateDefault;

        model.enemyAnim = GetComponent<Animator>();
        model.isAttackAHash = Animator.StringToHash("isAttackA");
        model.isDeadHash = Animator.StringToHash("isDead");
        model.isMovingHash = Animator.StringToHash("isMoving");

        model.characterRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (model.generalState == model.gStateDead) model.horizontalMovement = 0f;
        model.attackCondition = (model.generalState == model.gStateDefault && controller.isInSight(this));

        if (model.attackState == model.atkStateDefault && model.generalState != model.gStateDead)
        {
            //If not in attack, normal move, jump, and dash
            model.horizontalMovement = model.direction * model.moveSpeed * 1;
        }
        else
        {
            //If is attacking, half move speed, no jump, dash break attack chain
            model.horizontalMovement = model.direction * model.moveSpeed * 0f;
        }

        model.enemyAnim.SetBool(model.isDeadHash, model.hp <= 0);
        model.enemyAnim.SetBool(model.isMovingHash, model.horizontalMovement != 0);

        model.attackState.Update(this);
        model.generalState.Update(this);
        //Sprite facing Left/Right
        controller.scaleControl();
        var scale = transform.localScale;
        if (model.isLeft)
            transform.localScale = new Vector3(scale.x < 0 || model.horizontalMovement == 0 ? scale.x : -scale.x, scale.y, scale.z);
        else
            transform.localScale = new Vector3(scale.x > 0 || model.horizontalMovement == 0 ? scale.x : -scale.x, scale.y, scale.z);
        if (model.generalState == model.gStateDead) model.horizontalMovement = 0f;
    }

    private void FixedUpdate()
    {
        controller.hMovement();
    }

    public float getHpPer()
    {
        return model.hp / model.maxhp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "movLimit")
        {
            model.direction *= -1;
        }
    }

    public void takeDamage(float dmg, float x)
    {
        if (model.hp - dmg >= 0) model.hp -= dmg;
        else model.hp = 0;
        model.characterRB.velocity = Vector2.zero;
        model.characterRB.AddForce(new Vector2(Mathf.Sign(transform.position.x - x), 1) * model.hitForce, ForceMode2D.Impulse);
        if(model.generalState == model.gStateDefault) ChangeGeneralState(model.gStateDamage1);
        if (x > transform.position.x) model.direction = 1;
        else model.direction = -1;
    }
}
