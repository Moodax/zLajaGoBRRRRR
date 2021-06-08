using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playbutton : MonoBehaviour
{
    public GameObject desert;
    public GameObject forest;
    public GameObject back;
    public GameObject controlls;
    public GameObject quit;
    public GameObject play;
    public GameObject icy;
    public GameObject title;
    public GameObject choose;
    public AudioSource button_pressed;
    public GameObject controlls2;

    public void selectLevel()
    {
        Debug.Log("koji kurac");
        desert.SetActive(true);
        forest.SetActive(true);
        icy.SetActive(true);

        back.SetActive(true);
        controlls.SetActive(false);
        play.SetActive(false);
        quit.SetActive(false);
        title.SetActive(false);
        choose.SetActive(true);
        controlls2.SetActive(false);

        button_pressed.Play();
    }


}