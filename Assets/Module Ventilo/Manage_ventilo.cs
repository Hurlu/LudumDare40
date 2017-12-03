using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage_ventilo : MonoBehaviour
{
    private bool IsPressed = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsPressed = false;
        }
    }
}
