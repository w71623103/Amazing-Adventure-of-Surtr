using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyModel
{
    public float hp;
    public float maxhp;

    public Rigidbody2D characterRB;
    public float horizontalMovement = 0f;
    public float moveSpeed = 2f;
    public bool isLeft = false;
    
    public int direction = 1;

    public bool attackCondition;
    public EnemyAttackStateBase attackState;
    public EAStateA atkStateA = new EAStateA();
    public EAStateCD atkStateCD = new EAStateCD();
    public EAStateDefault atkStateDefault = new EAStateDefault();

    public Animator enemyAnim;
    public bool attackAanim = false;
    public int isMovingHash;
    public int isAttackAHash;
    public int isDeadHash;

    public EnemyGeneralStateBase generalState;
    public EGStateDefault gStateDefault = new EGStateDefault();
    public EGStateDamage1 gStateDamage1 = new EGStateDamage1();
    public EGStateDamage2 gStateDamage2 = new EGStateDamage2();
    public EGStateDead gStateDead = new EGStateDead();

    public float hitForce;
}
