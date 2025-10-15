using UnityEngine;

public class Bullet : MonoBehaviour
{
    private StateMachine stateMachine;
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Enemy"))
        {
            stateMachine.ChangeState(new HurtState());
        }
    }
}
