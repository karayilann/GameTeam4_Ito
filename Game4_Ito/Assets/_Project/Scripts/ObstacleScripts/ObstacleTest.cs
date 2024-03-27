using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTest : MonoBehaviour
{

    //[SerializeField] private GameObject seperateObstacle;

    [SerializeField] private bool myBool;

    [SerializeField] private bool setSetActive;
    [SerializeField] private GameObject parent;

    [SerializeField] private bool getBackBool;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (myBool)
        {
            float randomZ = UnityEngine.Random.Range(-13, 13);

            Vector3 obstaclePosition = new Vector3(0, 2, randomZ);
            ObstaclePooling.Instance.GetUnifiedObstacle(obstaclePosition);
            myBool = false;
        }

        if (setSetActive)
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                parent.transform.GetChild(i).gameObject.SetActive(false);
            }


            setSetActive = false;
        }


        if (getBackBool)
        {
            ObstaclePooling.Instance.GetBackPoolTheUnifiedObstacles();
            getBackBool = false;
        }
    }

    //void SeperateObject()
    //{
    //    //float randomY = UnityEngine.Random.Range(1.5f, 3.5f);
    //    float randomZ = UnityEngine.Random.Range(-13, 13);

    //    Vector3 obstaclePosition = new Vector3(0, seperateObstacle.transform.position.y, randomZ);

    //    seperateObstacle.SetActive(false);
    //    seperateObstacle.transform.position = obstaclePosition;
    //    seperateObstacle.SetActive(true);
    //}
}
