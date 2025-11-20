using UnityEngine;

public class Gun : MonoBehaviour
{
    private GameObject enemy;
    public Camera cam;
    public bool hitEnemy;

    [Header("Gun Properties")]
    public float damage = 10f;
    public float range = 100f;

    [Range(0.1f, 10f)]
    public float fireRate;
    public GameObject gunModel;

    private void Start()
    {
        hitEnemy = false;
        enemy = GameObject.FindGameObjectWithTag("EnemyBody");
    }

    void Update()
    {
        
    }

    public void Shoot()
    {
        Debug.Log("Shooting!");

        RaycastHit hit;

        Debug.Log(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range));
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            if (hit.transform.gameObject == enemy)
            {
                hitEnemy = true;
                Debug.Log("Enemy Hit!");
            }
        }
    }

    public Gun(float damage, GameObject gunModel)
    {
        //this.gunModel = gunModel;
        //this.damage = damage;
    }
}
