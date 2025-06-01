namespace Scripts.StateManagement.Core
{
    public abstract class BaseState<T> where T : BaseState<T>
    {
        public GameStateType stateType;

        protected BaseStateManager<T> StateManager;

        public BaseState(BaseStateManager<T> stateManager)
        {
            StateManager = stateManager;
        }

        public abstract void OnEnter(T previousState, object data);

        public abstract void OnExit(T nextState, object data);

        public virtual void OnUpdate()
        {
        }

        public virtual void OnFixedUpdate()
        {
        }

        public virtual void OnLateUpdate()
        {
        }
    }
}