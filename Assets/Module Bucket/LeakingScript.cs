using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LeakingScript : MonoBehaviour
{

    public float LeakFrequency;
    public GameObject WaterDrop;

    public Vector2 LeakingStart;
    private GameObject _currentDrop = null;

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(LeakingRoutine());
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

    IEnumerator LeakingRoutine()
    {
        while (true)
        {
            _currentDrop = Instantiate(WaterDrop);
            WaterDrop.transform.position = LeakingStart;
            _currentDrop.transform.SetParent(transform);
            _currentDrop.transform.position =
               new Vector3(_currentDrop.transform.position.x, _currentDrop.transform.position.y, transform.position.z);
            yield return new WaitForSeconds(LeakFrequency);
        }

    }
}
