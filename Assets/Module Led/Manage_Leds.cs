using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manage_Leds : MonoBehaviour
{
    #region "Variables"
    public KeyCode[] Keycode_array = new KeyCode[6];
    public int Temps = 10;
    public float Multiplicateur = 1.15f;
    public float Multiplicateur1 = 1;
    private GameObject mm;
    public SpriteRenderer[] SR_lamps_ex = new SpriteRenderer[6];
    public SpriteRenderer[] SR_lamps_array = new SpriteRenderer[6];
    public SpriteRenderer[] SR_number_array = new SpriteRenderer[6];
    public Sprite[] S_on_array = new Sprite[6];
    public Sprite[] S_off_array = new Sprite[6];
    private Sprite[] S_on_arrayEx = new Sprite[6];
    private Sprite[] S_off_arrayEx = new Sprite[6];
    public Sprite[] S_number_array = new Sprite[6];
    private Boolean[] L_is_on = new Boolean[6];
    private Boolean[] L_is_onEx = new Boolean[6];
    private System.Random random = new System.Random();
    private System.Random random2 = new System.Random();

    #endregion

    #region "Functions"

    private int RandomNumber(int min, int max)
    {
        int t = random.Next(min, max + 1);
        return t;
    }
    IEnumerator WaitForEnd()
    {
        int i = 0;
        float tmp = Temps * Multiplicateur1;

        tmp = (int)tmp;
        Multiplicateur1 /= Multiplicateur;
        while (i <= tmp)
        {
            yield return new WaitForSeconds(1);
            i++;
        }
        CheckPattern();
    }
    private void Shuffle_Ex()
    {

        int n = SR_lamps_ex.Length;
        for (int i = 0; i < n; i++)
        {
            int r = i + random2.Next(n - i);

            Sprite t2 = S_on_arrayEx[r];
            S_on_arrayEx[r] = S_on_arrayEx[i];
            S_on_arrayEx[i] = t2;

            t2 = S_off_arrayEx[r];
            S_off_arrayEx[r] = S_off_arrayEx[i];
            S_off_arrayEx[i] = t2;

            Boolean t4 = L_is_onEx[r];
            L_is_onEx[r] = L_is_onEx[i];
            L_is_onEx[i] = t4;

        }
        for (int i = 0; i < n; i++)
        {
            SR_lamps_ex[i].sprite = (L_is_on[i]) ? S_on_arrayEx[i] : S_off_arrayEx[i];
        }

    }

    private void Shuffle()
    {

        int n = SR_lamps_array.Length;
        for (int i = 0; i < n; i++)
        {
            int r = i + random.Next(n - i);

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

    void Randomize_Ex()
    {
        for (int i = 0; i < 6; i++) // Boucle pour check le tableau bool
        {
            L_is_onEx[i] = RandomNumber(0, 1) == 1;
            if (L_is_onEx[i] == true)
                SR_lamps_ex[i].sprite = S_on_arrayEx[i];
            else
                SR_lamps_ex[i].sprite = S_off_arrayEx[i];
        }
        StartCoroutine(WaitForEnd());
    }

    #region "Keyboard Inputs"

    void InputKeyborad()
    {
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

    void CheckPattern()
    {
        int match = 0;

        for (int i = 0; i < 6; i++)
        {
            if (L_is_on[i] != L_is_onEx[i])
                match = 1;
        }
        if (match == 1)
            mm.SendMessage("ReceiveValidation", "LAMPE FAILED");
        else if (match == 0)
            mm.SendMessage("ReceiveValidation", "LAMPE SUCCEED");
        for (int i = 0; i < 6; i++)
            {
                L_is_onEx[i] = false;
                SR_lamps_ex[i].sprite = S_off_arrayEx[i];
                L_is_on[i] = false;
                SR_lamps_array[i].sprite = S_off_array[i];
            }
        StartCoroutine(Spawn_Lamp());
    }

    IEnumerator Spawn_Lamp()
    {
        int temps = RandomNumber(1, 2);
        int i = 0; 

        while (i < temps)
        {
            yield return new WaitForSeconds(1);
            i++;
        }
        Randomize_Ex();
    }

    // Use this for initialization
    void Start()
    {
        mm = GameObject.Find("ModuleManager");
        for (int i = 0; i < 6; i++)
        {
            L_is_on[i] = false;
            L_is_onEx[i] = false;
        }
        S_on_arrayEx = S_on_array;
        S_off_arrayEx = S_off_array;
        StartCoroutine(Spawn_Lamp());
    }

    // Update is called once per frame
    void Update()
    {
        InputKeyborad();
    }
}
