using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputBroadcaster : MonoBehaviour
{
    PlayerInput playerInput;

    private InputAction testAction;
    private InputAction testWinLoseAction;


    public bool isTapPressed = false;
    public bool isWinPressed = false;
    public bool isCountingPressed = false;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        testAction = playerInput.actions.FindAction("Test");
        testWinLoseAction = playerInput.actions.FindAction("TestWinLose");
    }

    private void OnEnable()
    {

        testAction.performed += TestPressed;
        testAction.canceled += TestCancel;

        testWinLoseAction.performed += TestWinPressed;
        testWinLoseAction.canceled += TestWinCancel;
    }

    private void OnDisable()
    {
        testAction.performed -= TestPressed;
        testAction.canceled -= TestCancel;

        testWinLoseAction.performed -= TestWinPressed;
        testWinLoseAction.canceled -= TestWinCancel;
    }


    public void EndTurn()
    {
        isTapPressed = true;
    }

    public void EndGame()
    {
        isCountingPressed = true;
    }



    private void TestPressed(InputAction.CallbackContext context)
    {
        isTapPressed = true;
    }

    private void TestCancel(InputAction.CallbackContext context)
    {
        isTapPressed = false;
    }

    private void TestWinPressed(InputAction.CallbackContext context)
    {
        isWinPressed = true;

    }

    private void TestWinCancel(InputAction.CallbackContext context)
    {
        isWinPressed = false;
    }


}
