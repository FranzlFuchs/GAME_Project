using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class StandardMunition : Munition

{
    
    public override void Spawn(Vector3 spawnPosition)
    {
        GameObject newMunition = Instantiate(gameObject, spawnPosition, gameObject.transform.rotation);

        newMunition.gameObject.AddComponent<SpinAroundSelf>();
    }


    public override void PickUp()
    {
        Destroy(gameObject);
    }
}
