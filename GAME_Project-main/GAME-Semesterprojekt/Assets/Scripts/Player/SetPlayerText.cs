using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SetPlayerText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Player " + GetComponentInParent<PlayerConfig>().playerNumber;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
