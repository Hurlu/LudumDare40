using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manage_Leds : MonoBehaviour {
    #region "Variables"
    public KeyCode[] Keycode_array = new KeyCode[6];
    public SpriteRenderer [] SR_lamps_array = new SpriteRenderer [6];
    public SpriteRenderer[] SR_number_array = new SpriteRenderer[6];
    public Sprite [] S_on_array = new Sprite [6];
    public Sprite [] S_off_array = new Sprite [6];
    public Sprite[] S_number_array = new Sprite[6];
    private Boolean [] L_is_on = new Boolean [6];

    #endregion

    #region "Functions"

    private int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }

    private void Shuffle()
    {
        System.Random random = new System.Random();
        int n = SR_lamps_array.Length;
        for (int i = 0; i < n; i++)
        {
            int r = RandomNumber(0, n);

            Sprite t2 = S_on_array[r];
            S_on_array[r] = S_on_array[i];
            S_on_array[i] = t2;

            Sprite t3 = S_off_array[r];
            S_off_array[r] = S_off_array[i];
            S_off_array[i] = t3;

            Boolean t4 = L_is_on[r];
            L_is_on[r] = L_is_on[i];
            L_is_on[i] = t4;

            Sprite t5 = S_number_array[r];
            S_number_array[r] = S_number_array[i];
            S_number_array[i] = t5;

            KeyCode t6 = Keycode_array[r];
            Keycode_array[r] = Keycode_array[i];
            Keycode_array[i] = t6;
        }
        for (int i = 0; i < n; i++)
        {
            SR_lamps_array[i].sprite = (L_is_on[i]) ? S_on_array[i] : S_off_array[i];
            SR_number_array[i].sprite = S_number_array[i];
        }
    }
    
    #endregion

    #region "Keyboard Inputs"

    void InputKeyborad() {
        if (Input.GetKeyUp(Keycode_array[0]))
        {
            if (L_is_on[0] == false)
            {
                SR_lamps_array[0].sprite = S_on_array[0];
                L_is_on[0] = true;
            }
            else if (L_is_on[0] == true)
            {
                SR_lamps_array[0].sprite = S_off_array[0];
                L_is_on[0] = false;
            }
        }

        if (Input.GetKeyUp(Keycode_array[1]))
        {
            if (L_is_on[1] == false)
            {
                SR_lamps_array[1].sprite = S_on_array[1];
                L_is_on[1] = true;
            }
            else if (L_is_on[1] == true)
            {
                SR_lamps_array[1].sprite = S_off_array[1];
                L_is_on[1] = false;
            }
        }

        if (Input.GetKeyUp(Keycode_array[2]))
        {
            if (L_is_on[2] == false)
            {
                SR_lamps_array[2].sprite = S_on_array[2];
                L_is_on[2] = true;
            }
            else if (L_is_on[2] == true)
            {
                SR_lamps_array[2].sprite = S_off_array[2];
                L_is_on[2] = false;
            }
        }

        if (Input.GetKeyUp(Keycode_array[3]))
        {
            if (L_is_on[3] == false)
            {
                SR_lamps_array[3].sprite = S_on_array[3];
                L_is_on[3] = true;
            }
            else if (L_is_on[3] == true)
            {
                SR_lamps_array[3].sprite = S_off_array[3];
                L_is_on[3] = false;
            }
        }

        if (Input.GetKeyUp(Keycode_array[4]))
        {
            if (L_is_on[4] == false)
            {
                SR_lamps_array[4].sprite = S_on_array[4];
                L_is_on[4] = true;
            }
            else if (L_is_on[4] == true)
            {
                SR_lamps_array[4].sprite = S_off_array[4];
                L_is_on[4] = false;
            }
        }

        if (Input.GetKeyUp(Keycode_array[5]))
        {
            if (L_is_on[5] == false)
            {
                SR_lamps_array[5].sprite = S_on_array[5];
                L_is_on[5] = true;
            }
            else if (L_is_on[5] == true)
            {
                SR_lamps_array[5].sprite = S_off_array[5];
                L_is_on[5] = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Shuffle();
        }
    }

    #endregion

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            L_is_on[i] = false;
        }
    }

    // Update is called once per frame
    void Update () {
        InputKeyborad();
	}
}
