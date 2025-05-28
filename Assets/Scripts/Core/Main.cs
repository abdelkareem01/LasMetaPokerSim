using Fusion;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main instance;
    private bool initialised;

    public GameStateManager gameStateManager;
    public WindowStateManager windowStateManager;
    public NetworkManager networkManager;
    public PlayerManager playerManager;
    public FusionLogger logger;

    [SerializeField]
    private GameObject networkRunnerGO, playerPrefabs;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(networkRunnerGO);
    }

    void Start()
    {
        CreateObjects();
        InitObjects();
    }

    void Update()
    {
        if (!initialised) return;
        gameStateManager?.OnUpdate();
    }

    private void FixedUpdate()
    {
        gameStateManager?.OnFixedUpdate();
    }

    private void LateUpdate()
    {
        gameStateManager?.OnLateUpdate();
    }

    private void CreateObjects()
    {
        networkManager = new NetworkManager(networkRunnerGO.AddComponent<NetworkRunner>(),
            networkRunnerGO.AddComponent<NetworkSceneManagerDefault>(),
            networkRunnerGO.AddComponent<NetworkObjectProviderDefault>());
        
        gameStateManager = new GameStateManager();
        windowStateManager = new WindowStateManager();
        playerManager = new PlayerManager();
        logger = new FusionLogger();
    }

    private void InitObjects()
    {
        gameStateManager.Init();
        windowStateManager.Init();
        networkManager.Init();
        networkManager.AddCallbacks(logger);
        playerManager.Init();
        initialised = true;
    }
}
