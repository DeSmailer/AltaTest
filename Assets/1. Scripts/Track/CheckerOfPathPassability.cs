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
        if (_isUnlocked)
        {
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
                OnNoObstacles?.Invoke();
            }
        }
    }

    private void OnObstacleDeathByLoadingLevelHandler(Obstacle obstacle)
    {
        if (_isUnlocked)
        {
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
        Obstacle obstacle = other.GetComponent<Obstacle>();
        OnObstacleDeathByProjectileHandler(obstacle);
    }

    public void Lock()
    {
        _isUnlocked = false;
    }

    public void Unlock()
    {
        _isUnlocked = true;
    }
}
