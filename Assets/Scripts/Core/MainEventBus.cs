namespace Scripts.Core
{
    using Fusion;
    using Scripts.StateManagement.Core;
    using System;

    public class MainEventBus
    {
        public static Action<PlayerRef> OnRequestDeal;
        public static Action OnNetworkReady;
        public static Action<PlayerRef> OnPlayerJoined;
        public static Action OnGameplayLoaded;
        public static Action<GameStateType> OnStateChanged;
        public static Action SwitchDealerAnimation;
        public static Action<NetworkRunner> OnAssignCardSlots;
    }
}
