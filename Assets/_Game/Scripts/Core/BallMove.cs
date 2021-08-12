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
            this.gameObject.tag = "BallPlayer";
            BallShotAi();
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.playerHeldShot += 1;
            this.gameObject.tag = "Untagged";
            BallShotPlayer();
        }
    }

    public void BallShotAi()
    {
        rigidBody.velocity = Vector3.zero;
        var positionRandom = new Vector3(Random.Range(-0.25f, 0.25f), 0, 0);
        rigidBody.AddForce((transform.forward + transform.up + positionRandom) * speed);
        AİController.Instance.AiRotationFinish();
    }

    public void BallShotPlayer()
    {
        rigidBody.velocity = Vector3.zero;
        rigidBody.AddForce((new Vector3(5, 5, 0)) * speed);
    }
}