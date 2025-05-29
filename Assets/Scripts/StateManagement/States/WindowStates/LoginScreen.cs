using UnityEngine;
using UnityEngine.UI;

public class LoginScreen : BaseWindowState
{
    private Button startBtn;
    private Button exitBtn;

    public LoginScreen(WindowStateManager manager, GameObject canvas)
        : base(manager, canvas)
    {
        startBtn = CanvasHelper.Instance.login_StartBtn;
        exitBtn = CanvasHelper.Instance.login_exitBtn;
    }

    public override void OnEnter(BaseWindowState previousState, object data)
    {
        canvasRoot.SetActive(true);
        startBtn.onClick.AddListener(OnResumeClicked);
        exitBtn.onClick.AddListener(OnQuitClicked);
    }

    public override void OnExit(BaseWindowState nextState, object data)
    {
        startBtn.onClick.RemoveListener(OnResumeClicked);
        exitBtn.onClick.RemoveListener(OnQuitClicked);
        canvasRoot.SetActive(false);
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
