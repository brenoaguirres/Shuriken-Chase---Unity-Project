using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected StateMachine stateMachine;

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();

    public void Initialize(StateMachine stateMachine) {
        this.stateMachine = stateMachine;
    }
}
