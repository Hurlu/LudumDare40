using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ALevel
{
    public int level;
    public bool completion;
    public abstract void GetValidation(string message);

    protected void GameOver()
    {
        SceneManager.LoadScene(1);
    }
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
            _buttonpress_validations++;
        }

        if (message == "LAMPE FAILED")
        {
            _buttonpress_failures++;
        }

        if (message == "VANNE FAILED")
        {
            _buttonpress_failures++;
        }

        if (_buttonpress_validations >= 3)
        {
            completion = true;
        }

        if (_buttonpress_failures >= 2)
        {
            GameOver();
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
        Debug.Log("Received this for LV2 : " + message);
        if (message == "LAMPE SUCCEED" || message == "ButtonGood")
        {
            _buttonpress_validations++;
        }

        if (message == "LAMPE FAILED" || message == "ButtonBad")
        {
            Debug.Log("Ouhla!");
            _buttonpress_failures++;
        }

        if (message == "VANNE FAILED")
        {
            _buttonpress_failures++;
        }

        if (message == "CRANK FAILED")
        {
            _buttonpress_failures++;
        }

        if (message == "BOSS FAILED")
        {
            _buttonpress_failures++;
        }

        if (_buttonpress_validations >= 3)
        {
            completion = true;
        }

        if (_buttonpress_failures >= 2)
        {
            GameOver();
            completion = true;
        }

    }
}

public class Level3 : ALevel
{
    private int _button, _led, _geiger, _ventilo, _bucket = 0;

    public Level3()
    {
        level = 3;
        completion = false;
    }

    public override void GetValidation(string message)
    {
        switch (message)
        {
            case "ButtonGood":
                _button++;
                break;
            case "ButtonBad":
                _button--;
                break;
            case "LAMPE SUCCEED":
                _led++;
                break;
            case "LAMPE FAILED":
                _led--;
                break;
            case "GeigerFail":
                _geiger--;
                break;
            case "VANNE FAILED":
                _ventilo--;
                break;
            case "BucketSuccess":
                _bucket++;
                break;
            case "BucketFail":
                _bucket--;
                break;
        }
        if (_ventilo < 0 || _led < -2 || _button < -1 || _bucket < -2 || _geiger < 0)
            GameOver();
        if (_led > 3 && _button > 4 && _bucket > 2)
            completion = true;
    }
}

public class ModuleManager : MonoBehaviour
{

    public enum Modules
    {
        BUCKET = 0,
        BUTTON = 1,
        LED,
        MOLETTE,
        PARLOTTE,
        CRANK,
        VENTILO,
        GEIGER
    }

    public List<GameObject> _modules;

    private ALevel _currentLevel;

    private Dictionary<string, GameObject> _currentModules = new Dictionary<string, GameObject>();
    private GameObject _canvas;

	// Use this for initialization
	void Start () {
	    _currentLevel = new Level1();
		_currentModules.Add("Crank", Instantiate(_modules[(int)Modules.CRANK]));
	    _currentModules["Crank"].transform.SetParent(transform);
	    _currentModules.Add("Led", Instantiate(_modules[(int)Modules.LED]));
	    _currentModules["Led"].transform.SetParent(transform);
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
            _currentModules.Add("Button", Instantiate(_modules[(int)Modules.BUTTON]));
            _currentModules["Button"].transform.SetParent(transform);
            _currentModules.Add("Boss", Instantiate(_modules[(int)Modules.PARLOTTE]));
            _currentModules["Boss"].transform.SetParent(transform);
        }
    }

    void UpdateLevel2()
    {
        if (_currentLevel.completion)
        {
            _currentLevel = null;
            _currentLevel = new Level3();
            _currentModules.Add("Geiger", Instantiate(_modules[(int)Modules.GEIGER]));
            _currentModules["Geiger"].transform.SetParent(transform);
            _currentModules.Add("Ventilo", Instantiate(_modules[(int)Modules.VENTILO]));
            _currentModules["Ventilo"].transform.SetParent(transform);
            _currentModules.Add("Bucket", Instantiate(_modules[(int)Modules.BUCKET]));
            _currentModules["Bucket"].transform.SetParent(transform);
        }
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
