public class StartupState : BaseGameState
{
    public StartupState(GameStateManager stateManager) : base(stateManager)
    {
        stateType = GameStateType.Startup;
    }
}
