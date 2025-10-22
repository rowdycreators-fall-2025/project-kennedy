using System;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    public float Health = 10f;

    public delegate void Shot(float health, float damage);
    public event Shot onShot;

    public delegate void Killed();
    public event Killed onKilled;


    public virtual void Shoot(float damage)
    {
        Debug.Log($"Shootable in {gameObject.name} got shot, damage: {damage}");
        Health -= damage;
        onShot?.Invoke(Health, damage);
        if (Health <= 0) onKilled?.Invoke();

    }

}
