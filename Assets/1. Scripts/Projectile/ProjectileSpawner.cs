using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;

    [SerializeField] private BallData _playerBallData;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private float _spawnPositionOffsetZ;

    [SerializeField] private VolumeRedistributor _volumeRedistributor;

    private void Start()
    {
        _inputSystem.OnTouchBegan += Spawn;
    }

    public void Spawn()
    {
        Vector3 _spawnPosition = new Vector3(0, transform.position.y, transform.position.z + _playerBallData.Radius + _spawnPositionOffsetZ);
        Projectile projectile = Instantiate(_projectilePrefab, _spawnPosition, Quaternion.identity);

        projectile.Initialize(_inputSystem);
        _volumeRedistributor.Initialize(projectile.BallData);
    }

    private void OnDestroy()
    {
        _inputSystem.OnTouchBegan -= Spawn;
    }

    private void OnDrawGizmos()
    {
        Vector3 _spawnPosition = new Vector3(0, transform.position.y, transform.position.z + _playerBallData.Radius + _spawnPositionOffsetZ);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_spawnPosition, 0.1f);
    }
}
