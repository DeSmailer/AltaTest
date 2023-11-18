using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private ProjectileMovement _projectileMovement;
    [SerializeField] private BallData _ballData;
    [SerializeField] private SizeController _sizeController ;

    public BallData BallData => _ballData;

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
}