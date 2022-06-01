using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotMunition : Munition
{
    public override void PickUp()
    {
        Destroy(gameObject);
    }

    public override void Spawn(Vector3 spawnPosition)
    {
        // GameObject newMunition1 = Instantiate(gameObject, new Vector3(spawnPosition.x + 1, spawnPosition.y, spawnPosition.z - 1), gameObject.transform.rotation);
        //newMunition1.gameObject.AddComponent<SpinAroundSelf>();

        GameObject newMunition2 = Instantiate(gameObject, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z), gameObject.transform.rotation);
        newMunition2.gameObject.AddComponent<SpinAroundSelf>();

        //GameObject newMunition3 = Instantiate(gameObject, new Vector3(spawnPosition.x + 1, spawnPosition.y, spawnPosition.z + 1), gameObject.transform.rotation);
        //newMunition3.gameObject.AddComponent<SpinAroundSelf>();
    }
}
