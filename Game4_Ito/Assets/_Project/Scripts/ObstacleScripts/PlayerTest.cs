using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTest : MonoBehaviour
{


    private void Awake()
    {
        this.GetComponent<Renderer>().material.color = Color.red;

    }



    private void OnTriggerEnter(Collider other)
    {


        var a = other.GetComponent<IObstacle>();

        var b = other.GetComponent<ICollisionable>();

        if (a != null)
        {
            if (this.GetComponent<Renderer>().material.color == a.GetObstacleColor())
            {
                Debug.Log("Renkler Aynı");
                
                
                

            }
            else
            {
                Debug.Log("Renkler Farklı");
            }

            a = null;
        }

        if (b != null)
        {
            b.OnTriggerEvent();
            b = null;
        }
    }
}
