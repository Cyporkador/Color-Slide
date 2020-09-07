using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHandler : MonoBehaviour
{

    Ray ray;
    public MeshRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray(transform.position, Vector3.down);
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            mr.material = hit.collider.gameObject.GetComponent<MeshRenderer>().material;
        }
    }

}
