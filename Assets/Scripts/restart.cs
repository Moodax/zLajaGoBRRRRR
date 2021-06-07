using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class restart : MonoBehaviour
{
    public short br;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) == true) resetLevel();
    }

    void resetLevel()
    {
        if (br == 1) UnityEngine.SceneManagement.SceneManager.LoadScene("forest");
        if (br == 2) UnityEngine.SceneManagement.SceneManager.LoadScene("desert");
        if (br == 3) UnityEngine.SceneManagement.SceneManager.LoadScene("icy");
    }

}
