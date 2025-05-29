using Fusion;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main instance;

    private bool initialised;

    [Header("Main Managers")]
    public GameStateManager gameStateManager;
    public WindowStateManager windowStateManager;
    public NetworkManager networkManager;
    public PlayerManager playerManager;
    public FusionCallbacks callbacks;

    [HideInInspector]
    public DataCollection data;

    [SerializeField]
    private GameObject networkRunnerGO;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(networkRunnerGO);
        data = Resources.Load<DataCollection>(DataCollection.path);
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
        callbacks = new FusionCallbacks();
    }

    private void InitObjects()
    {
        gameStateManager.Init();
        windowStateManager.Init();
        networkManager.Init();
        networkManager.AddCallbacks(callbacks);
        playerManager.Init();
        initialised = true;
    }
}
