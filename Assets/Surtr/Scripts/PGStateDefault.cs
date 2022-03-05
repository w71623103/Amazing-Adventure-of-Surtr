using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGStateDefault : PlayerGeneralStateBase
{
    public override void EnterState(PlayerCore pl) 
    {
        
    }
    public override void Update(PlayerCore pl) 
    {
        if (pl.model.hp <= 0) pl.ChangeGeneralState(pl.model.gStateDead);
    }

    public override void LeaveState(PlayerCore pl) 
    {
        pl.ChangeAttackState(pl.model.atkStateDefault);
    }
}
