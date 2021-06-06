using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tekst;
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
    }
    private void CheckForCollision()
    {
        Debug.Log(Physics.OverlapBox(GetComponent<Transform>().position,transform.localScale / 2,Quaternion.identity).Length);
        Debug.Log(Object.FindObjectsOfType<CheckpointSystem>().Length);
        Debug.Log(tekst.GetComponent<Text>().enabled);
        
        if(Physics.OverlapBox(GetComponent<Transform>().position,transform.localScale / 2,Quaternion.identity).Length>1)
        {
            if(Object.FindObjectsOfType<CheckpointSystem>().Length==1)
            {
            tekst.GetComponent<Text>().text="Završili ste utrku s vremenom: "+ time.GetComponent<Text>().text;
            
            car.GetComponent<CarController>().enabled = false;
            time.GetComponent<Text>().enabled=false;
            }
            finish.GetComponent<CheckpointSystem>().enabled=true;
            Destroy(gameObject);
        }
    }

}
