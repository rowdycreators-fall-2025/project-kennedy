using UnityEngine;

// abstract class States that acts as the blueprint for all States of any type
public abstract class State<T>
{
    // generic type owner
    T owner;

    // constructor for the class, takes a generic owner as input, assigns it to the current generic owner
    public State(T owner)
    {
        this.owner = owner;
    }

    // abstract function Enter, this function will be called when a State first enters
    public abstract void Enter();

    // abstract function Update, this function will be called every frame and will contain the actual logic of the current State
    public abstract void Update();

    // abstract function Exit, this function will be called when a new State needs to Enter and the current state needs to Exit
    public abstract void Exit();
}
