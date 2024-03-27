using _Project.Runtime.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooling : SingletonBehaviour<ObstaclePooling>
{
    private List<GameObject> listedSeparateObstacles = new List<GameObject>();
    private List<GameObject> notListedSeparateObstacles = new List<GameObject>();
    private List<GameObject> listedUnifiedObstacles = new List<GameObject>();
    private List<GameObject> notListedUnifiedObstacles = new List<GameObject>();

    [SerializeField] private int cloneAmount;
    [SerializeField] private GameObject separateObstaclePrefab;
    [SerializeField] private GameObject unifiedObstaclePrefab;

    [SerializeField] private GameObject unifiedParent;
    [SerializeField] private GameObject separateParent;

    private void Start()
    {
        CloneObstacles(listedSeparateObstacles, separateObstaclePrefab, separateParent);
        CloneObstacles(listedUnifiedObstacles, unifiedObstaclePrefab, unifiedParent);
    }

    private void CloneObstacles(List<GameObject> targetList, GameObject _prefab, GameObject parent)
    {
        for (int i = 0; i < cloneAmount; i++)
        {
            GameObject obj = Instantiate(_prefab);
            targetList.Add(obj);
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(parent.transform);
        }
    }

    public void GetUnifiedObstacle(Vector3 position)
    {
        if (listedUnifiedObstacles.Count > 0)
        {
            listedUnifiedObstacles[0].transform.position = position;
            listedUnifiedObstacles[0].gameObject.SetActive(true);
            notListedUnifiedObstacles.Add(listedUnifiedObstacles[0]);
            listedUnifiedObstacles.RemoveAt(0);
        }
    }

    public void GetBackPoolTheUnifiedObstacles()
    {

        for (int i = notListedUnifiedObstacles.Count - 1; i >= 0; i--)
        {
            if (!notListedUnifiedObstacles[i].gameObject.activeSelf)
            {
                listedUnifiedObstacles.Add(notListedUnifiedObstacles[i]);
                notListedUnifiedObstacles.RemoveAt(i);
            }
        }

    }

    public void GetSeparateObstacle(Vector3 position)
    {
        if (listedSeparateObstacles.Count > 0)
        {
            listedSeparateObstacles[0].transform.position = position;
            listedSeparateObstacles[0].gameObject.SetActive(true);
            notListedSeparateObstacles.Add(listedSeparateObstacles[0]);
            listedSeparateObstacles.RemoveAt(0);
        }
    }

    public void GetBackPoolTheSeparateObstacle()
    {
        for (int i = notListedSeparateObstacles.Count - 1; i >= 0; i--)
        {
            if (!notListedSeparateObstacles[i].activeSelf)
            {
                listedSeparateObstacles.Add(notListedSeparateObstacles[i]);
                notListedSeparateObstacles.RemoveAt(i);
            }
        }

    }
}
