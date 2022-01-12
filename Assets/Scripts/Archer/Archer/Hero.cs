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
        PoolManager.CreatePool(archerSO.skillEffect, transform, 3);
    }

    private void Start()
    {
        curState = new Patrol(gameObject, anim, archerSO.moveSpeed);

        Instantiate(ArcherGameManager.Instance.skillBtnPrefab, ArcherGameManager.Instance.skillBtnParent)
            .GetComponent<SkillButton>().SetSkillInfo(archerSO.skillNeedMp, archerSO.skillSpirte,skillCmd);
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

        Arrow arrow = PoolManager.GetItem("Arrow").GetComponent<Arrow>();
        arrow.transform.position = transform.position;
        arrow.SetArrow(archerSO.arrowSpeed, archerSO.strength, target.position);


    }

    public override void UseSkill()
    {
        if (!ArcherGameManager.Instance.CanUseSkill(archerSO.skillNeedMp)) return;

        GameObject o = PoolManager.GetItem(archerSO.skillEffect.name);
        o.transform.localPosition = Vector2.zero;

        Time.timeScale = 0;

        int index = 0;
        foreach(Monster.Monster m in FindObjectsOfType<Monster.Monster>())
        {
            m.GetDamaged(archerSO.skillDamage);

            Debug.Log("Test");

            index++;
            if (index == archerSO.skillAtkEnemyCnt) break;
        }
    }
}
