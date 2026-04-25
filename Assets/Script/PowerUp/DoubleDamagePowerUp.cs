using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamagePowerUp : PowerUpDecorator
{
    public DoubleDamagePowerUp(IPowerUp inner) : base(inner) { }

    public override int ModifyDamage(int damage)
    {
        return wrapped.ModifyDamage(damage) * 2;
    }
}