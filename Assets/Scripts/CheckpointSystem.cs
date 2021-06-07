using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CheckpointSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tekst;
    private float highscore;
    public GameObject time;
    public GameObject car;
    public GameObject finish;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        CheckForCollision();
        Debug.Log(Object.FindObjectsOfType<CheckpointSystem>().Length);
    }
    private void CheckForCollision()
    {        
        if(Physics.OverlapBox(GetComponent<Transform>().position,transform.localScale / 2,Quaternion.identity).Length>1)
        {
            if(Object.FindObjectsOfType<CheckpointSystem>().Length==1)
            {
                Debug.Log("JEBEMU MATER");
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;

            if(sceneName=="Forest")
            {
            if(PlayerPrefs.HasKey("hsforest"))
            {
                highscore=PlayerPrefs.GetFloat("hsforest");
            }
            else highscore=float.Parse(time.GetComponent<Text>().text);
            
            tekst.GetComponent<Text>().text="Završili ste utrku s vremenom: "+ time.GetComponent<Text>().text;
            if(highscore>float.Parse(time.GetComponent<Text>().text))
            {
                PlayerPrefs.SetFloat("hsforest",float.Parse(time.GetComponent<Text>().text));
                tekst.GetComponent<Text>().text+= "\nČestitamo! Oborili ste rekord! Stari rekord je iznosio "+ highscore;
            }
            else if(!PlayerPrefs.HasKey("hsforest"))
            {
                PlayerPrefs.SetFloat("hsforest",float.Parse(time.GetComponent<Text>().text));
                tekst.GetComponent<Text>().text+= "\nČestitamo! Prvi put ste završili stazu!";
            }

            }
            if(sceneName=="Desert")
            {
            if(PlayerPrefs.HasKey("hsdesert"))
            {
                highscore=PlayerPrefs.GetFloat("hsdesert");
            }
            else highscore=float.Parse(time.GetComponent<Text>().text);
            
            tekst.GetComponent<Text>().text="Završili ste utrku s vremenom: "+ time.GetComponent<Text>().text;
            if(highscore>float.Parse(time.GetComponent<Text>().text))
            {
                PlayerPrefs.SetFloat("hsdesert",float.Parse(time.GetComponent<Text>().text));
                tekst.GetComponent<Text>().text+= "\nČestitamo! Oborili ste rekord! Stari rekord je iznosio "+ highscore;
            }
            else if(!PlayerPrefs.HasKey("hsdesert"))
            {
                PlayerPrefs.SetFloat("hsdesert",float.Parse(time.GetComponent<Text>().text));
                tekst.GetComponent<Text>().text+= "\nČestitamo! Prvi put ste završili stazu!";
            }
            }

            if(sceneName=="Icy")
            {
            if(PlayerPrefs.HasKey("hsicy"))
            {
                highscore=PlayerPrefs.GetFloat("hsicy");
            }
            else highscore=float.Parse(time.GetComponent<Text>().text);
            
            tekst.GetComponent<Text>().text="Završili ste utrku s vremenom: "+ time.GetComponent<Text>().text;
            if(highscore>float.Parse(time.GetComponent<Text>().text))
            {
                PlayerPrefs.SetFloat("hsicy",float.Parse(time.GetComponent<Text>().text));
                tekst.GetComponent<Text>().text+= "\nČestitamo! Oborili ste rekord! Stari rekord je iznosio "+ highscore;
            }
            else if(!PlayerPrefs.HasKey("hsicy"))
            {
                PlayerPrefs.SetFloat("hsicy",float.Parse(time.GetComponent<Text>().text));
                tekst.GetComponent<Text>().text+= "\nČestitamo! Prvi put ste završili stazu!";
            }
            }
            car.GetComponent<CarController>().enabled = false;
            time.GetComponent<Text>().enabled=false;
            }
            finish.GetComponent<CheckpointSystem>().enabled=true;
            Destroy(gameObject);
        }
    }

}
