using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawState : State
{
    private GameController controller;
    private GameFSM stateMachine;

    public DrawState(GameFSM passStateMachine, GameController passController)
    {
        controller = passController;
        stateMachine = passStateMachine;
    }

    public override void Enter()
    {
        Debug.Log("enter draw state");
        controller.drawPanel.SetActive(true);
    }

    public override void Exit()
    {
        Debug.Log("exit draw state");
        controller.drawPanel.SetActive(false);
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
