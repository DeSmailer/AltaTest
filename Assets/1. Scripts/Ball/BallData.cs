using System;
using UnityEngine;

public class BallData : MonoBehaviour
{
    [SerializeField] private float _volume;
    [SerializeField] private float _radius;

    [SerializeField] public Action OnRadiusChange;
    [SerializeField] public Action OnVolumeChange;

    public float Volume
    {
        get { return _volume; }
        set
        {
            Debug.Log("_volume " + _volume);
            _volume = value;
            Radius = GetRadiusByFormula();
            OnVolumeChange?.Invoke();
        }
    }

    public float Radius
    {
        get { return _radius; }
        set
        {
            Debug.Log("_radius " + _radius);
            _radius = value;
            OnRadiusChange?.Invoke();
        }
    }

    public float GetVolumeByFormula()
    {
        return (4 / 3) * Mathf.PI * Radius * Radius * Radius;
    }

    public float GetRadiusByFormula()
    {
        return Mathf.Pow((3 * Volume) / (4 * Mathf.PI), 1f / 3f);
    }
}
