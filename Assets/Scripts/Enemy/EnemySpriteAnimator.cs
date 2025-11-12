using UnityEngine;
using UnityEngine.AI;

public class EnemySpriteAnimator : MonoBehaviour
{

    [SerializeField]
    private Transform _player;
    [SerializeField]
    private NavMeshAgent _agent;

    private Animator _animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // false if speed is 0, true otherwise
        _animator.SetBool("isWalking", !Mathf.Approximately(_agent.velocity.magnitude, 0));

        Vector3 directionToPlayer = (_player.position - transform.position);
        Vector2 flattenedDirectionToPlayer = new Vector2(directionToPlayer.x, directionToPlayer.z).normalized;

        Vector2 flattenedAgentMoveDirection = new Vector2(_agent.velocity.x, _agent.velocity.z).normalized;
        Debug.Log(flattenedAgentMoveDirection);

        float angleTo = Vector2.SignedAngle(flattenedDirectionToPlayer, flattenedAgentMoveDirection);

        Vector2 relativeDirection = Quaternion.Euler(0, 0, angleTo) * Vector2.down;

        _animator.SetFloat("relativeX", relativeDirection.x);
        _animator.SetFloat("relativeY", relativeDirection.y);
    }
}
