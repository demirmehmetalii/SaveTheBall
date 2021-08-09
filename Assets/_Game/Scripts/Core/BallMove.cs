using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMove : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float speed;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ai"))
        {
            BallShot();
            AİController.Instance.AiRotationFinish();
            Level level = LevelHandler.Instance.GetLevel();
            var first = level.aiList.First();
            level.aiList.Remove(first);
        }
    }


    public void BallShot()
    {
        rigidBody.velocity = Vector3.zero;
        var positionRandom = new Vector3(Random.Range(-0.3f, 0.3f), 0, 0);
        rigidBody.AddForce((transform.forward + transform.up + positionRandom) * speed);
    }
}