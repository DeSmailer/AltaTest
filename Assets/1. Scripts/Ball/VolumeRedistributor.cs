using System.Collections;
using UnityEngine;

public class VolumeRedistributor : MonoBehaviour
{
    [SerializeField] private InputSystem inputSystem;

    [SerializeField] private BallData _playerData;
    [SerializeField] private BallData _projectileData;

    [SerializeField] private float _power;
    [SerializeField] private float _initialTransmittedVolume;

    [SerializeField] private bool _redistribute = false;

    private void Start()
    {
        inputSystem.OnTouchEnded += StopRedistribute;
    }

    public void Initialize(BallData projectileData)
    {
        _projectileData = projectileData;
        _redistribute = true;

        RedistributeInstantly();
        StartCoroutine(Redistribute());
    }

    private void RedistributeInstantly()
    {
        _playerData.Volume -= _initialTransmittedVolume;
        _projectileData.Volume += _initialTransmittedVolume;
    }

    private IEnumerator Redistribute()
    {
        float accelerationOverTime = 1;

        while (_redistribute)
        {
            _playerData.Volume -= _power * accelerationOverTime * Time.deltaTime;
            _projectileData.Volume += _power * accelerationOverTime * Time.deltaTime;

            accelerationOverTime += Time.deltaTime / 2;

            yield return null;
        }
    }

    private void StopRedistribute()
    {
        _redistribute = false;
    }

    private void OnDestroy()
    {
        inputSystem.OnTouchEnded -= StopRedistribute;
    }
}
