using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public MeshRenderer player;
    private Material playerColor;
    public AudioSource hit;

    // Update is called once per frame
    void Update()
    {
        playerColor = player.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        hit.Play();
        if (playerColor.name.Substring(0, 2) != other.GetComponent<MeshRenderer>().material.name.Substring(0, 2))
        {
            GameMenuController.gameOver = true;
        } 
    }
}
