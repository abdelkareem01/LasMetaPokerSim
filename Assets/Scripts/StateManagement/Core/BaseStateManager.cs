using System;
using System.Collections.Generic;

public abstract class BaseStateManager<T> where T : BaseState<T>
{
    protected T currentState;

    protected Dictionary<GameStateType, T> gameStates = new();

    protected Dictionary<WindowStateType, T> windowStates = new();

    public virtual void Init(){}

    public virtual void OnFixedUpdate() => currentState?.OnFixedUpdate();

    public virtual void OnLateUpdate() => currentState?.OnLateUpdate();

    public virtual void OnUpdate() => currentState?.OnUpdate();

    public virtual void ChangeState(GameStateType type, object data = null){}

    public virtual void ChangeState(WindowStateType type, object data = null){}
}
