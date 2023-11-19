using System;
using UnityEngine;
using DG.Tweening;

public class Flattener : MonoBehaviour
{
    [SerializeField] private float _duration;

    public void FlattenOut(float sizeCoefficient, Action onEnd)
    {
        Vector3 to1 = new Vector3(
            transform.localScale.x / sizeCoefficient,
            transform.localScale.y * sizeCoefficient,
            transform.localScale.z / sizeCoefficient);

        Vector3 to2 = new Vector3(
            transform.localScale.x * sizeCoefficient,
            transform.localScale.y / sizeCoefficient,
            transform.localScale.z * sizeCoefficient);

        transform.DOScale(to1, _duration)
            //.OnComplete(() => transform.DOScale(to2, _duration))
            .OnComplete(() => onEnd?.Invoke());
    }
}
