using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
public class MunitionDictionary : MonoBehaviour
{

    public Dictionary<BulletType, GameObject> ProjectilesDictionary = new Dictionary<BulletType, GameObject>();
    public Dictionary<BulletType, GameObject> MunitionsDictionary = new Dictionary<BulletType, GameObject>();

    public List<GameObject> MunitionList = new List<GameObject>();
    public List<GameObject> ProjectileList = new List<GameObject>();

    // save the dictionary to lists
    void Start()
    {
        foreach (BulletType bulletType in Enum.GetValues(typeof(BulletType)))
        {
            ProjectilesDictionary.Add(bulletType, ProjectileList[(int)bulletType]);
        }
        foreach (BulletType bulletType in Enum.GetValues(typeof(BulletType)))
        {
            MunitionsDictionary.Add(bulletType, MunitionList[(int)bulletType]);
        }


    }

}
