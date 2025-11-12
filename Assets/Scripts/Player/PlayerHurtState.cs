using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHurtState : State
{

    private Animator volumeAnimator;

    public PlayerHurtState(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("entered PlayerHurtState");
        volumeAnimator = GameObject.FindGameObjectWithTag("Global Volume").GetComponent<Animator>();

        volumeAnimator.SetTrigger("hurt");
    }

    public override void Update() 
    {
        _stateMachine.ChangeState(new PlayerWalkState(_stateMachine));
    }

    public override void Exit() 
    {
        Debug.Log("exited PlayerHurtState");
    }
}
