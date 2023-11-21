using UnityEngine;
using UnityEngine.UI;

public class PlayerHPView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private BallData _ballData;
    [SerializeField] private Slider _slider ;

    private float _maxDifference;

    private void Start()
    {
        _ballData.OnVolumeChange += Display;
    }

    public void Initialize()
    {
        _maxDifference = _ballData.Volume - _player.MinimumCriticalVolume;
        Display();
    }

    private void Display()
    {
        float currentDifference = _ballData.Volume - _player.MinimumCriticalVolume;
        float result = currentDifference / _maxDifference;
        _slider.value = result;
    }

    private void OnDestroy()
    {
        _ballData.OnVolumeChange -= Display;
    }
}
