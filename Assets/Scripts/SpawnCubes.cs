using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject Cube;
    public int CubesAmount;
    void Start()
    {
        for (int i = 0; i < CubesAmount; i++)
        {
            var x = Random.Range(-49,50);
            var y = 8 + Random.Range(-3, 4);
            var z = Random.Range(-49,50);

            var newCube = Instantiate(Cube);
            newCube.transform.position = new Vector3(x,y,z);
            newCube.transform.parent = transform;

        }
    }

}
