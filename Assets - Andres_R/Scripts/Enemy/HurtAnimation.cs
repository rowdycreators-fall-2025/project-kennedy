using UnityEngine;

public class ColorFlash : MonoBehaviour
{
    public Color colorA = Color.red;
    public Color colorB = Color.white;
    public float flashSpeed = 10f; // Higher = faster color switch
    public bool isFlashing = false;

    private Renderer rend;
    private float t;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // t will oscillate between 0 and 1
        t = Mathf.PingPong(Time.time * flashSpeed, 1f);

        // Lerp (blend) between the two colors
        rend.material.color = Color.Lerp(colorA, colorB, t);
    }
}
