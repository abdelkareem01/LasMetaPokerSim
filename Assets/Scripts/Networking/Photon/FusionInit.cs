using System;
using System.Threading.Tasks;
using Fusion;
using Fusion.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FusionInit : MonoBehaviour
{
    [SerializeField]
    private GameObject NetworkRunnerGO;

    [Header("Runner Settings")]
    public string SessionName = "LasMetaPokerPrototype";
    public GameMode GameMode = GameMode.Shared;

    private async void Awake()
    {
        DontDestroyOnLoad(NetworkRunnerGO.gameObject);

        // Create runner
        var runner = NetworkRunnerGO.gameObject.AddComponent<NetworkRunner>();
        runner.ProvideInput = true;

        var sceneManager = NetworkRunnerGO.gameObject.AddComponent<NetworkSceneManagerDefault>();
        var objectProvider = NetworkRunnerGO.gameObject.AddComponent<NetworkObjectProviderDefault>();
        var networkEvents = NetworkRunnerGO.gameObject.AddComponent<NetworkEvents>();

        Debug.Log("[Fusion] Starting game...");

        var result = await runner.StartGame(new StartGameArgs
        {
            GameMode = GameMode,
            SessionName = SessionName,
            SceneManager = sceneManager,
            ObjectProvider = objectProvider,
        });

        FusionLogger fusionLogger = new FusionLogger();
        runner.AddCallbacks(fusionLogger);

        if(runner.IsSceneAuthority)
        await runner.LoadScene(SceneRef.FromIndex(SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/Main.unity")), LoadSceneMode.Single);

        if (result.Ok)
            Debug.Log("[Fusion] Game started successfully in Shared mode.");
        else
            Debug.LogError($"[Fusion] Failed to start: {result.ShutdownReason}");
    }
}
