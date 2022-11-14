using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightBehavior : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement player;

    private bool isReversed = false;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Light>().color = (!isReversed) ? new Color(0.5424528f, 0.633156f, 1.0f) : new Color (1.0f, 0.6597413f, 0.0f);

        if (Input.GetKeyDown(KeyCode.F))
        {
            isReversed = isReversed ? false : true;
        }
    }
}
