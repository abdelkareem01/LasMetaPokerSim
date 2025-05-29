using Fusion;
using System;

public class MainEventBus 
{
    public static Action OnRequestDeal;
    public static Action OnNetworkReady;
    public static Action<PlayerRef> OnPlayerJoined;
    public static Action OnGameplayLoaded;
    public static Action<GameStateType> OnStateChanged;
}
