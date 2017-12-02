using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class WritingModule : MonoBehaviour {

    private Dictionary<string, string> _text_prompts = new Dictionary<string, string>
    {
        {"Are you doing fine ? A.Yes B.No", "Yes"},
        {"Is your work going well ? A.Yes B.No", "Yes"},
        {"Are you considering leaving us ? A.Yes B.No", "No"},
        {"Are you mocking me ? A.Yes B.No", "No"},
    };

    private KeyValuePair<string, string> _displayed;

    private System.Random _randomizer = new System.Random();

    private InputField _field;
    public Text BossText;
    public Text UserText;
    public float LettersSecond;

	// Use this for initialization
	void Start ()
	{
	    _field = GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {

	}


    void Awake()
    {
        DisplayBossQuestion();
    }


    IEnumerator SlowTextDisplay(string text)
    {
        foreach (char c in _displayed.Key)
        {
            BossText.text += c;
            yield return new WaitForSeconds(LettersSecond);
        }
    }

    public void DisplayBossQuestion()
    {
        StopAllCoroutines();
        _displayed = _text_prompts.ElementAt(_randomizer.Next(_text_prompts.Count));
        UserText.text = "YOU >: ";
        BossText.text = "BOSS >: ";
        StartCoroutine(SlowTextDisplay(BossText.text));
    }

    public void ValidateAnswer()
    {
        _field.text = "YOU >: ";
        Debug.Log(String.Format("Comparing \"{0}\" and \"{1}\"", UserText.text.Substring(7), _displayed.Value));
        if (UserText.text.Substring(7) == _displayed.Value)
            Debug.Log("OK !");
        else
            Debug.Log("False.");
        DisplayBossQuestion();
    }

    public void onEdit(string str)
    {
        if (!str.StartsWith("YOU >: "))
        {
            _field.text = "YOU >: ";
            _field.caretPosition = 7;
        }
    }
}
