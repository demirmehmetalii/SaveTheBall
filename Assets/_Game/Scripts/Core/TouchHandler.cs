using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchHandler : Singleton<TouchHandler>
{
    public enum TouchTypes
    {
        Core = 0,

        SecondaryMechanic = 1
        //.....so on
    }

    TouchTypes activeTouch;

    //Delegate Functions. You can change them at spesific parts like end of
    //the level or at different types of obstacles

    private delegate void OnDownAction();

    private OnDownAction OnDown = null;

    private delegate void OnUpAction();

    private OnUpAction OnUp = null;

    private delegate void OnDragAction();

    private OnDragAction OnDrag = null;

    private bool isDragging = false;
    private bool canPlay = false;

    private Vector3 fp, lp, dif;
    public Vector2 delta;
    public Vector3 initialMousePosition = Vector3.zero;
    public float inputSensitivity;
    bool IsActive() => GameManager.isRunning && canPlay;

    private void Update()
    {
        if (IsActive())
            HandleTouch();
    }

    public void OnGameStarted()
    {
        canPlay = true;
    }

    void HandleTouch()
    {
        if (!isDragging)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnDown?.Invoke();
                isDragging = true;
            }
        }
        else
        {
            OnDrag?.Invoke();

            if (Input.GetMouseButtonUp(0))
            {
                OnUp?.Invoke();
                isDragging = false;
            }
        }
    }

    public void Initialize(TouchTypes tt = TouchTypes.Core, bool isButtonDerived = true, bool isStart = false)
    {
        switch (tt)
        {
            case TouchTypes.Core:
                OnDown = CoreDown;
                OnUp = CoreUp;
                OnDrag = CoreDrag;
                break;

            case TouchTypes.SecondaryMechanic:
                OnDown = OnDownSecondary;
                OnUp = OnUpSecondary;
                OnDrag = OnDragSecondary;
                break;

            //You may add your secondary actions here

            default:
                OnDown = CoreDown;
                OnUp = CoreUp;
                OnDrag = CoreDrag;
                break;
        }

        if (isStart)
            UIManager.Instance.Initialize(isButtonDerived);
    }

    int counter = 0;

    void CoreDown()
    {
        delta.y = 0.0f;
        initialMousePosition = Input.mousePosition;
        PlayerController.Instance.Anim(true);
    }

    void CoreUp()
    {
        delta = (Input.mousePosition - initialMousePosition) *
                (((float)Screen.width / Screen.height) * inputSensitivity);
        initialMousePosition = Input.mousePosition;
        StartCoroutine(PlayerController.Instance.PlayerMover(delta));
        PlayerController.Instance.Anim(false);
    }

    void CoreDrag()
    {
    }

    void OnDownSecondary()
    {
        Debug.Log("On Down Sec");
    }

    void OnDragSecondary()
    {
        Debug.Log("On Drag Sec");
    }

    void OnUpSecondary()
    {
        Debug.Log("On Up Sec");
    }
}