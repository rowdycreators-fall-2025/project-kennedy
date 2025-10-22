using UnityEngine;

public class Gun
{
    public float ShootDamage = 5;
    public GameObject gunModel;


    public Gun() { }

    public Gun(float shootDamage, GameObject gunModel)
    {
        this.gunModel = gunModel;
        this.ShootDamage = shootDamage;
    }
}
