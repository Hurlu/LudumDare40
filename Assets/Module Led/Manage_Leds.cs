using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manage_Leds : MonoBehaviour {
    #region "Variables"

    public SpriteRenderer [] Sprite_RD_array = new SpriteRenderer [6];
    public Sprite [] S_on_array = new Sprite [6];
    public Sprite [] S_off_array = new Sprite [6];
    private Boolean [] L_is_on = new Boolean [6];

    #endregion

    #region "Functions"

    private int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }

    private void Shuffle(SpriteRenderer[] array, Sprite[] array2, Sprite[] array3, Boolean[] array4)
    {
        System.Random random = new System.Random();
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            int r = i + random.Next(n - i);
            SpriteRenderer t = array[r];
            array[r] = array[i];
            array[i] = t;

            Sprite t2 = array2[r];
            array2[r] = array2[i];
            array2[i] = t2;

            Sprite t3 = array3[r];
            array3[r] = array3[i];
            array3[i] = t3;

            Boolean t4 = array4[r];
            array4[r] = array4[i];
            array4[i] = t4;
        }
    }
    
    #endregion

    #region "Keyboard Inputs"

    void InputKeyborad() {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (L_is_on[0] == false)
            {
                Sprite_RD_array[0].sprite = S_on_array[0];
                L_is_on[0] = true;
            }
            else if (L_is_on[0] == true)
            {
                Sprite_RD_array[0].sprite = S_off_array[0];
                L_is_on[0] = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (L_is_on[1] == false)
            {
                Sprite_RD_array[1].sprite = S_on_array[1];
                L_is_on[1] = true;
            }
            else if (L_is_on[1] == true)
            {
                Sprite_RD_array[1].sprite = S_off_array[1];
                L_is_on[1] = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            if (L_is_on[2] == false)
            {
                Sprite_RD_array[2].sprite = S_on_array[2];
                L_is_on[2] = true;
            }
            else if (L_is_on[2] == true)
            {
                Sprite_RD_array[2].sprite = S_off_array[2];
                L_is_on[2] = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            if (L_is_on[3] == false)
            {
                Sprite_RD_array[3].sprite = S_on_array[3];
                L_is_on[3] = true;
            }
            else if (L_is_on[3] == true)
            {
                Sprite_RD_array[3].sprite = S_off_array[3];
                L_is_on[3] = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            if (L_is_on[4] == false)
            {
                Sprite_RD_array[4].sprite = S_on_array[4];
                L_is_on[4] = true;
            }
            else if (L_is_on[4] == true)
            {
                Sprite_RD_array[4].sprite = S_off_array[4];
                L_is_on[4] = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            if (L_is_on[5] == false)
            {
                Sprite_RD_array[5].sprite = S_on_array[5];
                L_is_on[5] = true;
            }
            else if (L_is_on[5] == true)
            {
                Sprite_RD_array[5].sprite = S_off_array[5];
                L_is_on[5] = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Shuffle(Sprite_RD_array, S_on_array, S_off_array, L_is_on);
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
