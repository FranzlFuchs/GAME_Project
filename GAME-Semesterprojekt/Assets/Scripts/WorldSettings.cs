using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = Vector3.down * 80;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
