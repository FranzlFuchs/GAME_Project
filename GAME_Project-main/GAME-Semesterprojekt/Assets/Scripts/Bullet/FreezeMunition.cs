using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeMunition : Munition
{

    public override void Spawn(Vector3 spawnPosition)
    {
        GameObject newMunition3 = Instantiate(gameObject, spawnPosition, gameObject.transform.rotation);

        newMunition3.gameObject.AddComponent<SpinAroundSelf>();
    }


    public override void PickUp()
    {
        Destroy(gameObject);
    }
}
