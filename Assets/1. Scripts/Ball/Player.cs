using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SizeController _sizeController;
    [SerializeField] private BallData _ballData;
    //[SerializeField] private CheckerOfPathPassability _checkerOfPathPassability  ;

    [SerializeField] private float _minimumCriticalVolume;

    public Action OnInitialize;
    public Action OnDeath;

    private void Start()
    {
        _ballData.OnVolumeChange += OnVolumeChangeHandler;
        //_checkerOfPathPassability.OnNoObstacles += OnVolumeChangeHandler;
    }

    public void Initialize(float minimumCriticalVolume)
    {
        _minimumCriticalVolume = minimumCriticalVolume;
        _sizeController.Initialize();
        OnInitialize?.Invoke();
    }

    private void OnVolumeChangeHandler()
    {
        if (_ballData.Volume <= _minimumCriticalVolume)
        {
            OnDeath?.Invoke();
        }
    }

    private void OnDestroy()
    {
        _ballData.OnVolumeChange -= OnVolumeChangeHandler;
    }
}
