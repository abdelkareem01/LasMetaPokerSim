using Fusion;
using UnityEngine;
public class PlayerInputHandler : SimulationCallbackHandler
{
    public override void OnInput(NetworkRunner runner, NetworkInput input)
    {
        var playerInputData = new PlayerInputData();

        playerInputData.playerButtons.Set(PlayerButtons.Space, Input.GetKey(KeyCode.Space));

        input.Set(playerInputData);
    }
}
