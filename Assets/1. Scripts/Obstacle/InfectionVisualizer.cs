using UnityEngine;

public class InfectionVisualizer : MonoBehaviour
{
    [SerializeField] private Obstacle _obstacle;
    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private Material _infectMaterial;
    [SerializeField] private GameObject _infectionVfxPrefab;
    [SerializeField] private GameObject _destructionVfxPrefab;

    private void Start()
    {
        _obstacle.OnInfect += OnInfectHandler;
        _obstacle.OnDeathByProjectile += OnDieHandler;
    }

    private void OnInfectHandler(Obstacle obstacle)
    {
        _obstacle.OnInfect -= OnInfectHandler;
        _meshRenderer.material = _infectMaterial;

        Instantiate(_infectionVfxPrefab, transform.position, Quaternion.identity);
    }

    private void OnDieHandler(Obstacle obstacle)
    {
        _obstacle.OnDeathByProjectile -= OnDieHandler;

        if (!gameObject.scene.isLoaded)
            return;

        Instantiate(_destructionVfxPrefab, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        _obstacle.OnInfect -= OnInfectHandler;
        _obstacle.OnDeathByProjectile -= OnDieHandler;
    }
}
