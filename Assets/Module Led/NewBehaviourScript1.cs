using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript1 : MonoBehaviour {
    public Light [] array = new Light [6];


    private int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }

   private void Shuffle<T>(T[] array)
    {
        System.Random random = new System.Random();
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            int r = i + random.Next(n - i);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
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
        if (Input.GetKeyUp(KeyCode.A))
        {
            Shuffle(array);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
        InputKeyborad();
	}
}
