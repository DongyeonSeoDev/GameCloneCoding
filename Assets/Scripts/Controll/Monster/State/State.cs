namespace Monster
{
    public partial class State
    {
        public enum eState
        {
            Run, Hurt, Attack, Die
        }

        public enum eEvent
        {
            START, UPDATE, END
        }

        public eState stateName;
        protected eEvent currentEvent;

        protected State nextState;
        protected MonsterData monsterData;

        public State(eState state, MonsterData data)
        {
            stateName = state;
            monsterData = data;
            currentEvent = eEvent.START;
        }

        protected virtual void Start()
        {
            currentEvent = eEvent.UPDATE;
        }

        protected virtual void Update()
        {
            StateChangeCondition();
        }

        protected virtual void End() { }

        public State Process()
        {
            switch (currentEvent)
            {
                case eEvent.START:
                    Start();
                    break;
                case eEvent.UPDATE:
                    Update();
                    break;
                case eEvent.END:
                    End();
                    return nextState;
            }

            return this;
        }

        protected virtual void StateChangeCondition() { }

        protected void ChangeState(State state)
        {
            nextState = state;
            currentEvent = eEvent.END;
        }
    }
}