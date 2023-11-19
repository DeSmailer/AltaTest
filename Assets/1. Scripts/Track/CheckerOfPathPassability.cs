using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckerOfPathPassability : MonoBehaviour
{
    [SerializeField] private List<Obstacle> _obstacles = new List<Obstacle>();

    [SerializeField] private BoxCollider myCollider;

    public Action OnNoObstacles;

    public void Initialize()
    {
        Debug.Log("Initialize");
        Check();
    }

    public void Check()
    {
        Debug.Log("Check");
        Collider[] colliders = Physics.OverlapBox(myCollider.bounds.center, myCollider.bounds.size);
        Debug.Log(myCollider.bounds.size);

        foreach (Collider collider in colliders)
        {
            Debug.Log("++");
            Obstacle obstacle = collider.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                Debug.Log("obstacle != null");
                Debug.Log("obstacle.name " + obstacle.name);
                if (!_obstacles.Contains(obstacle))
                {
                    Debug.Log("Add(obstacle)");
                    _obstacles.Add(obstacle);
                    obstacle.OnDie += OnObstacleDieHandler;
                }
            }
        }
    }

    private void OnObstacleDieHandler(Obstacle obstacle)
    {
        Debug.Log("OnObstacleDieHandler " + obstacle.name);
        //obstacle.OnDie -= OnObstacleDieHandler;
        //_obstacles.Remove(obstacle);

        ClearList();
        Check();

        Debug.Log("_obstacles.Count " + _obstacles.Count);
        if (_obstacles.Count <= 0)
        {
            OnNoObstacles?.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(myCollider.bounds.center, myCollider.bounds.size);
    }

    private void ClearList()
    {
        Debug.Log("ClearList");
        foreach (Obstacle obstacle in _obstacles)
        {
            obstacle.OnDie -= OnObstacleDieHandler;
        }

        _obstacles.Clear();
    }

    //private void OnValidate()
    //{
    //    Check();
    //}

    private void OnDestroy()
    {
        ClearList();
    }
}
