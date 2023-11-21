using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private InputSystem _inputSystem;

    [SerializeField] private BallData _playerBallData;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private float _spawnPositionOffsetZ;

    [SerializeField] private VolumeRedistributor _volumeRedistributor;

    [SerializeField] private List<Projectile> _projectiles;

    private void Start()
    {
        _inputSystem.OnTouchBegan += Spawn;
    }

    public void Spawn()
    {
        Vector3 _spawnPosition = new Vector3(0, transform.position.y, transform.position.z + _playerBallData.Radius + _spawnPositionOffsetZ);
        Projectile projectile = Instantiate(_projectilePrefab, _spawnPosition, Quaternion.identity);

        projectile.OnProjectileDestroy += OnProjectileDestroyHandler;
        _projectiles.Add(projectile);

        _volumeRedistributor.Initialize(projectile.BallData);
        projectile.Initialize(_inputSystem);
    }

    private void OnProjectileDestroyHandler(Projectile projectile)
    {
        projectile.OnProjectileDestroy -= OnProjectileDestroyHandler;
        _projectiles.Remove(projectile);
    }

    public void DestroyAllProjectiles()
    {
        Debug.Log("DestroyAllProjectiles");
        for (int i = 0; i < _projectiles.Count; i++)
        {
            if (_projectiles[i] != null)
            {
                Debug.Log("DestroyAllProjectiles " + i);
                _projectiles[i].OnProjectileDestroy -= OnProjectileDestroyHandler;
                _projectiles[i].DestroyProjectile();
            }
        }

        _projectiles.Clear();
    }

    private void OnDestroy()
    {
        DestroyAllProjectiles();

        _inputSystem.OnTouchBegan -= Spawn;
    }

    private void OnDrawGizmos()
    {
        Vector3 _spawnPosition = new Vector3(0, transform.position.y, transform.position.z + _playerBallData.Radius + _spawnPositionOffsetZ);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_spawnPosition, 0.1f);
    }
}
