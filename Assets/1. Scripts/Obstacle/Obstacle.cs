using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _delayBeforeDeath;
    [SerializeField] private ReasonForDestruction _reasonForDestruction = ReasonForDestruction.LoadingLevel;

    public Action<Obstacle> OnDeathByProjectile;
    public Action<Obstacle> OnDeathByLoadingLevel;
    public Action<Obstacle> OnInfect;

    public void Infect()
    {
        OnInfect?.Invoke(this);
        _reasonForDestruction = ReasonForDestruction.DeathByProjectile;
        Destroy(gameObject, _delayBeforeDeath);
    }

    private void OnDestroy()
    {
        if (_reasonForDestruction == ReasonForDestruction.DeathByProjectile)
        {
            OnDeathByProjectile?.Invoke(this);
        }
        else
        {
            OnDeathByLoadingLevel?.Invoke(this);
        }
    }
}

public enum ReasonForDestruction
{
    LoadingLevel,
    DeathByProjectile
}
