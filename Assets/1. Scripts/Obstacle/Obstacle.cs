using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Action<Obstacle> OnDie;

    public void Infect()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        OnDie?.Invoke(this);
    }
}
