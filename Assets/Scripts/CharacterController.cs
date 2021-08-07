using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterController : Singleton<CharacterController>
{
    [SerializeField] private Animator targetAnimator;
    public float speedAi;
    public bool move = false;

    private bool walk = false;

    void Update()
    {
        if (move)
        {
            transform.position += transform.forward * Time.deltaTime * speedAi;
            this.walk = true;
            this.targetAnimator.SetBool("Walk", this.walk);
        }
        else
        {
            this.walk = false;
        }
    }

    public void rot()
    {
        transform.DORotate(new Vector3(0, 90, 0), 1f);
    }
}