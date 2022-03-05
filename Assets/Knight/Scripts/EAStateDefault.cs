using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EAStateDefault : EnemyAttackStateBase
{
    public override void EnterState(EnemyCore em)
    {
        //em.model.comboCount = 0;

    }
    public override void Update(EnemyCore em)
    {
        if (em.model.attackCondition)
        {
            em.ChangeAttackState(em.model.atkStateA);

        }
    }
    public override void LeaveState(EnemyCore em)
    {

    }
}
