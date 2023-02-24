using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneState : State
{
    private GameController controller;
    private GameFSM stateMachine;

    public PlayerOneState(GameFSM passStateMachine, GameController passController)
    {
        controller = passController;
        stateMachine = passStateMachine;
    }

    public override void Enter()
    {
        Debug.Log("enter player 1 state");
    }

    public override void Exit()
    {
        Debug.Log("exit player 1 state");
    }

    public override void Tick()
    {
        if (controller.Input.isTapPressed)
        {
            stateMachine.ChangeState(stateMachine.playerTwoState);
            controller.Input.isTapPressed = false;
        }

        if (controller.Input.isWinPressed)
        {
            stateMachine.ChangeState(stateMachine.playerOneWinState);
            controller.Input.isWinPressed = false;
        }

    }
}
