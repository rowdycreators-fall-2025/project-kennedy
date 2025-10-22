using UnityEngine;

public class Shootable : MonoBehaviour
{
    public float Health = 10f;

    public virtual void Shoot(float damage)
    {
        Debug.Log($"Shootable in {gameObject.name} got shot, damage: {damage}");
    }
}
