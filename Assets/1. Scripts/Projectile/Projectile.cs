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

    private void OnTouchEndedHandler()
    {
        _projectileMovement.StartMove();
        _inputSystem.OnTouchEnded -= OnTouchEndedHandler;
    }

    public void DestroyProjectile()
    {
        OnProjectileDestroy?.Invoke(this);
        _inputSystem.OnTouchEnded -= OnTouchEndedHandler;
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Obstacle obstacle = other.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            _flattener.FlattenOut(_sizeCoefficient, DestroyProjectile);
            _projectileMovement.StopMove();
            obstacle.Infect();
        }
        else
        {
            LimiterForProjectiles limiter = other.GetComponent<LimiterForProjectiles>();
            if (limiter != null)
            {
                DestroyProjectile();
            }
        }
    }
}