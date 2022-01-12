using UnityEngine;

namespace Monster
{
    public class Monster : MonoBehaviour
    {
        private State currentState;
        private MonsterData monsterData;

        private void OnEnable()
        {
            monsterData = new MonsterData()
            {
                enemyAnimator = GetComponent<Animator>(),
                enemyObj = gameObject,
                castleObject = GameObject.FindGameObjectWithTag("Castle"),
                conEntity = GetComponent<CONEntity>(),
                moveSpeed = 5f,
                hp = 50,
                attackValue = 10,
                castleAttackableDistance = 1f,
                damagedValue = 0,
                isDamaged = false
            };

            MonsterAttackCheck monsterAttackCheck = GetComponentInChildren<MonsterAttackCheck>();

            if (monsterAttackCheck != null)
            {
                monsterAttackCheck.SetAttackValue(monsterData.attackValue);
            }

            currentState = new Run(monsterData);
        }

        void Update()
        {
            if (currentState != null)
            {
                currentState = currentState.Process();
            }
        }

        public void GetDamaged(int damagedValue)
        {
            if (!monsterData.isDamaged)
            {
                monsterData.isDamaged = true;
                monsterData.damagedValue = damagedValue;
            }
        }
    }
}