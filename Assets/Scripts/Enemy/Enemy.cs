using UnityEngine;

// Enemy class for a game object
public class Enemy : MonoBehaviour
{
    StateMachine<Enemy> enemyStateMachine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // creates a new StateMachine for the Enemy and sets the default state
        enemyStateMachine = new StateMachine<Enemy>();
        enemyStateMachine.ChangeState(new EnemyIdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
