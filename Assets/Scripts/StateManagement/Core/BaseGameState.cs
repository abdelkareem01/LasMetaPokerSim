using UnityEngine;

public enum GameStateType
{
    Startup = 0,
    Home = 1,
    Gameplay = 2,
}

public class BaseGameState : BaseState<BaseGameState>
{
    public string sceneName;

    protected BaseGameState(BaseStateManager<BaseGameState> stateManager) : base(stateManager){}

    public override void OnEnter(BaseGameState previousState, object data){}

    public override void OnExit(BaseGameState previousState, object data){}
}
