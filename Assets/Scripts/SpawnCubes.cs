using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    [SerializeField] private GameObject a;
    public int cubesamt;
    void Start()
    {
        for (int i = 0; i < cubesamt; i++)
        {
            var x = Random.Range(-49,50);
            var z = Random.Range(-49,50);

            var s = Instantiate(a);
            s.transform.position = new Vector3(x,8 + Random.Range(-3,4),z);
            s.transform.parent = transform;

        }
    }

}
