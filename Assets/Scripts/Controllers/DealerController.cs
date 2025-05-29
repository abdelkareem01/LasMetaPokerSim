using Fusion;
using Unity.VisualScripting;
using UnityEngine;

public class DealerController : NetworkBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float jumpForce = 5f;

    public override void Spawned()
    {
        //MainEventBus.OnRequestDeal += RPC_Jump;
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    private void RPC_Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        MainEventBus.OnRequestDeal -= RPC_Jump;
    }
}
