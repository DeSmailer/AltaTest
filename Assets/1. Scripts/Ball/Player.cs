using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SizeController _sizeController;

    void Start()
    {
        _sizeController.Initialize();
    }

}
