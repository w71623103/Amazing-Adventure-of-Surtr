using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerGeneralStateBase
{
    public abstract void EnterState(PlayerCore pl);
    public abstract void Update(PlayerCore pl);
    public abstract void LeaveState(PlayerCore pl);
}
