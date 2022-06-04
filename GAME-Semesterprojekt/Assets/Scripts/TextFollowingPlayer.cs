using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFollowingPlayer : MonoBehaviour
{
    public Transform cam;

    void Start()
    {
        cam = FindObjectOfType<Camera>().transform;

    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
        transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z - 3);

    }
}
