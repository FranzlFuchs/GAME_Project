using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{

    private float ybound = -30;

    void Start()
    {

    }
    void Update()
    {
        if (transform.position.y < ybound)
        {
            FindObjectOfType<GameManager>().PlayerDied(gameObject);
            gameObject.SetActive(false);
        }

    }
}
