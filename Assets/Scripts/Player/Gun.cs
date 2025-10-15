using UnityEngine;

public class Gun : MonoBehaviour
{
    private GameObject enemy;
    
    public Camera cam;
    public bool hitEnemy;

    [Header("Weapon Values")]
    public Transform gunBarrel;
    public float damage = 10f;
    public float range = 100f;

    [Range(0.1f, 10)]
    public float fireRate;

    private void Start()
    {
        hitEnemy = false;
        enemy = GameObject.FindGameObjectWithTag("EnemyBody");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        Debug.Log("Shooting!");

        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.gameObject == enemy) 
            {
                hitEnemy = true;
            }
        }
    }
}
