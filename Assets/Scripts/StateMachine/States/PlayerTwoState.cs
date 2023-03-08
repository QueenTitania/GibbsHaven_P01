using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoState : State
{
    private GameController controller;
    private GameFSM stateMachine;
    private TouchManager touchManager;

    public PlayerTwoState(GameFSM passStateMachine, GameController passController, TouchManager passTouch)
    {
        controller = passController;
        stateMachine = passStateMachine;
        touchManager = passTouch;
    }

    public override void Enter()
    {
        stateMachine.player2Panel.SetActive(true);
        touchManager.player = touchManager.player2Cursor;
        Debug.Log("enter player 2 state");
    }

    public override void Exit()
    {
        stateMachine.player2Panel.SetActive(false);
        Debug.Log("exit player 2 state");
    }

    public override void Tick()
    {
        if (controller.Input.isTapPressed)
        {
            stateMachine.ChangeState(stateMachine.playerOneState);
            controller.Input.isTapPressed = false;
        }

        if (controller.Input.isCountingPressed)
        {
            stateMachine.ChangeState(stateMachine.countingState);
            controller.Input.isWinPressed = false;
        }
    }
}
