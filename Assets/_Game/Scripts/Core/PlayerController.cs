using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : Singleton<PlayerController>
{
    //Some variables...
    float Speed => Configs.Player.speed;

    private void Start()
    {
    }

    public void OnGameStarted()
    {
        GameManager.Instance.Ball();
    }

    private void FixedUpdate()
    {
        if (GameManager.isRunning)
        {
            // var pos = transform.position;
            // pos.x = Mathf.Clamp(transform.position.x, -4.0f, 4.0f);
            // pos.y = Mathf.Clamp(transform.position.y, 0.05f, 4.0f);
            var delta = TouchHandler.Instance.delta;
            transform.position += new Vector3(delta.x, delta.y, 0);
        }
    }
}