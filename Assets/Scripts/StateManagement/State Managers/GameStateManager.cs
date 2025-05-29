using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateManager : BaseStateManager<BaseGameState>
{
    public override void ChangeState(GameStateType type, object data = null)
    {
        if (gameStates.TryGetValue(type, out BaseGameState nextState))
        {
            var previousState = currentState;

            currentState?.OnExit(nextState, data);
            currentState = nextState;
            currentState.OnEnter(previousState, data);

            MainEventBus.OnStateChanged?.Invoke(type);
        }
        else
        {
            throw new NotImplementedException($"[GameState Management]: Error! {type.ToString()}State not implemented in: {GetType().Name}");
        }
    }


    public override void Init()
    {
        gameStates.Add(GameStateType.Startup, new StartupState(this));
        gameStates.Add(GameStateType.Home, new HomeState(this));
        gameStates.Add(GameStateType.Gameplay, new GameplayState(this));

        ChangeState(GameStateType.Startup);
    }
}
