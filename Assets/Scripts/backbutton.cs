using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backbutton : MonoBehaviour
{
    public GameObject desert;
    public GameObject forest;
    public GameObject back;
    public GameObject controlls;
    public GameObject quit;
    public GameObject play;
    public GameObject icy;

    public GameObject controll_list;
    public GameObject title;
    public GameObject choose;
    public AudioSource button_pressed;

    public void mainmenu()
    {
        desert.SetActive(false);
        forest.SetActive(false);
        icy.SetActive(false);
        back.SetActive(false);
        controlls.SetActive(true);
        play.SetActive(true);
        quit.SetActive(true);


        controll_list.SetActive(false);
        title.SetActive(true);
        choose.SetActive(false);

        button_pressed.Play();
    }



}