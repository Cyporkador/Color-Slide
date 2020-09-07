using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject instructions;
    public AudioSource music;
    public GameObject fadeIn;

    private bool muted;

    // Start is called before the first frame update
    void Start()
    {
        muted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!muted)
            {
                music.mute = true;
                muted = true;
            } else
            {
                music.mute = false;
                muted = false;
            }
        } 
    }

    public void viewInstructions()
    {
        instructions.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void back()
    {
        instructions.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void play()
    {
        StartCoroutine(fade());
    }

    IEnumerator fade()
    {
        fadeIn.SetActive(true);
        music.mute = true;
        muted = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game");
    }
}
