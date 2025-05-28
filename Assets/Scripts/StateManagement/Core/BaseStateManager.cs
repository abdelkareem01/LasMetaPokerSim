using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public abstract class BaseStateManager<T> where T : BaseState<T>
{
    protected T currentState;

    internal Dictionary<Enum, T> states;

    public virtual void Init(){}

    public virtual void OnFixedUpdate() => currentState?.OnFixedUpdate();

    public virtual void OnLateUpdate() => currentState?.OnLateUpdate();

    public virtual void OnUpdate() => currentState?.OnUpdate();

    public virtual void ChangeState(GameStateType type, object data = null)
    {
        if (states.TryGetValue(type, out T nextState))
        {
            var previousState = currentState;

            currentState?.OnExit(nextState, data);
            currentState = nextState;
            currentState.OnEnter(previousState, data);

            MainEventBus.OnStateChanged?.Invoke(type);
        }
        else 
        {
            throw new NotImplementedException($"[StateManagement]: Error! {type.ToString()}State not implemented in: {GetType().Name}");        
        }
    }
}
