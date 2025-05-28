using Unity.VisualScripting;
using UnityEngine;

public class GameStateManager : BaseStateManager<BaseGameState>
{
    public override void Init()
    {
        states.Add(GameStateType.Startup, new GameplayState(this));
        states.Add(GameStateType.Home, new GameplayState(this));
        states.Add(GameStateType.Gameplay, new GameplayState(this));

        MainEventBus.OnNetworkReady += () =>
        {
            ChangeState(GameStateType.Home);
        };
    }
}
