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

    public void selectLevel()
    {
        desert.SetActive(true);
        forest.SetActive(true);
        back.SetActive(true);
        controlls.SetActive(false);
        play.SetActive(false);
        quit.SetActive(false);
    }


}
