using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MyBox;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : Singleton<PlayerController>
{
    float Speed => Configs.Player.speed;

    [SerializeField] public Animator targetAnimator;
    public Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void OnGameStarted()
    {
        GameManager.Instance.Ball();
    }

    

    public IEnumerator PlayerMover(Vector2 delta)
    {
        saveDelta = delta;
        rigidBody.AddForce(new Vector3(saveDelta.x, saveDelta.y, 0) * 10000f);
        yield return new WaitForSeconds(1f);
        transform.DORotate(new Vector3(transform.eulerAngles.x, 0, 0), 1f);
    }

    public Vector2 saveDelta;

    public void Anim(bool stateAnim)
    {
        this.targetAnimator.SetBool("Walk", stateAnim);
    }
}