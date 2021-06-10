using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    public TMPro.TMP_Text showTime;
    public TMPro.TMP_Text countdown;
    public float vrijeme=0;
    public float odbrojavanje=0;
    private bool idi = false;
    bool jednom=false;
    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        odbrojavanje=0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(idi==true && jednom==false)
        {
            car.GetComponent<CarController>().enabled = true;
            jednom=true;
        } 
        else if(idi==false)
        car.GetComponent<CarController>().enabled = false;
        
        odbrojavanje += Time.deltaTime;
        
        if (odbrojavanje >= 1 && odbrojavanje <= 2) {countdown.text = "3";
            
        }
        else if (odbrojavanje >= 2 && odbrojavanje <= 3) countdown.text = "2";
        else if (odbrojavanje >= 3 && odbrojavanje <= 4) countdown.text = "1";
        else if (odbrojavanje >= 4 && odbrojavanje <= 5) countdown.text = "GO!";
        else
        {
            countdown.text = " ";
        }

        if(odbrojavanje > 4 ) idi = true;


        if (idi==true) vrijeme += Time.deltaTime;

        showTime.text = vrijeme.ToString("#.000");
    }
}
