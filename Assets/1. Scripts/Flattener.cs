using System;
using UnityEngine;
using DG.Tweening;

public class Flattener : MonoBehaviour
{
    [SerializeField] private float _durationHeight;
    [SerializeField] private float _durationWidth;

    [SerializeField] private bool _active = false;

    public void FlattenOut(float sizeCoefficient, Action onEnd)
    {
        if (_active)
            return;

        _active = true;

        Vector3 to1 = new Vector3(
            transform.localScale.x / sizeCoefficient,
            transform.localScale.y * sizeCoefficient,
            transform.localScale.z / sizeCoefficient);

        Vector3 to2 = new Vector3(
            transform.localScale.x * sizeCoefficient,
            transform.localScale.y / sizeCoefficient,
            transform.localScale.z * sizeCoefficient);

        transform.DOMoveY(0, _durationHeight);

        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(transform.DOScale(to1, _durationHeight));
        mySequence.Append(transform.DOScale(to2, _durationWidth));
        mySequence.AppendCallback(() => onEnd?.Invoke());
    }
}
