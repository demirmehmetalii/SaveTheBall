using System;
using System.Collections;
using System.Collections.Generic;
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
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ai"))
        {
           BallShot();
        }
    }

    public void BallShot()
    {
        var positionRandom = new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
        rigidBody.AddForce((transform.forward + transform.up + positionRandom) * speed);
    }
}