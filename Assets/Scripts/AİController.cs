using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class AİController : Singleton<AİController>
{
    [SerializeField] private Animator targetAnimator;
    public float speedAi;

    private bool walk = false;

    void Update()
    {
        if (GameManager.isRunning)
        {
            transform.position += transform.forward * Time.deltaTime * speedAi;
            this.walk = true;
            this.targetAnimator.SetBool("Walk", this.walk);
        }
    }

    public void AiRotationFinish()
    {
        transform.DORotate(new Vector3(0, 90, 0), 1f);
    }
}