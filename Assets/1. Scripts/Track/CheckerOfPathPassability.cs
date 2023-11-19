using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckerOfPathPassability : MonoBehaviour
{
    [SerializeField] private List<Obstacle> _obstacles;

    [SerializeField] private BoxCollider myCollider;

    public Action OnNoObstacles;

    public void Initialize()
    {
        Check();
    }

    private void Check()
    {
        Collider[] colliders = Physics.OverlapBox(myCollider.bounds.center, myCollider.bounds.size);

        foreach (Collider collider in colliders)
        {
            Obstacle obstacle = collider.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                if (!_obstacles.Contains(obstacle))
                {
                    _obstacles.Add(obstacle);
                    obstacle.OnDie += OnObstacleDieHandler;
                }
            }
        }
    }

    private void OnObstacleDieHandler(Obstacle obstacle)
    {
        obstacle.OnDie -= OnObstacleDieHandler;
        _obstacles.Remove(obstacle);

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

    private void OnValidate()
    {
        Check();
    }

    private void OnDestroy()
    {
        foreach (Obstacle obstacle in _obstacles)
        {
            obstacle.OnDie -= OnObstacleDieHandler;
        }
        _obstacles.Clear();
    }
}
