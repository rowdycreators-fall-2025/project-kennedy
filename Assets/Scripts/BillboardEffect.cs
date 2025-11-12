using UnityEngine;

public class BillboardEffect : MonoBehaviour
{

    public Transform lookTarget;

    public void LateUpdate()
    {
        // target position, but at this gameobject's y level
        Vector3 targetLookPosition = new Vector3(lookTarget.position.x, transform.position.y, lookTarget.position.z);

        // look at target position, then flip 180 (unity's sprite renderer is weird)
        transform.LookAt(targetLookPosition, Vector3.up);
        transform.Rotate(Vector3.up, 180, Space.Self);
    }
}
