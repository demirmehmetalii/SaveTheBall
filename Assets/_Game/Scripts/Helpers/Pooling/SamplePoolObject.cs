using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePoolObject : PoolObject
{
    public override void OnCreated()
    {
        OnDeactivate();
    }

    public override void OnDeactivate()
    {
        gameObject.SetActive(false);
    }

    public override void OnSpawn()
    {
        gameObject.SetActive(true);
    }
}
