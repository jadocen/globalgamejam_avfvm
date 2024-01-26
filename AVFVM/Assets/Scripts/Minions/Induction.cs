using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Induction : MinionBase
{
    public BoxCollider2D _inductionHeat;

    public override void Attack()
    {
        base.Attack();
        _inductionHeat.enabled = true;
        Debug.Log("Induction - Attack");
    }

    public override void ChargeTime()
    {
        base.ChargeTime();
        _inductionHeat.enabled = false;
        Debug.Log("Induction - Charging");
    }
}
