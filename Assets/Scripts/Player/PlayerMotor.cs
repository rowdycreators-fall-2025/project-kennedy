using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    //public Camera cam;
    [Header("Movement Values")]
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;
    
    /*[Header("Weapon Values")]
    public Transform gunBarrel;
    public float damage = 10f;
    public float range = 100f;

    [Range(0.1f, 10)]
    public float fireRate;*/

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(gunBarrel.position,gunBarrel.forward * range);
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input) 
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if ((isGrounded) && (playerVelocity.y < 0)) {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }

    public void Jump() 
    {    
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -1.5f * gravity);
        }
    }

    /*public void Shoot()
    {
        Debug.Log("Shooting!");

        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)) 
        {
            Debug.Log(hit.transform.name);
        }
    }*/
}
