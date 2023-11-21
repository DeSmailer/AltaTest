using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private WinLoseManager _winLoseManager;

    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _loseWindow;

    [SerializeField] private LevelDesigner _levelDesigner;

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
        _levelDesigner.NextLevel();
    }

    public void RestartLevel()
    {
        CloseAllWindows();
        _levelDesigner.Restart();
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
