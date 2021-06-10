using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHighscore : MonoBehaviour
{
    public TMPro.TMP_Text Forest;
    public TMPro.TMP_Text Desert;
    public TMPro.TMP_Text Icy;
   void Start()
    {
       
    }
    public void show()
    {
         if(PlayerPrefs.HasKey("hsforest"))
        {
            Forest.text=PlayerPrefs.GetFloat("hsforest").ToString("#.000");
        }
        else Forest.text="NO HIGHSCORE";
        if(PlayerPrefs.HasKey("hsdesert"))
        {
            Desert.text=PlayerPrefs.GetFloat("hsdesert").ToString("#.000");
        }
        else Desert.text="NO HIGHSCORE";
        if(PlayerPrefs.HasKey("hsicy"))
        {
            Icy.text=PlayerPrefs.GetFloat("hsicy").ToString("#.000");
        }
        else Icy.text="NO HIGHSCORE";
    }
}
