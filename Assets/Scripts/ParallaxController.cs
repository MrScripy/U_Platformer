using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private new Transform camera; // main camera
    private Vector3 cameraStartPos;
    private float distance; // distance between the canera start position and its current position

    private GameObject[] backgrounds;
    private Material[] materials;
    private float[] backSpeed;
    private int backCount;

    float farthestBack;

    [Range(0.01f, 0.05f)]
    [SerializeField] private float parallaxSpeed;

    private void Start()
    {
        camera = Camera.main.transform;
        cameraStartPos = camera.position;

        backCount = transform.childCount;
        materials = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            materials[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount);
    }
    private void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++) // find the farthest background
        {
            if ((backgrounds[i].transform.position.z - camera.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - camera.position.z;
            }
        }

        for (int i = 0; i < backCount; i++) // set the speed of backgrounds
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - camera.position.z) / farthestBack;
        }
    }

    private void LateUpdate()
    {
        distance = camera.position.x - cameraStartPos.x;
        transform.position = new Vector3(camera.position.x, 0, 0);

        for (int i = 0; i < backCount; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            materials[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }

}
