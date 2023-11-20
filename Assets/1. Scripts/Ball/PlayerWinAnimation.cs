using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PlayerWinAnimation : MonoBehaviour
{
    [SerializeField] private Transform _finalPosition;

    [SerializeField] private BallData _ballData;

    [SerializeField] private float _delay;

    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _strength;
    [SerializeField] private int _vibrato;
    [SerializeField] private float _randomness;
    [SerializeField] private bool _snapping = false;
    [SerializeField] private bool _fadeOut = true;

    public void Play()
    {
        StartCoroutine(PlayAnimation());
    }

    private IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(_delay);

        transform.DOShakePosition(_duration, _strength, _vibrato, _randomness, _snapping, _fadeOut);
        transform.position = transform.position + new Vector3(0, _ballData.Radius / _vibrato, 0);
        transform.DOLocalMoveZ(_finalPosition.position.z, _duration);
    }
}
