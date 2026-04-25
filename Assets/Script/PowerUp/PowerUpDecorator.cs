using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpDecorator : IPowerUp
{
    protected readonly IPowerUp wrapped;

    protected PowerUpDecorator(IPowerUp inner)
    {
        wrapped = inner;
    }

    public virtual int ModifyDamage(int damage)
    {
        return wrapped.ModifyDamage(damage);
    }

    public virtual int ModifyHeal(int heal)
    {
        return wrapped.ModifyHeal(heal);
    }
}
