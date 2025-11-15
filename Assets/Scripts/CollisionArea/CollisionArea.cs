using UnityEngine;
using UnityEngine.Events;

public class CollisionArea : MonoBehaviour
{

    public UnityEvent onAreaEntered;
    public UnityEvent onAreaExit;

    private Collider _collider;

    public string _tag = "";

    void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;

        //onAreaEntered.AddListener(() => Debug.Log("area entered"));
    }

    private void ifMatch(Collider other, UnityEvent uEvent)
    {
        if (other.CompareTag(_tag))
        {
            uEvent.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other) => ifMatch(other, onAreaEntered);

    private void OnTriggerExit(Collider other) => ifMatch(other, onAreaExit);
}
