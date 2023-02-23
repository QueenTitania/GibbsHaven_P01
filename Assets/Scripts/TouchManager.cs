using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions.FindAction("TouchPress");
        touchPositionAction = playerInput.actions.FindAction("TouchPosition");
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
        touchPressAction.canceled += TouchDone;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
        touchPressAction.canceled -= TouchDone;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector2 position = touchPositionAction.ReadValue<Vector2>();
        player.transform.position = position;
    }

    private void TouchDone(InputAction.CallbackContext context)
    {
        Vector2 position = touchPositionAction.ReadValue<Vector2>();
        player.transform.position = position;
    }

}
