using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class EnemyGeneralStateBase
{
    public abstract void EnterState(EnemyCore em);
    public abstract void Update(EnemyCore em);
    public abstract void LeaveState(EnemyCore em);
}
