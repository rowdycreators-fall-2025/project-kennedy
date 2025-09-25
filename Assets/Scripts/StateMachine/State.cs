using UnityEngine;

// abstract class States that acts as the blueprint for all States of any type
public abstract class State
{
    // generic type owner, in which the States will belong to
    protected StateMachine _stateMachine;

    // constructor for the class, takes a generic owner as input, assigns it to the current generic owner
    public State(StateMachine stateMachine)
    {
        this._stateMachine = stateMachine;
    }

    // called when state is entered
    public abstract void Enter();

    // called every frame
    public abstract void Update();

    // abstract function Exit, this function will be called when a new State needs to Enter and the current state needs to Exit
    public abstract void Exit();
}
