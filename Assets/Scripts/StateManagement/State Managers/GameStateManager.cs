using Unity.VisualScripting;
using UnityEngine;

public class GameStateManager : BaseStateManager<BaseGameState>
{
    public override void Init()
    {
        states.Add(GameStateType.Startup, new StartupState(this));
        states.Add(GameStateType.Home, new HomeState(this));
        states.Add(GameStateType.Gameplay, new GameplayState(this));

        ChangeState(GameStateType.Startup);

        MainEventBus.OnNetworkReady += () =>
        {
            ChangeState(GameStateType.Gameplay);
        };
    }
}
