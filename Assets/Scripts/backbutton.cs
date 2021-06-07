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

    public GameObject w;
    public GameObject a;
    public GameObject s;
    public GameObject d;
    public GameObject shift;

    public void mainmenu()
    {
        desert.SetActive(false);
        forest.SetActive(false);
        icy.SetActive(false);
        back.SetActive(false);
        controlls.SetActive(true);
        play.SetActive(true);
        quit.SetActive(true);

        w.SetActive(false);
        a.SetActive(false);
        s.SetActive(false);
        d.SetActive(false);
        shift.SetActive(false);
    }



}
