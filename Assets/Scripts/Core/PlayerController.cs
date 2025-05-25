using Fusion;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [Networked] public NetworkButtons Buttons { get; set; }

    [SerializeField] private PlayerInputHandler playerInputHandler;

    public override void Spawned()
    {
        if(HasInputAuthority)
        Runner.AddCallbacks(playerInputHandler);
    }


    public override void FixedUpdateNetwork()
    {
        if (GetInput<PlayerInputData>(out var input) == false) return;

        var pressed = input.playerButtons.GetPressed(Buttons);
        var released = input.playerButtons.GetReleased(Buttons);

        Buttons = input.playerButtons;

        if (pressed.IsSet(PlayerButtons.Space))
        {
            MainEventBus.OnRequestJump?.Invoke();
        }
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        Runner.RemoveCallbacks(playerInputHandler);
    }
}
