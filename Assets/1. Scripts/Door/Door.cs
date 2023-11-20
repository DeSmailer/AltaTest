using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _player;

    private const string _idleAnimation = "IdleDoor";
    private const string _openAnimation = "OpenDoor";
    //private const string _openedAnimation = "OpenedDoor";

    private bool _isOpening = false;
    [SerializeField] private float _openDistance;

    public void Initialize()
    {
        _isOpening = false;
        _animator.Play(_idleAnimation);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.position) <= _openDistance)
        {
            if (_isOpening == false)
            {
                OpenDoor();
            }
        }
        Debug.Log(Vector3.Distance(transform.position, _player.position));
    }

    private void OpenDoor()
    {
        _isOpening = true;
        _animator.Play(_openAnimation);
    }
}
