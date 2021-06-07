using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class quitbutton : MonoBehaviour
{
    public AudioSource button_pressed;


    public void quit_game()
    {
        button_pressed.Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }





}
