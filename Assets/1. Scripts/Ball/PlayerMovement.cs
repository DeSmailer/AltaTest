using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _finalPosition;

    [SerializeField] private BallData _ballData;

    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _strength;
    [SerializeField] private int _vibrato;
    [SerializeField] private float _randomness;
    [SerializeField] private bool _snapping = false;
    [SerializeField] private bool _fadeOut = true;

    public void Move()
    {
        transform.DOShakePosition(_duration, _strength, _vibrato, _randomness, _snapping, _fadeOut);
        transform.position = transform.position + new Vector3(0, _ballData.Radius / 2, 0);
        transform.DOLocalMoveZ(_finalPosition.position.z, _duration);
    }
}
