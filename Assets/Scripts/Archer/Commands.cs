namespace One
{
    public abstract class Command 
    {
        public Archer archer;
        public abstract void Execute();
    }

    public class AttackCommand : Command
    {
        public AttackCommand(Archer ac)
        {
            archer = ac;
        }

        public override void Execute()
        {
            archer.Attack();
        }
    }

    public class SkillCommand : Command
    {
        public SkillCommand(Archer ac)
        {
            archer = ac;
        }
        public override void Execute()
        {
            archer.UseSkill();
            UnityEngine.Debug.Log("SkillTest");
            
        }
    }

    public class DoNothingCommand : Command
    {
        public override void Execute()
        {
            
        }
    }
}