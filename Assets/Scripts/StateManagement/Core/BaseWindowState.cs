using UnityEngine;

public enum WindowStateType
{
    GameplayCanvas = 0,
    PopupCanvas = 1
    
}


public class BaseWindowState : BaseState<BaseWindowState>
{
    protected BaseWindowState(BaseStateManager<BaseWindowState> stateManager) : base(stateManager) { }

    public override void OnEnter(BaseWindowState previousState, object data)
    {
    }

    public override void OnExit(BaseWindowState previousState, object data)
    {
    }
}
