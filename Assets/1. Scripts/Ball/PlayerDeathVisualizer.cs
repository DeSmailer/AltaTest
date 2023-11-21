using UnityEngine;

public class PlayerDeathVisualizer : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private GameObject _playerDeatVfx;

    void Start()
    {
        _player.OnDeath += OnDeathHandler;
    }

    private void OnDeathHandler()
    {
        Instantiate(_playerDeatVfx, _player.transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        _player.OnDeath -= OnDeathHandler;
    }
}