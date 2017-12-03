using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

public class ButtonModule : MonoBehaviour
{

    private Dictionary<char, KeyCode> _keyCodesMap = new Dictionary<char, KeyCode>
    {
        {'K', KeyCode.K},
        {'J', KeyCode.J},
        {'L', KeyCode.L},
        {'M', KeyCode.M}
    };

    private System.Random _randomizer = new System.Random();

    private char _charUsed;
    private KeyCode _keyUsed;
    private Text _text;

	// Use this for initialization
	void Start ()
	{
	    Reset();
	}


    void Reset()
    {
        _charUsed = _keyCodesMap.ElementAt(_randomizer.Next(_keyCodesMap.Count)).Key;
        _keyUsed = _keyCodesMap[_charUsed];
        _text = GetComponent<Text>();
        _text.text = _charUsed + "";
    }

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(_keyUsed))
	        StartCoroutine(HideNResetRoutine());

	}

    IEnumerator HideNResetRoutine()
    {
        Debug.Log("Starting destruction");
        while (true)
        {
            var old_scale = transform.localScale;
            transform.localScale = Vector3.zero;
            GameObject.Find("ModuleManager").SendMessage("ReceiveValidation", "Button");
            yield return new WaitForSeconds(4);
            Reset();
            transform.localScale = old_scale;

            yield break;
        }

    }


}
