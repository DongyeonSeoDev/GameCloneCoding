using UnityEngine;

namespace Monster
{
    public class MonsterRun : Command
    {
        Transform targetTransform;
        Transform currentTransform;

        Vector3 targetPosition;

        float moveSpeed;

        public MonsterRun(Transform target, Transform current, float speed)
        {
            targetTransform = target;
            currentTransform = current;
            moveSpeed = speed;
        }

        public override void Execute()
        {
            targetPosition = (targetTransform.position - currentTransform.position).normalized;
            targetPosition *= moveSpeed * Time.deltaTime;
            targetPosition.y = 0f;
            currentTransform.position += targetPosition;
        }
    }

    public class MonsterHurt : Command
    {
        private MonsterData monsterData;
        
        public MonsterHurt(MonsterData data)
        {
            monsterData = data;
        }

        public override void Execute()
        {
            monsterData.hp -= monsterData.damagedValue;
            monsterData.isDamaged = false;
        }
    }

    public class MonsterDie : Command
    {
        private GameObject enemyObject;
        private CONEntity conEntity;

        public MonsterDie(GameObject enemyObj, CONEntity conEntity)
        {
            enemyObject = enemyObj;
            this.conEntity = conEntity;
        }

        public override void Execute()
        {
            conEntity.SetActive(false);
        }
    }
}