using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllsbutton : MonoBehaviour
{
    public GameObject desert;
    public GameObject forest;
    public GameObject back;
    public GameObject controlls;
    public GameObject quit;
    public GameObject play;
    public GameObject controll_list;
    public AudioSource button_pressed;
    public GameObject controlls2;
    public GameObject title;


    public void list_of_controls()
    {
        desert.SetActive(false);
        forest.SetActive(false);
        back.SetActive(true);
        controlls.SetActive(false);
        play.SetActive(false);
        quit.SetActive(false);

        controll_list.SetActive(true);
        controlls2.SetActive(true);
        title.SetActive(false);

        button_pressed.Play();
    }
}