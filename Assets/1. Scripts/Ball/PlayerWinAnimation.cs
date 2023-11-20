using UnityEngine;
using DG.Tweening;
using System.Collections;
using System;

public class PlayerWinAnimation : MonoBehaviour
{
    [SerializeField] private Transform _finalPosition;

    [SerializeField] private BallData _ballData;

    [SerializeField] private float _delay;

    [SerializeField] private float _duration;

    [SerializeField] private float _strength;
    [SerializeField] private int _numJumps;
    [SerializeField] private bool _snapping = false;

    public void Play(Action onEnd)
    {
        StartCoroutine(PlayAnimation(onEnd));
    }

    private IEnumerator PlayAnimation(Action onEnd)
    {
        yield return new WaitForSeconds(_delay);

        transform.DOJump(_finalPosition.position, _strength, _numJumps, _duration, _snapping);
        transform.position = transform.position + new Vector3(0, _ballData.Radius / _numJumps, 0);
        transform.DOLocalMoveZ(_finalPosition.position.z, _duration).OnComplete(() => onEnd?.Invoke()); ;
    }
}
