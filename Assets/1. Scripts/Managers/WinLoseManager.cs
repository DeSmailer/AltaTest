using System;
using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;

    [SerializeField] private PlayerWinAnimation _playerWinAnimation;

    [SerializeField] private Player _player;
    [SerializeField] private CheckerOfPathPassability _checkerOfPathPassability;

    public Action OnWin;
    public Action OnLose;

    private void Awake()
    {
        _player.OnDeath += Lose;
        _checkerOfPathPassability.OnNoObstacles += PlayPlayerWinAnimation;
    }

    public void PlayPlayerWinAnimation()
    {
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
        _inputSystem.Lock();
        OnLose?.Invoke();
    }

    private void OnDestroy()
    {
        _player.OnDeath -= Lose;
        _checkerOfPathPassability.OnNoObstacles -= PlayPlayerWinAnimation;
    }
}
