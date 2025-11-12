using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    PlayerCamBob camBob;
    public float health = 100;

    private void Start()
    {   
        camBob = GetComponent<PlayerCamBob>();
        ChangeState(new PlayerWalkState(this));
    }

    public void Hit(float damage)
    {
        health -= damage;
        
    }
}
