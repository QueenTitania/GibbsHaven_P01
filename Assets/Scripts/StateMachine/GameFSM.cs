using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachine
{
    [SerializeField] public GameObject player1Panel;
    [SerializeField] public GameObject player2Panel;

    private GameController controller;
    private TouchManager touch;

    public SetupGoGameState SetupState { get; private set; }
    public PlayerOneState playerOneState { get; private set; }
    public PlayerTwoState playerTwoState { get; private set; }
    public CountingState countingState { get; private set; }
    public PlayerOneWinState playerOneWinState { get; private set; }
    public PlayerTwoWinState playerTwoWinState { get; private set; }
    public DrawState drawState { get; private set; }

    private void Awake()
    {
        controller = GetComponent<GameController>();
        touch = GetComponent<TouchManager>();
        SetupState = new SetupGoGameState(this, controller);
        playerOneState = new PlayerOneState(this, controller, touch);
        playerTwoState = new PlayerTwoState(this, controller, touch);
        countingState = new CountingState(this, controller);
        playerOneWinState = new PlayerOneWinState(this, controller);
        playerTwoWinState = new PlayerTwoWinState(this, controller);
        drawState = new DrawState(this, controller);
    }

    private void Start()
    {
        ChangeState(SetupState);
    }

}
