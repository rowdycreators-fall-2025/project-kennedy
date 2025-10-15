using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;

    public void Initialize()
    {
        //setup default State
        ChangeState(new IdleState());
        ChangeState(new AttackState());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null) 
        {
            activeState.Perform();
        }
    }
    public void ChangeState(BaseState newState) 
    {
        //check active state != null
        if (activeState != null) {
            //run cleanup on activeState
            activeState.Exit();
        }

        activeState = newState;

        if (activeState != null) 
        {
            //Setup new state
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.gun = GetComponent<Enemy>().gun;
            activeState.Enter();
        }
    }
}
