using UnityEngine;

namespace Monster
{
    public partial class Run : State
    {
        private Command monsterRunCommand;

        public Run(MonsterData data) : base(eState.Run, data)
        {
            if (data.castleObject != null)
            {
                monsterRunCommand = new MonsterRun(data.castleObject.transform, data.enemyObj.transform, data.moveSpeed);
            }
        }

        protected override void Start()
        {
            monsterData.enemyAnimator.SetTrigger(monsterData.hashRun);

            base.Start();
        }

        protected override void Update()
        {
            monsterRunCommand.Execute();

            base.Update();
        }

        protected override void End()
        {
            monsterData.enemyAnimator.ResetTrigger(monsterData.hashRun);
        }
    }

    public partial class Hurt : State
    {
        private Command monsterHurtCommand;

        private float currentTime;

        public Hurt(MonsterData data) : base(eState.Hurt, data)
        {
            monsterHurtCommand = new MonsterHurt(monsterData);
        }

        protected override void Start()
        {
            monsterData.enemyAnimator.SetTrigger(monsterData.hashHurt);
            monsterHurtCommand.Execute();

            currentTime = 0f;

            base.Start();
        }

        protected override void Update()
        {
            currentTime += Time.deltaTime;

            if (currentTime >= 1f)
            {
                base.Update();
            }
        }

        protected override void End()
        {
            monsterData.enemyAnimator.ResetTrigger(monsterData.hashHurt);
        }
    }

    public partial class Attack : State
    {
        public Attack(MonsterData data) : base(eState.Attack, data) { }
        protected override void Start()
        {
            monsterData.enemyAnimator.SetTrigger(monsterData.hashAttack);

            base.Start();
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void End()
        {
            monsterData.enemyAnimator.ResetTrigger(monsterData.hashAttack);
        }
    }

    public partial class Die : State
    {
        private Command monsterDieCommand;

        private float currentTime;

        public Die(MonsterData data) : base(eState.Die, data)
        {
            monsterDieCommand = new MonsterDie(monsterData.enemyObj, monsterData.conEntity);
        }

        protected override void Start()
        {
            monsterData.enemyAnimator.SetTrigger(monsterData.hashDie);

            currentTime = 0f;

            base.Start();
        }

        protected override void Update()
        {
            currentTime += Time.deltaTime;

            if (currentTime >= 1f)
            {
                monsterDieCommand.Execute();

                base.Update();
            }
        }

        protected override void End()
        {
            monsterData.enemyAnimator.ResetTrigger(monsterData.hashDie);
        }
    }
}