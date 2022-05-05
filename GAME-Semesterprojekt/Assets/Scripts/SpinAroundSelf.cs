using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAroundSelf : MonoBehaviour
{

    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 200;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = transform.eulerAngles + (Vector3.up * speed * Time.deltaTime);
    }
}
