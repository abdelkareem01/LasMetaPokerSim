namespace Scripts.Core
{
    using Fusion;
    using Scripts.Data;
    using Scripts.Managers;
    using Scripts.Networking.Photon;
    using Scripts.StateManagement.StateManagers;
    using System.Collections.Generic;
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
        public AudioSource mainAudioSrc;
        public Light pointLight;

        [HideInInspector]
        public DataCollection data;

        [SerializeField]
        private GameObject networkRunnerGO;

        public Dictionary<PlayerRef, Vector3> _playerCardPositions = new();

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(networkRunnerGO);
            data = Resources.Load<DataCollection>(DataCollection.path);
            pointLight.enabled = true;
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
}
