using UnityEngine;

public class BillboardEffect : MonoBehaviour
{

    public Transform lookTarget;

    public void LateUpdate()
    {
        transform.LookAt(lookTarget,Vector3.up);
        transform.Rotate(Vector3.up, 180, Space.Self);
        transform.Rotate(Vector3.right, -transform.rotation.eulerAngles.x, Space.Self);
    }
}
