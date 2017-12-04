using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.VersionControl;
using UnityEngine;

public abstract class ALevel
{
    public int level;
    public bool completion;
    public abstract void GetValidation(string message);
}

public class Level1 :  ALevel
{
    private int _buttonpress_validations = 0;
    private int _buttonpress_failures = 0;

    public Level1()
    {
        level = 1;
        completion = false;
    }

    public override void GetValidation(string message)
    {
        if (message == "LAMPE SUCCEED")
        {
            Debug.Log("Getting validation for Lampe !");
            _buttonpress_validations++;
        }

        if (message == "LAMPE FAILED")
        {
            Debug.Log("Getting failure for Lampe !");
            _buttonpress_failures++;
        }

        if (message == "VANNE FAILED")
        {
            Debug.Log("Getting failure for Lampe !");
            _buttonpress_failures++;
        }

        if (_buttonpress_validations >= 3)
        {
            Debug.Log("Completion is true !");
            completion = true;
        }

        if (_buttonpress_failures >= 2)
        {
            Debug.Log("Failure !");
            //LOAD GAME OVER
            completion = true;
        }

    }
}

public class Level2 : ALevel
{
    private int _buttonpress_validations = 0;
    private int _buttonpress_failures = 0;

    public Level2()
    {
        level = 2;
        completion = false;
    }

    public override void GetValidation(string message)
    {
        Debug.Log("Validation == " + _buttonpress_validations);
        Debug.Log("Validation == " + _buttonpress_failures);
        if (message == "LAMPE SUCCEED")
        {
            Debug.Log("Getting validation for Lampe !");
            _buttonpress_validations++;
        }

        if (message == "LAMPE FAILED")
        {
            Debug.Log("Getting failure for Lampe !");
            _buttonpress_failures++;
        }

        if (message == "VANNE FAILED")
        {
            Debug.Log("Getting failure for Lampe !");
            _buttonpress_failures++;
        }

        if (message == "CRANK FAILED")
        {
            Debug.Log("Getting failure for Crank !");
            _buttonpress_failures++;
        }

        if (message == "BOSS FAILED")
        {
            Debug.Log("Getting failure for Boss !");
            _buttonpress_failures++;
        }

        if (_buttonpress_validations >= 3)
        {
            Debug.Log("Completion is true !");
            completion = true;
        }

        if (_buttonpress_failures >= 2)
        {
            Debug.Log("Failure !");
            //LOAD GAME OVER
            completion = true;
        }

    }
}


public class ModuleManager : MonoBehaviour
{

    public enum Modules
    {
        BUCKET = 0,
        BUTTON = 1,
        LED = 2,
        MOLETTE = 3,
        PARLOTTE = 4,
        WRITING = 5,
        CRANK = 6,
        VENTILO = 7,
    }

    public List<GameObject> _modules;

    private ALevel _currentLevel;

    private Dictionary<string, GameObject> _currentModules = new Dictionary<string, GameObject>();
    private GameObject _canvas;

	// Use this for initialization
	void Start () {
	    _currentLevel = new Level1();
/*		_currentModules.Add("Crank", Instantiate(_modules[(int)Modules.CRANK]));
	    _currentModules["Crank"].transform.SetParent(transform);*/
	}
	
    // Update is called once per frame
    void Update () {
        switch (_currentLevel.level)
        {
            case 1:
                UpdateLevel1();
                break;
            case 2:
                UpdateLevel2();
                break;
            case 3:
                UpdateLevel3();
                break;
            case 4:
                UpdateLevel4();
                break;
            case 5:
                UpdateLevel5();
                break;
            default:
                Debug.Log("No level update launched");
                break;

        }
    }

    public void ReceiveValidation(string message)
    {
        _currentLevel.GetValidation(message);
    }

    void UpdateLevel1()
    {
        if (_currentLevel.completion)
        {
            Debug.Log("Level 1 réussi !");
            _currentLevel = null;
            _currentLevel = new Level2();
        }
    }

    void UpdateLevel2()
    {

    }

    void UpdateLevel3()
    {

    }

    void UpdateLevel4()
    {

    }

    void UpdateLevel5()
    {

    }
}
