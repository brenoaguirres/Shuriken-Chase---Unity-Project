using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] protected State currentState;

    private void Start() {
        // needs to be changed to starting state of the creature
        TransitionToState(new RunStatePlayer());
    }

    // Inputs will be passed by input manager to this, and this will call transition to states that will do the
    // logic previously did by input manager
    private void Update() {
        currentState.Execute();

        // if certain input then
        // TransitionToState(NextState nextState);
    }

    protected void TransitionToState(State nextState) {
        currentState?.Exit();

        currentState = nextState;
        currentState.Initialize(this);
        currentState.Enter();
    }
}
