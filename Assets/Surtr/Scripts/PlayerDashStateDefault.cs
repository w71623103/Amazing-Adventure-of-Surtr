using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerDashStateDefault : PlayerDashStateBase
{
    [SerializeField] private float noDashTimer;
    [SerializeField] private float DashCD = 1f;
    public override void EnterState(PlayerCore pl)
    {
        noDashTimer = DashCD;
    }
    public override void Update(PlayerCore pl)
    {
        noDashTimer -= Time.deltaTime;
        if (noDashTimer <= 0f) 
        {
            if (pl.model.dashInput)
            {
                pl.ChangeDashState(pl.model.dStateDash);
            }
        } //allow dash
    }
    public override void LeaveState(PlayerCore pl)
    {
        
    }
}
