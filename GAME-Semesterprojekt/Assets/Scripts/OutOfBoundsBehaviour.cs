using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private float zBound = 50;
    private float xBound = 50;
    private float yBound = -30;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > zBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < -zBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > xBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < yBound)
        {
            Destroy(gameObject);
        }
    }
}
