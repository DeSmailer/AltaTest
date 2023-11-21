using System.Collections.Generic;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;

    [SerializeField] private UI _ui;
    [SerializeField] private PlayerHPView _playerHPView;
    [SerializeField] private LevelNumberSetter _levelNumberSetter;

    [SerializeField] private BallData _ballData;
    [SerializeField] private SizeController _sizeController;
    [SerializeField] private Transform _playerStartPosition;
    [SerializeField] private Player _player;

    [SerializeField] private Door _door ;

    [SerializeField] private WinLoseManager _winLoseManager;

    [SerializeField] private Track _track;
    [SerializeField] private CheckerOfPathPassability _checkerOfPathPassability;

    [SerializeField] private ProjectileSpawner _projectileSpawner;

    [SerializeField] private ObstaclesContainer _obstaclesContainer;

    [SerializeField] private int _currentLevel;
    [SerializeField] private List<LevelSettingsScriptableObject> _levelSettings;

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

        _checkerOfPathPassability.Lock();

        _ui.CloseAllWindows();
        _levelNumberSetter.SetText(CurrentLevel);

        _projectileSpawner.DestroyAllProjectiles();

        _obstaclesContainer.SetNewObstacles(levelSettings.ObstaclesPrefab, _checkerOfPathPassability.Unlock);

        _player.gameObject.transform.position = _playerStartPosition.position;
        _player.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        _player.Initialize(levelSettings.MinimumCriticalVolume);
        _ballData.Volume = levelSettings.Volume;

        _door.Initialize();

        _playerHPView.Initialize();

        _sizeController.Resize();

        _track.Initialize();

        _winLoseManager.Restart();

        _inputSystem.Unlock();
        _checkerOfPathPassability.Unlock();
    }
}
