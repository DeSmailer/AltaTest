using System.Collections.Generic;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;

    [SerializeField] private UI _ui;
    [SerializeField] private BallData _ballData;
    [SerializeField] private SizeController _sizeController;
    [SerializeField] private Track _track;
    [SerializeField] private Player _player;
    [SerializeField] private ObstaclesContainer _obstaclesContainer;

    [SerializeField] private int _currentLevel;
    [SerializeField] private List<LevelSettingsScriptableObject> _levelSettings;

    [SerializeField] private Transform _playerStartPosition;

    public int CurrentLevel
    {
        get
        {
            return _currentLevel;
        }
        set
        {
            _currentLevel = value;
            if (_currentLevel > _levelSettings.Count)
            {
                _currentLevel = 1;
            }
        }
    }

    private void Start()
    {
        CurrentLevel = 1;
        LoadLevel();
    }

    public void Restart()
    {
        LoadLevel();
    }

    public void NextLevel()
    {
        CurrentLevel++;
        LoadLevel();
    }

    public void LoadLevel()
    {
        LevelSettingsScriptableObject levelSettings = _levelSettings[CurrentLevel - 1];

        _ui.CloseAllWindows();

        _player.gameObject.transform.position = _playerStartPosition.position;
        _player.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        _ballData.Volume = levelSettings.Volume;
        _player.Initialize(levelSettings.MinimumCriticalVolume);

        _obstaclesContainer.SetNewObstacles(levelSettings.ObstaclesPrefab);

        _sizeController.Resize();
        _track.Initialize();

        _inputSystem.Unlock();
    }

    private void OnValidate()
    {

    }
}
