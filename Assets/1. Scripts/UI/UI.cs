using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private WinLoseManager _winLoseManager;

    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _loseWindow;

    private void Start()
    {
        CloseAllWindows();

        _winLoseManager.OnWin += OnWinHandler;
        _winLoseManager.OnLose += OnLoseHandler;
    }

    public void CloseAllWindows()
    {
        _loseWindow.SetActive(false);
        _winWindow.SetActive(false);
    }

    public void OnWinHandler()
    {
        _loseWindow.SetActive(false);
        _winWindow.SetActive(true);
    }

    public void OnLoseHandler()
    {
        _loseWindow.SetActive(true);
        _winWindow.SetActive(false);
    }

    public void NextLevel()
    {
        CloseAllWindows();
    }

    public void RestartLevel()
    {
        CloseAllWindows();
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        _winLoseManager.OnWin -= OnWinHandler;
        _winLoseManager.OnLose -= OnLoseHandler;
    }
}
