using System.Collections;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _canMove = false;

    public void StartMove()
    {
        _canMove = true;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (_canMove)
        {
            transform.position += new Vector3(0, 0, _speed * Time.deltaTime);

            yield return null;
        }
    }
}
