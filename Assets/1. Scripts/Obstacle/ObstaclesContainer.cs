using System;
using UnityEngine;

public class ObstaclesContainer : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclesParent;

    public void SetNewObstacles(GameObject obstaclesParent, Action onEnd)
    {
        GameObject newObstacles = Instantiate(obstaclesParent, transform.position, Quaternion.identity, transform);

        if (_obstaclesParent != null)
        {
            Destroy(_obstaclesParent);
        }
        _obstaclesParent = newObstacles;

        onEnd?.Invoke();
    }
}
