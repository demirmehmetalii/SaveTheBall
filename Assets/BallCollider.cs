using UnityEngine;

public class BallCollider : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.Ball();
        }
    }
}