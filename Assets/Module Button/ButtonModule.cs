using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class ButtonModule : MonoBehaviour
{

    public List<KeyCode> KeyCodes;
    public List<Sprite> KeySprites;

    private System.Random _randomizer = new System.Random();

    private char _charUsed;
    private KeyCode _keyUsed;
    private float timer;

    public float PushDuration;
    public float ElapsingTime;

    public SpriteRenderer ClapetRenderer;
    public SpriteRenderer ButtonRenderer;
    public SpriteRenderer LetterRenderer;

    public Sprite ClosedClapet;
    public Sprite OpenClapet;

    public Sprite PushedButton;
    public Sprite StandbyButton;




	// Use this for initialization
	void Start ()
	{
	    DisplayButton();
	}

	// Update is called once per frame
	void Update ()
	{
	    int result;
	    if ((result = ButtonPressed()) != 0)
	    {
	        StartCoroutine(HideButton(result));
	    }
	    else if (!ButtonRenderer.enabled)
	    {
	        timer += Time.deltaTime;
	        if (timer > ElapsingTime)
	            DisplayButton();
	    }

	}

    IEnumerator HideButton(int result)
    {
        var message = (result == 1) ? "ButtonGood" : "ButtonBad";
        GameObject.Find("ModuleManager").SendMessage("ReceiveValidation", message);
        while (true)
        {
            ButtonRenderer.sprite = PushedButton;
            yield return new WaitForSeconds(PushDuration);
            LetterRenderer.enabled = false;
            ClapetRenderer.sprite = ClosedClapet;
            ButtonRenderer.enabled = false;
            ButtonRenderer.sprite = StandbyButton;
            yield break;
        }
    }

    void DisplayButton()
    {
        timer = 0;
        ClapetRenderer.sprite = OpenClapet;
        ButtonRenderer.enabled = true;
        LetterRenderer.enabled = true;
        var random = _randomizer.Next(KeyCodes.Count);
        _keyUsed = KeyCodes[random];
        LetterRenderer.sprite = KeySprites[random];
    }


    int ButtonPressed()
    {
        foreach (var key in KeyCodes)
            if (Input.GetKeyDown(key))
                return (key == _keyUsed) ? 1 : 2;
        return 0;
    }
}
