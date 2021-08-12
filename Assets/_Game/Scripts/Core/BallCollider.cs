using System;
using System.Collections;
using UnityEngine;

public class BallCollider : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BallPlayer"))
        {
            StartCoroutine(nameof(BallShotDelay));
            GameManager.Instance.ListControlRemove();
        }
    }

    private IEnumerator BallShotDelay()
    {
        yield return new WaitForSeconds(GameManager.Instance.ballShotDelay);
        GameManager.Instance.Ball();
    }
}