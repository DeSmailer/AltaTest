using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "ScriptableObjects/LevelSettings", order = 1)]
public class LevelSettingsScriptableObject : ScriptableObject
{
    [SerializeField] private float _volume;
    [SerializeField] private float _minimumCriticalVolume;

    [SerializeField] private GameObject _obstaclesPrefab;

    public float Volume => _volume;
    public float MinimumCriticalVolume => _minimumCriticalVolume;

    public GameObject ObstaclesPrefab => _obstaclesPrefab;
}
