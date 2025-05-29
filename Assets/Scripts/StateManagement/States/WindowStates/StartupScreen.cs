using UnityEngine;
using UnityEngine.UI;

public class StartupScreen : BaseWindowState
{
    public StartupScreen(WindowStateManager manager, GameObject canvas)
        : base(manager, canvas)
    {
    }

    public override void OnEnter(BaseWindowState previousState, object data)
    {
        canvasRoot.SetActive(true);
        MainEventBus.OnNetworkReady += () =>
        {
            StateManager.ChangeState(WindowStateType.LoginScreen);
        };
    }

    public override void OnExit(BaseWindowState nextState, object data)
    {
        canvasRoot.SetActive(false);
    }
   
}
