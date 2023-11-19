using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _delayBeforeDeath;

    public Action<Obstacle> OnDie;
    public Action<Obstacle> OnInfect;

    public void Infect()
    {
        OnInfect?.Invoke(this);
        Destroy(gameObject, _delayBeforeDeath);
    }

    private void OnDestroy()
    {
        OnDie?.Invoke(this);
    }
}
