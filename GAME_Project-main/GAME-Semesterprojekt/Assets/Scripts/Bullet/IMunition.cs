using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMunition
{
    // Start is called before the first frame update
    void Spawn(Vector3 spawnPosition);
    void PickUp();
    float GetSpawnIntervalNextMunition();

}
