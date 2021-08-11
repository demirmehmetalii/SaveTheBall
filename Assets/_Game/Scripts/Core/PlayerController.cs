using System;
using System.Collections;
using System.Collections.Generic;
using MyBox;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : Singleton<PlayerController>
{
    //Some variables...
    float Speed => Configs.Player.speed;

    [SerializeField] public Animator targetAnimator;

    public void OnGameStarted()
    {
        GameManager.Instance.Ball();
    }

    private void FixedUpdate()
    {
        if (GameManager.isRunning)
        {
            var delta = TouchHandler.Instance.delta;
            Vector3 direction = new Vector3(0, 0, delta.x * 15f);
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, delta.x, 0.1f),
                Mathf.Lerp(transform.position.y, delta.y, 0.1f), transform.position.z);
            transform.eulerAngles = new Vector3(0, 0, -direction.z);
        }
    }
}