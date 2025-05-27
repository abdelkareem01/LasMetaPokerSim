using System;
using System.Collections.Generic;

public abstract class BaseStateManager<T> where T : BaseState<T>
{
    protected T _currentState;

    internal Dictionary<Enum, T> _states;

    public virtual void ChangeState(GameStateType type, object data = null)
    {
        if (_states.TryGetValue(type, out T nextState))
        {

            var previousState = _currentState;

            _currentState?.OnExit(nextState, data);
            _currentState = nextState;
            _currentState.OnEnter(previousState, data);
        }
        else 
        {
            throw new NotImplementedException($"[StateManager]: Error! State not implemented.");        
        }

    }

    public virtual void Init(){}

    public virtual void OnFixedUpdate() => _currentState?.OnFixedUpdate();

    public virtual void OnLateUpdate() => _currentState?.OnLateUpdate();

    public virtual void OnUpdate() => _currentState?.OnUpdate();
}
