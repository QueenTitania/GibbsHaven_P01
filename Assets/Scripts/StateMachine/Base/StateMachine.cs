using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State CurrentState { get; private set; }
    private bool inTransition = false;

    private State previousState;

    public void ChangeState(State newState)
    {
        if(CurrentState == newState || inTransition)
        {
            Debug.Log("Cannot change to state " + newState.ToString());
            return;
        }

        InitiateStateChange(newState);
    }

    public void RevertState()
    {
        if(previousState != null)
            InitiateStateChange(previousState);
    }

    public void InitiateStateChange(State targetState)
    {
        if(CurrentState != targetState && !inTransition)
        {
            Transition(targetState);
        }
    }

    void Transition(State newState)
    {
        inTransition = true;
        CurrentState?.Exit();
        previousState = CurrentState;
        CurrentState = newState;
        CurrentState?.Enter();
        inTransition = false;
    }

    private void Update()
    {
        if(CurrentState != null && !inTransition)
        {
            CurrentState.Tick();
        }
    }

}
