using UnityEngine;

public class WinLoseManager : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;

    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _loseWindow;

    [SerializeField] private PlayerWinAnimation _playerWinAnimation;

    [SerializeField] private Player _player;
    [SerializeField] private CheckerOfPathPassability _checkerOfPathPassability;

    private void Awake()
    {
        _loseWindow.SetActive(false);
        _winWindow.SetActive(false);

        _player.OnDeath += Lose;
        _checkerOfPathPassability.OnNoObstacles += PlayerWinAnimation;
    }

    public void Win()
    {
        _loseWindow.SetActive(false);
        _winWindow.SetActive(true);

        _inputSystem.Lock();
    }

    public void PlayerWinAnimation()
    {
        _playerWinAnimation.Play(Win);
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

    private void OnDestroy()
    {
        _player.OnDeath -= Lose;
        _checkerOfPathPassability.OnNoObstacles -= PlayerWinAnimation;
    }
}
