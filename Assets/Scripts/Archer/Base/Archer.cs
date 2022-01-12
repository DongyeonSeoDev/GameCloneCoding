using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using One;

public abstract class Archer : MonoBehaviour
{
    public ArcherSO archerSO;

    protected int atkInt;

    protected Animator anim;

    public Command attackCmd;
    public Command skillCmd;

    protected virtual void Awake()
    {
        transform.localScale = archerSO.scale;
        anim = GetComponent<Animator>();
        atkInt = Animator.StringToHash("atk");
        attackCmd = new AttackCommand(this);
    }

    public abstract void Attack();

    public virtual void UseSkill()
    {

    }
}
