using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFunctionality : MonoBehaviour
{
    public float fallDistance = -10.0f;
    public bool earthIsFallen;
    public GameObject earth;

    public float gameTime = 0.0f;
    public Text timeText;

    void Start()
    {
        earthIsFallen = false;
    }

    void Update()
    {
        if(earth.transform.position.y <= fallDistance){
            earthIsFallen = true;
        }

        if(!earthIsFallen){
            gameTime += Time.deltaTime;
            //update text here
            timeText.text = gameTime.ToString("00:00");
        }
        else{
            // freeze game here
            timeText.text = gameTime.ToString("00:00") + "\nEARTH HAS FALLEN";
        }
    }
}
