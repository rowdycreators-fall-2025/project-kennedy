using UnityEngine;

public class BillboardEffect : MonoBehaviour
{
    public void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0f,Camera.main.transform.rotation.eulerAngles.y, 0f);
    }
}
