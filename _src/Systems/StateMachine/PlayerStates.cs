using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : State
{

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

}

public class RunStatePlayer : PlayerStates
{
    public override void Enter()
    {

    }

    public override void Execute()
    {
        Debug.Log("Running State");
    }

    public override void Exit()
    {

    }
}

public class AttackStatePlayer : PlayerStates
{
    public override void Enter()
    {

    }

    public override void Execute()
    {
        Debug.Log("Attack State");
    }

    public override void Exit()
    {

    }

}

public class JumpStatePlayer : PlayerStates
{
    public override void Enter()
    {

    }

    public override void Execute()
    {
        Debug.Log("Jump State");
    }

    public override void Exit()
    {

    }
}

public class DuckStatePlayer : PlayerStates
{
    public override void Enter()
    {

    }

    public override void Execute()
    {
        Debug.Log("Duck State");
    }

    public override void Exit()
    {

    }
}

public class DeathStatePlayer : PlayerStates
{
    public override void Enter()
    {

    }

    public override void Execute()
    {
        Debug.Log("Death State");
    }

    public override void Exit()
    {

    }
}

public class LaneChangeStatePlayer : PlayerStates
{
    public override void Enter()
    {

    }

    public override void Execute()
    {
        Debug.Log("Lane-Changing");
    }

    public override void Exit()
    {

    }
}  