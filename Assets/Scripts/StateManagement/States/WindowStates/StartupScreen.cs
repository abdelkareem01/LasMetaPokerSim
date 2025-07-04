namespace Scripts.StateManagement.States.WindowStates
{
    using Scripts.Core;
    using Scripts.StateManagement.Core;
    using Scripts.StateManagement.StateManagers;
    using UnityEngine;

    public class StartupScreen : BaseWindowState
    {
        public StartupScreen(WindowStateManager manager, GameObject canvas)
            : base(manager, canvas)
        {
        }

        public override void OnEnter(BaseWindowState previousState, object data)
        {
            canvasRoot.SetActive(true);
            CanvasHelper.Instance.startup_Loadingtxt.SetActive(true);
            MainEventBus.OnNetworkReady += () =>
            {
                StateManager.ChangeState(WindowStateType.HomeScreen);
            };
        }

        public override void OnExit(BaseWindowState nextState, object data)
        {
            CanvasHelper.Instance.startup_Loadingtxt.SetActive(false);
            canvasRoot.SetActive(false);
        }

    }
}
