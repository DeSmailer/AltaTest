using UnityEngine;

public class PlayerDeathVisualizer : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private GameObject _playerDeatVfx;

    void Start()
    {
        _player.OnInitialize += OnInitializeHandler;
        _player.OnDeath += OnDeathHandler;
    }

    private void OnInitializeHandler()
    {
        //_player.gameObject.SetActive(true);
    }

    private void OnDeathHandler()
    {
        //_player.gameObject.SetActive(false);
        Instantiate(_playerDeatVfx, _player.transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        _player.OnInitialize -= OnInitializeHandler;
        _player.OnDeath -= OnDeathHandler;
    }
}