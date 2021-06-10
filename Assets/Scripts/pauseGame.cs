using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseGame : MonoBehaviour
{
    public GameObject pauseUI;
    public AudioSource music;
    public AudioSource countdown;
    public GameObject text;
    public GameObject car;
    public static bool if_paused = false;
    float odbrojavanje = 0;

    private void Start()
    {  
        car=GameObject.Find("Car");
        resume();
        countdown.Play();
    }



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (if_paused)
            resume();
            else pause();
            
        }
        odbrojavanje += Time.deltaTime;

    }

    public void resume()
    {
        car.GetComponent<AudioSource>().enabled=true;
        pauseUI.SetActive(false);
        if_paused = false;
        Time.timeScale = 1f;
        music.Pause();
       if(odbrojavanje<5) countdown.Play();
        text.SetActive(true);
    }
    void pause()
    {
        car.GetComponent<AudioSource>().enabled=false;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        if_paused = true;
        if (odbrojavanje > 5) music.Play();
        countdown.Pause();
        text.SetActive(false);
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }



}
