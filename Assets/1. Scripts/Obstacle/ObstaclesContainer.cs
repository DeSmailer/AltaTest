using UnityEngine;

public class ObstaclesContainer : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclesParent;

    public void SetNewObstacles(GameObject obstaclesParent)
    {
        if (_obstaclesParent != null)
        {
            Destroy(_obstaclesParent);
        }

        _obstaclesParent = Instantiate(obstaclesParent, transform.position, Quaternion.identity, transform);
    }
}
