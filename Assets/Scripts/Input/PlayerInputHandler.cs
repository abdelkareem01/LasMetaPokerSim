using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : SimulationCallbackHandler
{
    public override void OnInput(NetworkRunner runner, NetworkInput input)
    {
        var playerInputData = new PlayerInputData();

        playerInputData.playerButtons.Set(PlayerButtons.Forward, Input.GetKey(KeyCode.W));
        playerInputData.playerButtons.Set(PlayerButtons.Backward, Input.GetKey(KeyCode.S));
        playerInputData.playerButtons.Set(PlayerButtons.Right, Input.GetKey(KeyCode.D));
        playerInputData.playerButtons.Set(PlayerButtons.Left, Input.GetKey(KeyCode.A));
        playerInputData.playerButtons.Set(PlayerButtons.RequestDeal, Input.GetKey(KeyCode.G));
        playerInputData.playerButtons.Set(PlayerButtons.ToggleUI, Input.GetKey(KeyCode.T));

        if (Application.isFocused)
        {
            playerInputData.perspectiveDelta = new Vector2(
                Input.GetAxis("Mouse X"),
                Input.GetAxis("Mouse Y")
            );
        }
        else
        {
            playerInputData.perspectiveDelta = Vector2.zero;
        }

        input.Set(playerInputData);
    }
}
