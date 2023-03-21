using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeff;
    [SerializeField] private bool disableVerticalParallax;
    private Vector3 previousPosition;
    private int layersAmount;

    void Start()
    {
        layersAmount = coeff.Length;
        previousPosition = transform.position;
    }

    void Update()
    {
        var delta = transform.position - previousPosition;
        if (disableVerticalParallax)
        {
            delta.y = 0;
        }
        previousPosition = transform.position;
        for (int i = 0; i < layersAmount; i++)
        {
            layers[i].position = transform.position * coeff[i];
        }

    }
}
