using System.Collections;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _canMove = false;

    [SerializeField] private Rotator _rotator;

    public void StartMove()
    {
        _canMove = true;
        StartCoroutine(Move());

        float w = (_speed / GetComponent<BallData>().Radius) * 57.2957795131f; /*(180 / Mathf.PI);*/
        _rotator.StartRotate(w);
    }

    private IEnumerator Move()
    {
        while (_canMove)
        {
            transform.position += new Vector3(0, 0, _speed * Time.deltaTime);

            yield return null;
        }
        _rotator.StopRotate();
    }

    public void StopMove()
    {
        _canMove = false;
    }
}
