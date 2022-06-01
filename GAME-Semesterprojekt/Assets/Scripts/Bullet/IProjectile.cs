using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    void Shoot();
    void OnHit(GameObject hittedObject);
}
