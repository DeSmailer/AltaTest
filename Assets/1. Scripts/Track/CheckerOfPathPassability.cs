using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckerOfPathPassability : MonoBehaviour
{
    [SerializeField] private List<Obstacle> _obstacles = new List<Obstacle>();

    [SerializeField] private bool _isUnlocked = false;

    public Action OnNoObstacles;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        Obstacle obstacle = other.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            if (!_obstacles.Contains(obstacle))
            {
                _obstacles.Add(obstacle);
                obstacle.OnDeathByProjectile += OnObstacleDeathByProjectileHandler;
                obstacle.OnDeathByLoadingLevel += OnObstacleDeathByLoadingLevelHandler;
            }
        }
    }

    private void OnObstacleDeathByProjectileHandler(Obstacle obstacle)
    {
        Debug.Log("OnObstacleDeathByProjectileHandler1");
        if (_isUnlocked)
        {
            Debug.Log("OnObstacleDeathByProjectileHandler2");
            if (obstacle != null)
            {
                if (_obstacles.Contains(obstacle))
                {
                    _obstacles.Remove(obstacle);
                    obstacle.OnDeathByProjectile -= OnObstacleDeathByProjectileHandler;
                    obstacle.OnDeathByLoadingLevel -= OnObstacleDeathByLoadingLevelHandler;
                }
            }

            if (_obstacles.Count <= 0)
            {
                Debug.Log("OnNoObstacles" + 0);
                OnNoObstacles?.Invoke();
            }
        }
    }

    private void OnObstacleDeathByLoadingLevelHandler(Obstacle obstacle)
    {
        Debug.Log("OnObstacleDieHandler");
        if (_isUnlocked)
        {
            Debug.Log("OnObstacleDieHandler");
            if (obstacle != null)
            {
                if (_obstacles.Contains(obstacle))
                {
                    _obstacles.Remove(obstacle);
                    obstacle.OnDeathByProjectile -= OnObstacleDeathByProjectileHandler;
                    obstacle.OnDeathByLoadingLevel -= OnObstacleDeathByLoadingLevelHandler;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        Obstacle obstacle = other.GetComponent<Obstacle>();
        OnObstacleDeathByProjectileHandler(obstacle);
    }

    public void Lock()
    {
        Debug.Log("Lock");
        _isUnlocked = false;
    }

    public void Unlock()
    {
        Debug.Log("Unlock");
        _isUnlocked = true;
    }
}
