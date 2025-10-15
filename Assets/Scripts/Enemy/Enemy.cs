using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private GameObject player;
    public Gun gun;

    [SerializeField]
    private string currentState;

    public float health = 50f;
    
    [Header("SightValues")]
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        stateMachine.Initialize();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    {
        if (player != null) 
        {
            //is the player close enough to be seen?
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance) 
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                
                if ((angleToPlayer >= -fieldOfView) && (angleToPlayer <= fieldOfView)) { 
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player) 
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                            
                        }
                    }
                    
                }
            }
        }
        return false;
    }

    public void Die() 
    {
        Destroy(gameObject);
    }
}
