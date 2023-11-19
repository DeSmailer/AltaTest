using KevinCastejon.ConeMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionVisualizer : MonoBehaviour
{
    [SerializeField] private Obstacle _obstacle;
    [SerializeField] private Cone _cone;

    [SerializeField] private Material _infectMaterial;
    [SerializeField] private GameObject _boomVfxPrefab;

    private void Start()
    {
        _obstacle.OnInfect += OnInfectHandler;
        _obstacle.OnDie += OnDieHandler;
    }

    private void OnInfectHandler(Obstacle obstacle)
    {
        _obstacle.OnInfect -= OnInfectHandler;
        _cone.Material = _infectMaterial;
    }

    private void OnDieHandler(Obstacle obstacle)
    {
        _obstacle.OnDie -= OnDieHandler;
        Instantiate(_boomVfxPrefab, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        _obstacle.OnInfect -= OnInfectHandler;
        _obstacle.OnDie -= OnDieHandler;
    }
}
