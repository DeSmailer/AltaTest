using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private ProjectileMovement _projectileMovement;
    [SerializeField] private BallData _ballData;
    [SerializeField] private SizeController _sizeController;

    public BallData BallData => _ballData;

    public Action<Projectile> OnProjectileDestroy;

    private void TryDestroyObstacle()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _ballData.Radius * 2);

        int countOfObstacle = 0;

        foreach (Collider collider in colliders)
        {
            Obstacle obstacle = collider.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                countOfObstacle++;

                Debug.Log("Infect");
                obstacle.Infect();
            }
        }
        Debug.Log("countOfObstacle " + countOfObstacle);
        if (countOfObstacle > 0)
        {
            Destroy();
        }
    }

    public void Initialize(InputSystem inputSystem)
    {
        _sizeController.Initialize();
        _inputSystem = inputSystem;
        _inputSystem.OnTouchEnded += OnTouchEndedHandler;
    }

    private void OnTouchEndedHandler()
    {
        _projectileMovement.StartMove();
        _inputSystem.OnTouchEnded -= OnTouchEndedHandler;
    }

    public void Destroy()
    {
        Debug.Log("Destroy");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        TryDestroyObstacle();
    }

    private void OnDestroy()
    {
        OnProjectileDestroy?.Invoke(this);
        _inputSystem.OnTouchEnded -= OnTouchEndedHandler;
    }
}