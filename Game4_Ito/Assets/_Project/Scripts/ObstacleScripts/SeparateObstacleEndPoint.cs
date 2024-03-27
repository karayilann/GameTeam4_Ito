using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeparateObstacleEndPoint : MonoBehaviour, ICollisionable
{
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
