using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{


    bool isAlive;


    void Start()
    {
        isAlive = true;

    }
    void Update()
    {

    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Ground") && isAlive)
        {
            FindObjectOfType<GameManager>().PlayerDied(gameObject);
            gameObject.SetActive(false);
            isAlive = false;

        }
    }
}
