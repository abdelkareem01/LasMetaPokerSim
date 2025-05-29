using UnityEngine;
using UnityEngine.UI;

public class GameplayHUD : BaseWindowState
{
    public GameplayHUD(WindowStateManager manager, GameObject canvas)
        : base(manager, canvas)
    {
    }

    public override void OnEnter(BaseWindowState previousState, object data)
    {
        canvasRoot.SetActive(true);
    }

    public override void OnExit(BaseWindowState nextState, object data)
    {
        canvasRoot.SetActive(false);
    }

}
