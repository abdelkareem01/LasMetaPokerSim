using Fusion;
using System;
using UnityEngine;

public class MainEventBus 
{
    public static Action <PlayerRef> OnRequestDeal;
    public static Action OnNetworkReady;
    public static Action<PlayerRef> OnPlayerJoined;
    public static Action OnGameplayLoaded;
    public static Action<GameStateType> OnStateChanged;
    public static Action SwitchDealerAnimation;
    public static Action<NetworkRunner> OnAssignCardSlots;
}
