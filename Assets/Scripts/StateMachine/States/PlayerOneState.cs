using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneState : State
{
    private GameController controller;
    private GameFSM stateMachine;
    private TouchManager touchManager;
    

    public PlayerOneState(GameFSM passStateMachine, GameController passController, TouchManager passTouch)
    {
        controller = passController;
        stateMachine = passStateMachine;
        touchManager = passTouch;
    }

    public override void Enter()
    {
        stateMachine.player1Panel.SetActive(true);
        touchManager.player = touchManager.player1Cursor;
        Debug.Log("enter player 1 state");
    }

    public override void Exit()
    {
        stateMachine.player1Panel.SetActive(false);
        Debug.Log("exit player 1 state");
    }

    public override void Tick()
    {
        if (controller.Input.isTapPressed)
        {
            stateMachine.ChangeState(stateMachine.playerTwoState);
            controller.Input.isTapPressed = false;
        }

        if (controller.Input.isCountingPressed)
        {
            stateMachine.ChangeState(stateMachine.countingState);
            controller.Input.isWinPressed = false;
        }

    }
}
