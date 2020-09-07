using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public static int score = 0;
    public static int highscore = 0;

    public MeshRenderer player;
    private Material playerColor;

    public TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        highscore = PlayerPrefs.GetInt("Highscore");
        playerColor = player.material;
        text.text = "Score : " + (score + "");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerColor.name.Substring(0, 2) == other.GetComponent<MeshRenderer>().material.name.Substring(0, 2))
        {
            score += 10;
        }
    }
}
