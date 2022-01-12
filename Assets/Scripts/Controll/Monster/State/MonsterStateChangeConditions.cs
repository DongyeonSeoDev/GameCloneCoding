namespace Monster
{
    public partial class Run : State
    {
        protected override void StateChangeCondition()
        {
            if (AnyStateChangeState()) { }
            else if (MonsterStatesCheck.CanAttackCastle(monsterData))
            {
                ChangeState(new Attack(monsterData));
            }
        }
    }

    public partial class Hurt : State
    {
        protected override void StateChangeCondition()
        {
            if (AnyStateChangeState()) { }
            else if (MonsterStatesCheck.CanAttackCastle(monsterData))
            {
                ChangeState(new Attack(monsterData));
            }
            else
            {
                ChangeState(new Run(monsterData));
            }
        }
    }

    public partial class Attack : State
    {
        protected override void StateChangeCondition()
        {
            if (AnyStateChangeState()) { }
            else if (!MonsterStatesCheck.CanAttackCastle(monsterData))
            {
                ChangeState(new Run(monsterData));
            }
        }
    }

    public partial class Die : State
    {
        protected override void StateChangeCondition()
        {
            ChangeState(null);
        }
    }

    public partial class State
    {
        public bool AnyStateChangeState()
        {
            if (monsterData.isDamaged)
            {
                ChangeState(new Hurt(monsterData));
            }
            else if (monsterData.hp <= 0)
            {
                ChangeState(new Die(monsterData));
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}