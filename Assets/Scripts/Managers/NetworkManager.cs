using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Collections.Unicode;

public class NetworkManager
{
    private readonly NetworkRunner networkRunner;
    private readonly NetworkSceneManagerDefault networkSceneManager;
    private readonly NetworkObjectProviderDefault networkObjectProvider;
    
    private NetworkData networkData;

    public NetworkManager(NetworkRunner runner, NetworkSceneManagerDefault sceneManager, NetworkObjectProviderDefault objectProvider)
    {
        networkRunner = runner;
        networkSceneManager = sceneManager;
        networkObjectProvider = objectProvider;
    }

    public async void Init()
    {
        MainEventBus.OnStateChanged += LoadScene;

        networkData = Main.instance.data.networkData;

        networkRunner.ProvideInput = true;

        var result = await networkRunner.StartGame(new StartGameArgs
        {
            GameMode = networkData.GameMode,
            SessionName = networkData.SessionName,
            SceneManager = networkSceneManager,
            ObjectProvider = networkObjectProvider,
        });

        Debug.Log("[NetworkManager] Runner started.");
        MainEventBus.OnNetworkReady?.Invoke();
    }

    public void AddCallbacks(INetworkRunnerCallbacks callbacks)
    {
        networkRunner.AddCallbacks(callbacks);
    }

    private async void LoadScene(GameStateType stateType)
    {
       await networkRunner.LoadScene(SceneRef.FromIndex(SceneUtility.GetBuildIndexByScenePath($"Assets/Scenes/{stateType.ToString()}.unity")), LoadSceneMode.Single);
    }

    public bool IsLocalPlayer(PlayerRef player)
    {
        return (player == networkRunner.LocalPlayer);
    }

    public PlayerRef GetPlayer()
    {
        return networkRunner.LocalPlayer;
    }

    public void SpawnPlayer(GameObject player, Vector3 position)
    {
        networkRunner.Spawn(player, position, Quaternion.identity, networkRunner.LocalPlayer);
    }
}