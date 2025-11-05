using UnityEngine;

// Adds billboard effect to any 2d sprite attached to the script, so that the 2d sprite always faces the camera
public class BillboardEffect : MonoBehaviour
{
    public void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0f,Camera.main.transform.rotation.eulerAngles.y, 0f);
    }
}
