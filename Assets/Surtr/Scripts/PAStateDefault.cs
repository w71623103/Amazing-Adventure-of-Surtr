using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PAStateDefault : PlayerAttackStateBase
{
    public override void EnterState(PlayerCore pl)
    {
        pl.model.comboCount = 0;
        
    }
    public override void Update(PlayerCore pl)
    {
        if (pl.model.attackInput)
        {
            pl.ChangeAttackState(pl.model.atkStateA);
            
        }
    }
    public override void LeaveState(PlayerCore pl)
    {

    }
}
