using UnityEngine;
using UnityEngine.UI;

public class CanvasHelper : MonoBehaviour
{
    public static CanvasHelper Instance;

    [Header("Login Canvas:")]
    public GameObject login_Canvas;
    public Button login_StartBtn;
    public Button login_exitBtn;

    [Header("GameplayHUD Canvas:")]
    public GameObject gamplayHUD_Canvas;
    
    [Header("Startup Canvas:")]
    public GameObject startup_Canvas;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
}
