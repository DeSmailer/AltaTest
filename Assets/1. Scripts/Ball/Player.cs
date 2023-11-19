using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SizeController _sizeController;

    public void Initialize()
    {
        _sizeController.Initialize();
    }
}
