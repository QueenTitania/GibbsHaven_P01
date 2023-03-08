using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingState : State
{
    private GameController controller;
    private GameFSM stateMachine;


    private GameObject[] playerScores;

    public CountingState(GameFSM passStateMachine, GameController passController)
    {
        controller = passController;
        stateMachine = passStateMachine;
    }

    public override void Enter()
    {
        playerScores = GameObject.FindGameObjectsWithTag("Counter");
        playerScores[0].GetComponent<Counter>().counterUpdate += UpdateCounter;
        playerScores[1].GetComponent<Counter>().counterUpdate += UpdateCounter;

        Debug.Log("enter counting state");
    }

    public override void Exit()
    {
        Debug.Log("exit counting state");
    }

    public override void Tick()
    {
        //if (controller.Input.isTapPressed)
        //{
        //    stateMachine.ChangeState(stateMachine.SetupState);
        //    controller.Input.isTapPressed = false;
        //}

        if(playerScores[0].GetComponent<Counter>().doneCounting == true && playerScores[1].GetComponent<Counter>().doneCounting == true)
        {
            Debug.Log("both players done");
            CalculateWinner();
        }

    }

    private void UpdateCounter()
    {
        playerScores[0].GetComponent<Counter>().counterText.text = playerScores[0].GetComponent<Counter>().playerCount.ToString();
        playerScores[1].GetComponent<Counter>().counterText.text = playerScores[1].GetComponent<Counter>().playerCount.ToString();
    }

    private void CalculateWinner()
    {
        Debug.Log("calculating winner");
        if (playerScores[1].GetComponent<Counter>().playerCount == playerScores[0].GetComponent<Counter>().playerCount)
            stateMachine.ChangeState(stateMachine.drawState);
        else if (playerScores[0].GetComponent<Counter>().playerCount > playerScores[1].GetComponent<Counter>().playerCount)
            stateMachine.ChangeState(stateMachine.playerOneWinState);
        else if (playerScores[1].GetComponent<Counter>().playerCount > playerScores[0].GetComponent<Counter>().playerCount)
            stateMachine.ChangeState(stateMachine.playerTwoWinState);
    }
    
}
