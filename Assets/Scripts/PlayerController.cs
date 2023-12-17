using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;

    private InputAction touchClickAction;

    private void Start()
    {
        // Find the input action for touch click on the Oculus Go controller touchpad
        touchClickAction = new InputAction("OculusGo/TouchClick", InputActionType.Button, "<XRController>{RightHand}/primaryButton");
        touchClickAction.Enable();
        touchClickAction.performed += OnTouchClickPerformed;
    }

    private void Update()
    {
        // ...
    }

    private void OnTouchClickPerformed(InputAction.CallbackContext context)
    {
        MoveForward();
    }

    private void MoveForward()
    {
        Vector3 forward = transform.forward;
        forward.y = 0f; // Remove vertical component for movement on the XZ plane
        transform.position += forward.normalized * speed * Time.deltaTime;
    }
}