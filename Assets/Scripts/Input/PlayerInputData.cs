namespace Scripts.Input
{
    using Fusion;
    using UnityEngine;

    enum PlayerButtons
    {
        Space = 0,
        Forward = 1,
        Backward = 2,
        Right = 3,
        Left = 4,
        RequestDeal = 5,
        ToggleUI = 6,
    }

    public struct PlayerInputData : INetworkInput
    {
        public NetworkButtons playerButtons;
        public Vector2 perspectiveDelta;
    }
}