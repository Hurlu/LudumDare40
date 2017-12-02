using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {
    public Light [] array = new Light [6];

    // Use this for initialization
    void Start () {
        //l1 = GetComponent<Light>();
    }
    void InputKeyborad() {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            array[0].enabled = !array[0].enabled;
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            array[1].enabled = !array[1].enabled;
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            array[2].enabled = !array[2].enabled;
        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            array[3].enabled = !array[3].enabled;
        }

        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            array[4].enabled = !array[4].enabled;
        }

        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            array[5].enabled = !array[5].enabled;
        }
    }

    // Update is called once per frame
    void Update () {
        InputKeyborad();
	}
}
