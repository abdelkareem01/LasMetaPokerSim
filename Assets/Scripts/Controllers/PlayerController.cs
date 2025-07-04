namespace Scripts.Controllers
{
    using Fusion;
    using Scripts.Core;
    using Scripts.Input;
    using Scripts.Managers;
    using UnityEngine;

    public class PlayerController : NetworkBehaviour
    {
        [Networked]
        public NetworkButtons Buttons
        {
            get; set;
        }

        private NetworkManager networkManager;

        [SerializeField] private PlayerInputHandler playerInputHandler;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform cameraPos;
        [SerializeField] private float mouseSensitivity;
        private float xMouseOffset = 0f;
        private float yMouseOffset = 0f;

        private Camera mainCam;

        private bool mouseIsVisible;
        private bool mouseIsLocked;
        private bool trackMouseMovement;

        public void Awake()
        {
            networkManager = Main.instance.networkManager;
            mainCam = Camera.main;
        }

        public override void Spawned()
        {
            if (HasInputAuthority)
            {
                networkManager.AddCallbacks(playerInputHandler);

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = mouseIsVisible = false;
                mouseIsLocked = true;
                trackMouseMovement = true;

                Debug.Log($"[PlayerController] Spawned | InputAuthority: {Object.InputAuthority} | IsLocal: {HasInputAuthority}");
            }
        }

        private void LateUpdate()
        {
            if (!HasInputAuthority || mainCam.transform == null || cameraPos == null || !trackMouseMovement) return;

            Vector2 prespectiveDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitivity;

            yMouseOffset += prespectiveDelta.x;
            xMouseOffset -= prespectiveDelta.y;

            xMouseOffset = Mathf.Clamp(xMouseOffset, -85f, 85f);

            transform.rotation = Quaternion.Euler(0, yMouseOffset, 0);

            mainCam.transform.rotation = Quaternion.Euler(xMouseOffset, yMouseOffset, 0f);

            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, cameraPos.position, 1f);
        }

        public override void FixedUpdateNetwork()
        {
            if (GetInput<PlayerInputData>(out var input) == false) return;

            var pressed = input.playerButtons.GetPressed(Buttons);
            var released = input.playerButtons.GetReleased(Buttons);

            Buttons = input.playerButtons;

            var moveAmount = default(Vector3);

            if (Buttons.IsSet(PlayerButtons.Forward)) { moveAmount.z += 1; }
            if (Buttons.IsSet(PlayerButtons.Backward)) { moveAmount.z -= 1; }

            if (Buttons.IsSet(PlayerButtons.Left)) { moveAmount.x -= 1; }
            if (Buttons.IsSet(PlayerButtons.Right)) { moveAmount.x += 1; }

            MovePlayer(moveAmount);

            if (pressed.IsSet(PlayerButtons.RequestDeal))
            {
                MainEventBus.OnRequestDeal?.Invoke(networkManager.GetPlayer());
            }

            if (pressed.IsSet(PlayerButtons.ToggleUI))
            {
                Cursor.lockState = MouseLockDecider(!mouseIsLocked);
                Cursor.visible = mouseIsVisible = !mouseIsVisible;

                mouseIsLocked = !mouseIsLocked;
                trackMouseMovement = !trackMouseMovement;
            }
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            Runner.RemoveCallbacks(playerInputHandler);
        }

        public void MovePlayer(Vector3 amount)
        {
            transform.Translate(amount * 5f * networkManager.GetDeltaTime());
        }

        private CursorLockMode MouseLockDecider(bool lockMode)
        {
            switch (lockMode)
            {
                case true:
                    return CursorLockMode.Locked;
                case false:
                    return CursorLockMode.None;
            }
        }
    }
}
