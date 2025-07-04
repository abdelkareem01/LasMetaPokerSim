namespace Scripts.StateManagement.States.WindowStates
{
    using Scripts.Core;
    using Scripts.StateManagement.Core;
    using Scripts.StateManagement.StateManagers;
    using UnityEngine;
    using UnityEngine.UI;

    public class HomeScreen : BaseWindowState
    {
        private Button startBtn;
        private Button exitBtn;

        public HomeScreen(WindowStateManager manager, GameObject canvas)
            : base(manager, canvas)
        {
            startBtn = CanvasHelper.Instance.home_StartBtn;
            exitBtn = CanvasHelper.Instance.home_exitBtn;
        }

        public override void OnEnter(BaseWindowState previousState, object data)
        {
            canvasRoot.SetActive(true);
            startBtn.onClick.AddListener(OnResumeClicked);
            exitBtn.onClick.AddListener(OnQuitClicked);
            if (!Main.instance.networkManager.IsSceneAuthority()) StateManager.ChangeState(WindowStateType.GameplayHUD);
        }

        public override void OnExit(BaseWindowState nextState, object data)
        {
            canvasRoot.SetActive(false);
            startBtn.onClick.RemoveListener(OnResumeClicked);
            exitBtn.onClick.RemoveListener(OnQuitClicked);
        }

        private void OnResumeClicked()
        {
            Main.instance.gameStateManager.ChangeState(GameStateType.Gameplay);
            StateManager.ChangeState(WindowStateType.GameplayHUD);
        }

        private void OnQuitClicked()
        {
            Application.Quit();
        }
    }
}
