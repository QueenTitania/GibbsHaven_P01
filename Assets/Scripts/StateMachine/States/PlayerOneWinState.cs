using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneWinState : State
{
    private GameController controller;
    private GameFSM stateMachine;

    public PlayerOneWinState(GameFSM passStateMachine, GameController passController)
    {
        controller = passController;
        stateMachine = passStateMachine;
    }

    public override void Enter()
    {
        Debug.Log("enter player 1 win state");
    }

    public override void Exit()
    {
        Debug.Log("exit player 1 win state");
    }

    public override void Tick()
    {
        if (controller.Input.isTapPressed)
        {
            stateMachine.ChangeState(stateMachine.SetupState);
            controller.Input.isTapPressed = false;
        }

    }
}
