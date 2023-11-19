using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] private BallData _ballData;
    [SerializeField] private CheckerOfPathPassability _checker;

    private void Start()
    {
        _ballData.OnRadiusChange += Resize;
    }

    public void Initialize()
    {
        Resize();
        //_checker.Initialize();
    }

    public void Resize()
    {
        float width = _ballData.Radius / 10;
        transform.localScale = new Vector3(width, transform.localScale.y, transform.localScale.z);

        //_checker.Check();
    }

    private void OnDestroy()
    {
        _ballData.OnRadiusChange -= Resize;
    }
}
