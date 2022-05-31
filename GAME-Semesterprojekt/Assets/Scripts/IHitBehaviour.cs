using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitBehaviour 
{
    // was macht das gehittete objekt
    public void OnHit(GameObject hittedObject);
}
