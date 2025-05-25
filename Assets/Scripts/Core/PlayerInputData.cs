using Fusion;

enum PlayerButtons
{
    Space = 0
}

public struct PlayerInputData : INetworkInput
{
    public NetworkButtons playerButtons;
}
