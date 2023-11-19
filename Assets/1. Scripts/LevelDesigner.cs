using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    [SerializeField] private float _volume;

    [SerializeField] private BallData _ballData;
    [SerializeField] private SizeController _sizeController;
    [SerializeField] private Track _track;
    [SerializeField] private Player _player;

    private void Start()
    {
        _ballData.Volume = _volume;
        _sizeController.Resize();
        _track.Initialize();
        _player.Initialize();
    }

    private void OnValidate()
    {
        
    }
}
