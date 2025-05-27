public class GameplayState : BaseGameState
{
    public GameplayState(GameStateManager stateManager) : base(stateManager)
    {
        stateType = GameStateType.Gameplay;
    }
}
