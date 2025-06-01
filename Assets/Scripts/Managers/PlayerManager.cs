namespace Scripts.Managers
{
    using UnityEngine;
    using Fusion;
    using Scripts.Core;

    public class PlayerManager
    {
        private bool playerJoined = false;
        private bool sceneLoaded = false;

        private NetworkManager networkManager;
        private GameObject playerPrefab;

        public void Init()
        {
            networkManager = Main.instance.networkManager;
            playerPrefab = Main.instance.data.playerData.playerPrefab;

            MainEventBus.OnPlayerJoined += PlayerJoined;
            MainEventBus.OnGameplayLoaded += SceneLoadDone;
        }

        public void PlayerJoined(PlayerRef player)
        {
            if (networkManager.IsLocalPlayer(player))
            {
                playerJoined = true;
                SpawnPlayer();
            }
        }

        public void SceneLoadDone()
        {
            sceneLoaded = true;
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            if (playerJoined && sceneLoaded)
            {
                Debug.Log("[Fusion] Spawned player");
                networkManager.SpawnPlayer(playerPrefab, new Vector3(5.67f, 5.48f, 2.7f));
            }
        }
    }
}
