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

    public GameObject w;
    public GameObject a;
    public GameObject s;
    public GameObject d;
    public GameObject shift;


    public void list_of_controls()
    {
        desert.SetActive(false);
        forest.SetActive(false);
        back.SetActive(true);
        controlls.SetActive(false);
        play.SetActive(false);
        quit.SetActive(false);

        w.SetActive(true);
        a.SetActive(true);
        s.SetActive(true);
        d.SetActive(true);
        shift.SetActive(true);

    }
}
