using UnityEngine;

public class EnemyIdleState : State<Enemy>
{

    // constructer for EnemyIdleState, takes a type Enemy as a parameter, and sets the Enemy type as the owner of the base class (State)
    public EnemyIdleState(Enemy enemy) : base(enemy) { }


    // function Enter is called when the State first enters
    public void Enter()
    {
        // message that states the State has entered (for debugging purposes)
        Debug.Log("Enemy has entered the Idle State");
    }

    // Update function that contains the actual logic of the State, called every frame
    public void Update()
    {
        // NOTE: temporary logic for the Idle State
        // will switch do the Chase State if up arrow key is pressed
        if(Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
          
        }
    }

    // function Exit is called when the State leaves
    public void Exit()
    {
        // message that state the State has been exited (for debugging purposes)
        Debug.Log("Enemy has exited the Idle State");

    }
}
