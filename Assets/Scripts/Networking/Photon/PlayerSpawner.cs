using UnityEngine;
using Fusion;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined, ISceneLoadDone
{
    [SerializeField]
    private GameObject playerPrefab;

    private bool playerJoined = false;
    private bool sceneLoaded = false;

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            playerJoined = true;
            SpawnPlayer();
        }
    }

    public void SceneLoadDone(in SceneLoadDoneArgs sceneInfo)
    {
        sceneLoaded = true;
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        if (playerJoined && sceneLoaded)
        {
            Debug.Log("[Fusion] Spawned player");
            Runner.Spawn(playerPrefab, new Vector3(-6.69f, 5.48f, -10.49f), Quaternion.identity, Runner.LocalPlayer);
        }
    }
}
