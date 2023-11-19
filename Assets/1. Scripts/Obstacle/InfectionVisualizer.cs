using KevinCastejon.ConeMesh;
using UnityEngine;

public class InfectionVisualizer : MonoBehaviour
{
    [SerializeField] private Obstacle _obstacle;
    [SerializeField] private Cone _cone;

    [SerializeField] private Material _infectMaterial;
    [SerializeField] private GameObject _infectionVfxPrefab;
    [SerializeField] private GameObject _destructionVfxPrefab;

    private void Start()
    {
        _obstacle.OnInfect += OnInfectHandler;
        _obstacle.OnDie += OnDieHandler;
    }

    private void OnInfectHandler(Obstacle obstacle)
    {
        _obstacle.OnInfect -= OnInfectHandler;
        _cone.Material = _infectMaterial;

        Instantiate(_infectionVfxPrefab, transform.position, Quaternion.identity);
    }

    private void OnDieHandler(Obstacle obstacle)
    {
        _obstacle.OnDie -= OnDieHandler;

        if (!gameObject.scene.isLoaded)
            return;

        Instantiate(_destructionVfxPrefab, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        _obstacle.OnInfect -= OnInfectHandler;
        _obstacle.OnDie -= OnDieHandler;
    }
}
