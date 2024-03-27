using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleCollision : MonoBehaviour,ICollisionable,IObstacle
{
    Renderer renderer;
    
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    

    public Color GetObstacleColor()
    {
        
        return renderer.material.color;
        
    }

    public void OnTriggerEvent()
    {
        StartCoroutine(WaitForSetActive());
    }

    IEnumerator WaitForSetActive()
    {
        
        yield return new WaitForSeconds(3f);
        this.transform.parent.gameObject.SetActive(false);
    }


    
}
