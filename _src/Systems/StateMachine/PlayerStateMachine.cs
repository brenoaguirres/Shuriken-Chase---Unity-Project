using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    private bool attack = false;
    private bool jump = false;
    private bool duck = false;
    private bool death = false;
    private bool laneChange = false;

    private void Start() {
        TransitionToState(new RunStatePlayer());
    }

    private void Update() {
        currentState.Execute();

        if (attack) {
            TransitionToState(new AttackStatePlayer());
        }
        else if (jump) {
            TransitionToState(new JumpStatePlayer());
        }    
        else if (duck) {
            TransitionToState(new DuckStatePlayer());
        }
        else if (death) {
            TransitionToState(new DeathStatePlayer());
        }
        else if (laneChange) {
            TransitionToState(new LaneChangeStatePlayer());
        }
        else {
            TransitionToState(new RunStatePlayer());
        }
    }

    public bool GetAttackState() {
        return attack;
    }

    public void StartAttackState() {
        attack = true;
    }

    public void EndAttackState() {
        attack = false;
    }

    public IEnumerator WaitAttackState() {
        // Check if this won't cause delay on attack
        yield return new WaitForSeconds(0.1f);
        EndAttackState();
    }

    public bool GetLaneChangeState() {
        return laneChange;
    }

    public void StartLaneChangeState() {
        laneChange = true;
    }

    public void EndLaneChangeState() {
        laneChange = false;
    }

    public IEnumerator WaitLaneChangeState() {
        // Check if this won't cause delay on lane change
        yield return new WaitForSeconds(0.3f);
        EndLaneChangeState();
    }

    public bool GetJumpState() {
        return jump;
    }

    public void StartJumpState() {
        jump = true;
    }

    public void EndJumpState() {
        jump = false;
    }

    public IEnumerator WaitJumpState() {
        // Check if this won't cause delay on Jump
        yield return new WaitForSeconds(0.4f);
        EndJumpState();
    }

    public bool GetDuckState() {
        return duck;
    }

    public void StartDuckState() {
        duck = true;
    }

    public void EndDuckState() {
        duck = false;
    }

    public bool GetDeathState() {
        return death;
    }

    public void StartDeathState() {
        death = true;
    }

    public void EndDeathState() {
        death = false;
    }

    public State GetCurrentState() {
        return currentState;
    }
}
