namespace Scripts.StateManagement.Core
{
    using UnityEngine;

    public enum WindowStateType
    {
        StartupScreen = 0,
        GameplayHUD = 1,
        HomeScreen = 2,
    }

    public class BaseWindowState : BaseState<BaseWindowState>
    {
        protected GameObject canvasRoot;

        protected BaseWindowState(BaseStateManager<BaseWindowState> stateManager, GameObject canvas) : base(stateManager)
        {
            canvasRoot = canvas;
        }

        public override void OnEnter(BaseWindowState previousState, object data)
        {
        }

        public override void OnExit(BaseWindowState nextState, object data)
        {
        }
    }
}
