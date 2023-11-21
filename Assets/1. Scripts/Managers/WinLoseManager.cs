using System;
using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;

    [SerializeField] private PlayerWinAnimation _playerWinAnimation;

    [SerializeField] private Player _player;
    [SerializeField] private CheckerOfPathPassability _checkerOfPathPassability;

    [SerializeField] private bool _isResultReceived = false;

    public Action OnWin;
    public Action OnLose;

    private void Awake()
    {
        _player.OnDeath += Lose;
        _checkerOfPathPassability.OnNoObstacles += PlayPlayerWinAnimation;
    }

    public void PlayPlayerWinAnimation()
    {
        if (_isResultReceived)
            return;

        _isResultReceived = true;
        _inputSystem.Lock();
        _playerWinAnimation.Play(Win);
    }

    public void Win()
    {
        _inputSystem.Lock();
        OnWin?.Invoke();
    }

    public void Lose()
    {
        if (_isResultReceived)
            return;

        _isResultReceived = true;
        _inputSystem.Lock();
        OnLose?.Invoke();
    }

    public void Restart()
    {
        _isResultReceived = false;
    }

    private void OnDestroy()
    {
        _player.OnDeath -= Lose;
        _checkerOfPathPassability.OnNoObstacles -= PlayPlayerWinAnimation;
    }
}
