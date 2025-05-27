using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main instance;
    private bool _initialised;


    public GameStateManager gameStateManager;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        CreateObjects();
        InitObjects();
    }

    void Update()
    {
        if (!_initialised) return;
    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        
    }

    private void CreateObjects()
    {
        gameStateManager = new GameStateManager();
    }

    private void InitObjects()
    {
        gameStateManager.Init();
    }
}
