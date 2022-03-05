using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerModel
{
    public float hp;
    public float maxhp = 100f;

    public bool attackInput;
    public PlayerAttackStateBase attackState;
    public PAStateA atkStateA = new PAStateA();
    public PAStateB atkStateB = new PAStateB();
    public PAStateC atkStateC = new PAStateC();
    public PAStateT atkStateT = new PAStateT();
    public PAStateDefault atkStateDefault = new PAStateDefault();

    public int comboCount = 0;

    public Animator playerAnim;
    public bool attackAanim = false;
    public bool attackBanim = false;
    public bool attackCanim = false;
    public bool attackTanim = false;

    public int isAttackAHash;
    public int isAttackBHash;
    public int isAttackCHash;
    public int isAttackTHash;

    public float attackingMovingFactor = 0.1f;

    public Rigidbody2D characterRB;
    public float horizontalMovement = 0f;
    public float moveSpeed = 2f;
    public bool isLeft = false;

    public int isMovingHash;

    public bool isGrounded;
    public float jumpTimer = 0f;
    public float jumpSpeed = 5f;
    public float jumpCD = 0.5f;
    public int isJumpHash;

    public bool dashInput;
    public PlayerDashStateBase dashState;
    public PlayerDashStateDefault dStateDefault = new PlayerDashStateDefault();
    public PlayerDashStateDash dStateDash = new PlayerDashStateDash();
    public int isDashHash;
    public float dashSpeed = 5f;

    public Dictionary<string, bool> inventory = new Dictionary<string, bool>();

    public float healTimer;
    public float healCD = 1f;
    public GameObject healEffect;
    public int healNum = 3;
    public GameObject[] healUI = new GameObject[3];
    public GameObject healUIP;

    public float hitForce = 1f;
    public PlayerGeneralStateBase generalState;
    public PGStateDefault gStateDefault = new PGStateDefault();
    public PGStateDamage1 gStateDamage1 = new PGStateDamage1();
    public PGStateDamage2 gStateDamage2 = new PGStateDamage2();
    public PGStateDead gStateDead = new PGStateDead();
}
