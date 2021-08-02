using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : Singleton<PlayerController>
{
    //Some variables...
    float Speed => Configs.Player.speed;


    public void OnGameStarted()
    {
    }

    private void Update()
    {
        var delta = TouchHandler.Instance.delta;
        transform.position += new Vector3(delta.x, delta.y, 0)*Time.deltaTime;
    }
}