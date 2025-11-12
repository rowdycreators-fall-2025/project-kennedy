using UnityEngine;
using UnityEngine.Events;

public class CollisionArea : MonoBehaviour
{

    public UnityEvent onAreaEntered;
    public UnityEvent onAreaExit;

    private Collider _collider;

    void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;

        //onAreaEntered.AddListener(() => Debug.Log("area entered"));
    }

    private void OnTriggerEnter(Collider other) => onAreaEntered.Invoke();

    private void OnTriggerExit(Collider other) => onAreaExit.Invoke();
}
