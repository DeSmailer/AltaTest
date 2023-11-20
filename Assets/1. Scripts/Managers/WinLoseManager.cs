using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;

    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _loseWindow;

    [SerializeField] private Player _player;

    private void Awake()
    {
        _loseWindow.SetActive(false);
        _winWindow.SetActive(false);

        _player.OnDeath += Lose;
    }

    public void Win()
    {
        _loseWindow.SetActive(false);
        _winWindow.SetActive(true);

        _inputSystem.Lock();
    }

    public void Lose()
    {
        _loseWindow.SetActive(true);
        _winWindow.SetActive(false);

        _inputSystem.Lock();
    }

    public void NextLevel()
    {

    }

    public void RestartLevel()
    {

    }

    public void Exit()
    {

    }
}
