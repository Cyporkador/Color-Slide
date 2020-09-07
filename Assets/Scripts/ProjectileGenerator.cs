using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGenerator : MonoBehaviour
{
    public GameObject projectile;
    public Transform playerPos;
    private float distance = 145;
    public static float speed = 10;

    public Material red;
    public Material orange;
    public Material yellow;
    public Material green;
    public Material blue;
    public Material purple;

    private List<Material> colors = new List<Material>();
    private List<bool> fullCols = new List<bool>();
    private List<float> colTimers = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        colors.Add(red);
        colors.Add(orange);
        colors.Add(yellow);
        colors.Add(green);
        colors.Add(blue);
        colors.Add(purple);

        fullCols.Add(false);
        fullCols.Add(false);
        fullCols.Add(false);
        fullCols.Add(false);
        fullCols.Add(false);

        colTimers.Add(0f);
        colTimers.Add(0f);
        colTimers.Add(0f);
        colTimers.Add(0f);
        colTimers.Add(0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for(int k = 0; k < 5; k++)
        {
            if(fullCols[k])
            {
                colTimers[k] += Time.deltaTime;
                if (colTimers[k] > 1.5f)
                {
                    fullCols[k] = false;
                    colTimers[k] = 0f;
                }
            }
        }

        int generate = Random.Range(0, 200); // to generate or not

        if (generate < (CameraMovement.speed + 4))
        {
            int column = Random.Range(0, 5);
            int amount = Random.Range(3, 9); // length
            int color = Random.Range(0, 6);
            if (!fullCols[column])
            {
                for (int k = 0; k < amount; k++)
                {
                    GameObject prefab = Instantiate(projectile, new Vector3(-10 + 5 * column, 2, playerPos.position.z + distance - 2 * k), Quaternion.identity);
                    prefab.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
                    prefab.GetComponent<MeshRenderer>().material = colors[color];
                }
                fullCols[column] = true;
            }
            
        }
        
        
    }
}
