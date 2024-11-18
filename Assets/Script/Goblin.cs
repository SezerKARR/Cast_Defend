using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : EnemySkeleton
{
    public override void Start()
    {
        base.Start();
    }
    public override void OnCollisionStay2D(Collision2D collision)
    {
        base.OnCollisionStay2D(collision);
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }
    public override void Update()
    {
        base.Update();
    }
    public override void GiveDamage(float damage)
    {
        base.GiveDamage(damage);
    }

}
