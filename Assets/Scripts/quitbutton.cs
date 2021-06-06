using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class quitbutton : MonoBehaviour
{


    public void quit_game()
    {
        #if     UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }





}
