using Fusion;
using UnityEngine;

public class DealerController : NetworkBehaviour
{
    [Networked] private TickTimer jumpCooldown { get; set; }

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float jumpForce = 5f;


    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();
        if (Object.HasStateAuthority && GetInput(out PlayerInputData input)) 
        {
            if (input.jumpPressed && jumpCooldown.ExpiredOrNotRunning(Runner))
            {
                jumpCooldown = TickTimer.CreateFromSeconds(Runner, 1f);
                Jump();
                RPC_Jump();
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    private void RPC_Jump()
    {
        if(!Object.HasStateAuthority) Jump();
    }
}
