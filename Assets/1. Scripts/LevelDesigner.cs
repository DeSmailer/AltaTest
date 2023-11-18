using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    [SerializeField] private float _volume;

    [SerializeField] private BallData _ballData;
    [SerializeField] private SizeController _sizeController;
    [SerializeField] private Track _track ;

    private void OnValidate()
    {
        _ballData.Volume = _volume;
        _sizeController.Resize();
        _track.Resize();
    }
}
