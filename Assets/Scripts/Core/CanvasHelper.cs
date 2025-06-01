namespace Scripts.Core
{
    using UnityEngine;
    using UnityEngine.UI;

    public class CanvasHelper : MonoBehaviour
    {
        public static CanvasHelper Instance;

        [Header("Home Canvas:")]
        public GameObject home_Canvas;
        public Button home_StartBtn;
        public Button home_exitBtn;

        [Header("GameplayHUD Canvas:")]
        public GameObject gamplayHUD_Canvas;
        public Slider gamplayHUD_lightSlider;

        [Header("Startup Canvas:")]
        public GameObject startup_Canvas;
        public GameObject startup_Loadingtxt;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
