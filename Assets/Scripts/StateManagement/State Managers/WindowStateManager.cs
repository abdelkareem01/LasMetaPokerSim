using System;
using System.Collections.Generic;
using UnityEngine;

public class WindowStateManager : BaseStateManager<BaseWindowState>
{
    protected Dictionary<WindowStateType, BaseWindowState> _states = new();

    public override void ChangeState(WindowStateType type, object data = null)
    {
        if (windowStates.TryGetValue(type, out BaseWindowState nextState))
        {
            var previousState = currentState;

            currentState?.OnExit(previousState, data);
            currentState = nextState;
            currentState.OnEnter(nextState, data);
        }
        else
        {
            throw new NotImplementedException($"[WindowState Management]: Error! {type.ToString()}State not implemented in: {GetType().Name}");
        }
    }

    public override void Init()
    {
        windowStates.Add(WindowStateType.HomeScreen, new HomeScreen(this, CanvasHelper.Instance.home_Canvas));
        windowStates.Add(WindowStateType.StartupScreen, new StartupScreen(this, CanvasHelper.Instance.startup_Canvas));
        windowStates.Add(WindowStateType.GameplayHUD, new GameplayHUD(this, CanvasHelper.Instance.gamplayHUD_Canvas));

        ChangeState(WindowStateType.StartupScreen);
    }
}
