using Fusion;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class DealerController : NetworkBehaviour
{
    [SerializeField]
    private Animator animator;

    private Dictionary<PlayerRef, Vector3> _playerCardPositions;
    private GameObject _cardPrefab;

    private NetworkManager networkManager;

    private bool _isDealing = false;

    public override void Spawned()
    {
        networkManager = Main.instance.networkManager;
        _playerCardPositions = Main.instance._playerCardPositions;
        _cardPrefab = Main.instance.data.gameData.cardPrefab;

        MainEventBus.OnRequestDeal += HandleDealRequest;
    }

    private void HandleDealRequest(PlayerRef requester)
    {
        if (HasStateAuthority && !_isDealing)
        {
            RPC_DealCards(requester);
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    private async void RPC_DealCards(PlayerRef player)
    {
        if (_isDealing)
            return;

        if (!HasStateAuthority)
            return;

        _isDealing = true;

        animator.Play("Dealing");

        await Task.Delay(300);

        for (int i = 0; i < 4; i++)
        {
            DealCardTo(player);
        }

        animator.Play("Idle");

        _isDealing = false;
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        networkManager = null;
        _playerCardPositions = null;
        _cardPrefab = null;

        MainEventBus.OnRequestDeal -= HandleDealRequest;
    }

    public void DealCardTo(PlayerRef player)
    {
        if (!_playerCardPositions.TryGetValue(player, out var targetPos))
        {
            Debug.LogWarning($"[Dealer] No card position found for player: {player}");
            return;
        }

        // Spawn a card object at targetPos (networked spawn)
        networkManager.SpawnEntity(_cardPrefab, transform.position);
    }

}
