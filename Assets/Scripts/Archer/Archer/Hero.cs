using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using One;

public class Hero : Archer
{

    State curState;

    Transform target;

    protected override void Awake()
    {
        base.Awake();
        skillCmd = new SkillCommand(this);
    }

    private void Start()
    {
        curState = new Patrol(gameObject, anim, archerSO.moveSpeed);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        curState = curState.Process();
    }

    public override void Attack()
    {
       
    }

    public override void UseSkill()
    {
        
    }
}
