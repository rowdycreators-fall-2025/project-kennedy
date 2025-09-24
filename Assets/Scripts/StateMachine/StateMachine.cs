using UnityEngine;

// State Machine class, this class will contain the logic needed for States to change
public class StateMachine<T> : MonoBehaviour
{
    // declare the currentState variable of type State<T> and include getters and setters
    public State<T> currentState {  get; private set; }

    // the ChangeState function Exits the current State and Enters the new State given by the parameter
    public void ChangeState(State<T> newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        currentState.Update();
    }
}
