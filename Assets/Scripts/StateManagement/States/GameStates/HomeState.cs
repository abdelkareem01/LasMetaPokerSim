using Scripts.StateManagement.Core;
using Scripts.StateManagement.StateManagers;

namespace Scripts.StateManagement.States.GameStates
{
    public class HomeState : BaseGameState
    {
        public HomeState(GameStateManager stateManager) : base(stateManager)
        {
            stateType = GameStateType.Home;
            sceneName = stateType.ToString();
        }
    }
}
