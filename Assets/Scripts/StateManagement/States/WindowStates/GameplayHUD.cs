namespace Scripts.StateManagement.States.WindowStates
{
    using Scripts.Core;
    using Scripts.StateManagement.Core;
    using Scripts.StateManagement.StateManagers;
    using UnityEngine;
    using UnityEngine.UI;

    public class GameplayHUD : BaseWindowState
    {

        private Slider lightSlider;
        private Light pointLight;

        public GameplayHUD(WindowStateManager manager, GameObject canvas)
            : base(manager, canvas)
        {
            lightSlider = CanvasHelper.Instance.gamplayHUD_lightSlider;
            pointLight = Main.instance.pointLight;
        }

        public override void OnEnter(BaseWindowState previousState, object data)
        {
            canvasRoot.SetActive(true);
            lightSlider.onValueChanged.AddListener(ChangeLightIntensity);
        }

        public override void OnExit(BaseWindowState nextState, object data)
        {
            canvasRoot.SetActive(false);
        }

        private void ChangeLightIntensity(float value)
        {
            pointLight.intensity = value * 10;
        }
    }
}