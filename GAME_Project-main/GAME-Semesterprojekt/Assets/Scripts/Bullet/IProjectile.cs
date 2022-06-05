using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    void Shoot(GameObject player);
    void Fly();
    void OnHit(GameObject hittedObject);
}
