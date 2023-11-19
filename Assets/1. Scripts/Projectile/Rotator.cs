using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float _speed;
    private bool _canRotate = false;

    public void StartRotate(float speed)
    {
        _speed = speed;
        _canRotate = true;
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        while (_canRotate)
        {
            transform.Rotate(new Vector3(_speed * Time.deltaTime, 0, 0));

            yield return null;
        }
    }

    public void StopRotate()
    {
        _canRotate = false;
    }
}
