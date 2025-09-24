using UnityEngine;

public class EnemyIdleState: State<Enemy>
{
    // function Enter is called when the State first enters
    public void Enter()
    {
        // message that states the State has entered (for debugging purposes)
        Debug.Log("Enemy has entered the Idle State");
    }

    public void Update()
    {

    }

    // function Exit is called when the State leaves
    public void Exit()
    {
        // message that state the State has been exited (for debugging purposes)
        Debug.Log("Enemy has exited the Idle State");

    }
}
