public class HomeState : BaseGameState
{
    public HomeState(GameStateManager stateManager) : base(stateManager) 
    {
        stateType = GameStateType.Home;
        sceneName = stateType.ToString();
    }
}
