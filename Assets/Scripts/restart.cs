using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class restart : MonoBehaviour
{
    public short br;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) == true) {
        Scene currentScene = SceneManager.GetActiveScene ();
        SceneManager.LoadScene(currentScene.name);
        }
    }
}
