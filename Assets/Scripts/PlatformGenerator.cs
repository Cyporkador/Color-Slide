using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        // making the starting platform, 3 x 30
        for (int k = -5; k <= 145; k += 5)
        {
            for (int j = -10; j <= 10; j += 5)
            {
                float rand = Random.Range(1, 7);
                if (rand == 1)
                {
                    block.GetComponent<MeshRenderer>().material = red;
                } else if (rand == 2)
                {
                    block.GetComponent<MeshRenderer>().material = orange;
                }
                else if (rand == 3)
                {
                    block.GetComponent<MeshRenderer>().material = yellow;
                }
                else if (rand == 4)
                {
                    block.GetComponent<MeshRenderer>().material = green;
                }
                else if (rand == 5)
                {
                    block.GetComponent<MeshRenderer>().material = blue;
                }
                else if (rand == 6)
                {
                    block.GetComponent<MeshRenderer>().material = purple;
                }
                
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
            for (int j = -10; j <= 10; j += 5)
            {
                float rand = Random.Range(1, 7);
                if (rand == 1)
                {
                    block.GetComponent<MeshRenderer>().material = red;
                }
                else if (rand == 2)
                {
                    block.GetComponent<MeshRenderer>().material = orange;
                }
                else if (rand == 3)
                {
                    block.GetComponent<MeshRenderer>().material = yellow;
                }
                else if (rand == 4)
                {
                    block.GetComponent<MeshRenderer>().material = green;
                }
                else if (rand == 5)
                {
                    block.GetComponent<MeshRenderer>().material = blue;
                }
                else if (rand == 6)
                {
                    block.GetComponent<MeshRenderer>().material = purple;
                }

                Instantiate(block, new Vector3(j, 0, edgePos + 5), Quaternion.identity);
            }

            edgePos += 5;

        }
    }
}
