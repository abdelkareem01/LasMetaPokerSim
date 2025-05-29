using UnityEngine.SceneManagement;

public class StartupState : BaseGameState
{
    public StartupState(GameStateManager stateManager) : base(stateManager)
    {
        stateType = GameStateType.Startup;
        sceneName = stateType.ToString();

        MainEventBus.OnNetworkReady += () =>
        {
            StateManager.ChangeState(GameStateType.Home);
        };
    }
}
