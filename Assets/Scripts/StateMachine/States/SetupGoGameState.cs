using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGoGameState : State
{
    private GameController controller;
    private GameFSM stateMachine;

    public SetupGoGameState(GameFSM passStateMachine, GameController passController)
    {
        controller = passController;
        stateMachine = passStateMachine;
    }

    public override void Enter()
    {
        Debug.Log("enter setup state");
    }

    public override void Tick()
    {
        stateMachine.ChangeState(stateMachine.playerOneState);
    }

    public override void Exit()
    {
        Debug.Log("exit setup state");
    }

}
