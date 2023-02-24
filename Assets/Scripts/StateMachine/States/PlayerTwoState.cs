using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoState : State
{
    private GameController controller;
    private GameFSM stateMachine;

    public PlayerTwoState(GameFSM passStateMachine, GameController passController)
    {
        controller = passController;
        stateMachine = passStateMachine;
    }

    public override void Enter()
    {
        Debug.Log("enter player 2 state");
    }

    public override void Exit()
    {
        Debug.Log("exit player 2 state");
    }

    public override void Tick()
    {
        if (controller.Input.isTapPressed)
        {
            stateMachine.ChangeState(stateMachine.playerOneState);
            controller.Input.isTapPressed = false;
        }

        if (controller.Input.isWinPressed)
        {
            stateMachine.ChangeState(stateMachine.playerTwoWinState);
            controller.Input.isWinPressed = false;
        }
    }
}
