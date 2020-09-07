using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator2 : MonoBehaviour
{
    public Transform playerPos;
    public GameObject block; // prefab
    private float edgePos; // where the edge is (z position)
    private float distance; // distance between edge and player

    public Material red;
    public Material orange;
    public Material yellow;
    public Material green;
    public Material blue;
    public Material purple;

    private List<Material> colors = new List<Material>();

    // Start is called before the first frame update
    void Start()
    {
        colors.Add(red);
        colors.Add(orange);
        colors.Add(yellow);
        colors.Add(green);
        colors.Add(blue);
        colors.Add(purple);

        // making the starting platform, 3 x 30
        for (int k = -5; k <= 145; k += 5)
        {

            for (int r = 0; r < 6; r++)
            {
                int index = Random.Range(0, 6);
                Material temp = colors[index];
                colors[index] = colors[r];
                colors[r] = temp;
            }

            for (int j = -10; j <= 10; j += 5)
            {
                block.GetComponent<MeshRenderer>().material = colors[j / 5 + 2];
                Instantiate(block, new Vector3(j, 0, k), Quaternion.identity);
            }
        }

        edgePos = 145f;
        distance = 145f;

    }

    // Update is called once per frame
    void Update()
    {
        if (edgePos - playerPos.position.z < distance)
        {
            for (int r = 0; r < 6; r++)
            {
                int index = Random.Range(0, 6);
                Material temp = colors[index];
                colors[index] = colors[r];
                colors[r] = temp;
            }

            for (int j = -10; j <= 10; j += 5)
            {
                block.GetComponent<MeshRenderer>().material = colors[j / 5 + 2];
                Instantiate(block, new Vector3(j, 0, edgePos + 5), Quaternion.identity);
            }

            edgePos += 5;

        }
    }
}
