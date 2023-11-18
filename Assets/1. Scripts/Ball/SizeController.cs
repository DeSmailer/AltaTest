using UnityEngine;

public class SizeController : MonoBehaviour
{
    [SerializeField] private BallData _ballData;

    private void Start()
    {
        _ballData.OnRadiusChange += Resize;
    }

    public void Resize()
    {
        float radius = _ballData.Radius;
        transform.localScale = new Vector3(radius, radius, radius);

        StandOnGround();
    }

    private void StandOnGround()
    {
        Vector3 pos = transform.position;
        pos.y = _ballData.Radius / 2;
        transform.position = pos;
    }

    private void OnDestroy()
    {
        _ballData.OnRadiusChange -= Resize;
    }
}
