using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachine
{
    private GameController controller;

    public SetupGoGameState SetupState { get; private set; }
    public PlayerOneState playerOneState { get; private set; }
    public PlayerTwoState playerTwoState { get; private set; }
    public PlayerOneWinState playerOneWinState { get; private set; }
    public PlayerTwoWinState playerTwoWinState { get; private set; }

    private void Awake()
    {
        controller = GetComponent<GameController>();
        SetupState = new SetupGoGameState(this, controller);
        playerOneState = new PlayerOneState(this, controller);
        playerTwoState = new PlayerTwoState(this, controller);
        playerOneWinState = new PlayerOneWinState(this, controller);
        playerTwoWinState = new PlayerTwoWinState(this, controller);
    }

    private void Start()
    {
        ChangeState(SetupState);
    }

}
