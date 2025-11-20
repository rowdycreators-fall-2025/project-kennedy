using Unity.VisualScripting;
using UnityEngine;

public class MeshColliderAdder : MonoBehaviour
{
    void Start()
    {
        var children = gameObject.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < children.Length; i++)
        {
            children[i].AddComponent<MeshCollider>();
        }
    }
}
