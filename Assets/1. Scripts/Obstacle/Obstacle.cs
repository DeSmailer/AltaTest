using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Action<Obstacle> OnDie;

    private void OnDestroy()
    {
        OnDie?.Invoke(this);
    }
}
