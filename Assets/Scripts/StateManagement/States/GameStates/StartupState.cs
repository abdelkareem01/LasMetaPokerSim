using Scripts.Core;
using Scripts.StateManagement.Core;
using Scripts.StateManagement.StateManagers;

namespace Scripts.StateManagement.States.GameStates
{
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
}