using UnityEngine;
using UnityEngine.AI;

public class EnemySpriteAnimator : MonoBehaviour
{

    [SerializeField]
    private Transform _player;

    private Animator _animator;

    private Vector3 previousPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // false if speed is 0, true otherwise
        _animator.SetBool("isWalking", !Mathf.Approximately(flattenedDeltaPosition().magnitude, 0));

        Vector3 directionToPlayer = (_player.position - transform.position);

        // represent the directions as Vector2's since x and z is all we need.
        Vector2 flattenedDirectionToPlayer = new Vector2(directionToPlayer.x, directionToPlayer.z).normalized;

        // get the angle between the two unit vectors
        float angleTo = Vector2.SignedAngle(flattenedDirectionToPlayer, flattenedDeltaPosition().normalized);

        // rotates the default Vector2.down by the angle.
        // relative direction being "Vector2.down" means the enemy is walking straight for the target.
        Vector2 relativeDirection = Quaternion.Euler(0, 0, angleTo) * Vector2.down;

        _animator.SetFloat("relativeX", relativeDirection.x);
        _animator.SetFloat("relativeY", relativeDirection.y);

        previousPosition = transform.position;
    }

    private Vector2 flattenedDeltaPosition()
    {
        Vector3 deltaPosition = transform.position - previousPosition;
        return new Vector2(deltaPosition.x, deltaPosition.z);
    }
}
