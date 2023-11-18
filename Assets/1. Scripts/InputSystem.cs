using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public Action OnTouchBegan;
    public Action OnTouchEnded;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Mouse0))

        {
            Debug.Log("OnTouchBegan");
            OnTouchBegan?.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log("OnTouchEnded");
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
