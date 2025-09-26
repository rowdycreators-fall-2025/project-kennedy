using UnityEngine;

// Enemy class for a game object
public class Enemy : MonoBehaviour
{
    public StateMachine enemyStateMachine { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // creates a new StateMachine for the Enemy and sets the default state
        enemyStateMachine = new StateMachine();
        enemyStateMachine.ChangeState(new EnemyIdleState(enemyStateMachine));
    }

    // Update is called once per frame
    void Update()
    {
        // call the Update function of the current state every frame
        enemyStateMachine.currentState?.Update();
    }
}
