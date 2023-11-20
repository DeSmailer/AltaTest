using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public Action OnTouchBegan;
    public Action OnTouchEnded;

    [SerializeField] private bool _isUnlocked = true;

    void Update()
    {
        if (_isUnlocked)
        {

#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Mouse0))

            {
                OnTouchBegan?.Invoke();
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                OnTouchEnded?.Invoke();
            }
#else
    if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("OnTouchBegan");
                OnTouchBegan?.Invoke();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("OnTouchEnded");
                OnTouchEnded?.Invoke();
            }
        }
#endif

        }
    }

    public void Lock()
    {
        _isUnlocked = false;
        OnTouchEnded?.Invoke();
    }

    public void Unlock()
    {
        _isUnlocked = true;
    }
}
