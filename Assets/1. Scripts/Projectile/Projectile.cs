using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private ProjectileMovement _projectileMovement;
    [SerializeField] private BallData _ballData;
    [SerializeField] private SizeController _sizeController;

    [SerializeField] private float _sizeCoefficient;
    [SerializeField] private Flattener _flattener;

    public BallData BallData => _ballData;

    public Action<Projectile> OnProjectileDestroy;

    public void Initialize(InputSystem inputSystem)
    {
        _sizeController.Initialize();
        _inputSystem = inputSystem;
        _inputSystem.OnTouchEnded += OnTouchEndedHandler;
    }

    private void TryDestroyObstacle()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _ballData.Radius * _sizeCoefficient);

        int countOfObstacle = 0;

        foreach (Collider collider in colliders)
        {
            Obstacle obstacle = collider.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                countOfObstacle++;

                _projectileMovement.StopMove();
                obstacle.Infect();
            }
        }
        if (countOfObstacle > 0)
        {
            _flattener.FlattenOut(_sizeCoefficient, Destroy);
        }
    }

    private void OnTouchEndedHandler()
    {
        _projectileMovement.StartMove();
        _inputSystem.OnTouchEnded -= OnTouchEndedHandler;
    }

    public void Destroy()
    {
        Debug.Log("Destroy");
        OnProjectileDestroy?.Invoke(this);
        _inputSystem.OnTouchEnded -= OnTouchEndedHandler;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        TryDestroyObstacle();
    }
}