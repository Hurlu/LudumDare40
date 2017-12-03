using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoletteModule : MonoBehaviour
{

    public List<int> PivotList = new List<int>{0};
    private int rotateIdx;
    public float rotaSpeed;
    public float rotaWait;
    private bool isRotating = false;

	// Use this for initialization
	void Start () {
		if (PivotList.Any(piv => piv < -360 || piv > 360))
		    throw new Exception("Should not have values below -360 or greater than 360 in pivot list !");
	}

    IEnumerator rotateTo(int rotation)
    {
        isRotating = true;
        var speed = rotaSpeed;
        Debug.Log("Rotating to " + rotation);
        var new_rota = new Quaternion();
        new_rota.eulerAngles = new Vector3(0, 0, rotation);
        while (transform.rotation.eulerAngles.z < rotation - 1 || transform.rotation.eulerAngles.z > rotation + 1)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, new_rota, speed);
            speed += rotaSpeed;
            yield return new WaitForSeconds(rotaWait);
            Debug.LogFormat("Current rota == {0}, rotation to achieve == {1}", transform.rotation.eulerAngles.z, rotation);
        }
        Debug.Log("Finished rotating !");
        isRotating = false;
    }

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.W) && !isRotating)
	    {
	        rotateIdx = (rotateIdx + 1) % PivotList.Count;
	        Debug.LogFormat("New values from W are Pivotlist[{0}] = {1}", rotateIdx, PivotList[rotateIdx]);
	        StartCoroutine(rotateTo(PivotList[rotateIdx]));
	    }
		else if (Input.GetKeyDown(KeyCode.C) && !isRotating)
	    {
	        rotateIdx = (rotateIdx == 0) ? PivotList.Count - 1 : rotateIdx - 1;
	        Debug.LogFormat("New values from C are Pivotlist[{0}] = {1}", rotateIdx, PivotList[rotateIdx]);
	        StartCoroutine(rotateTo(PivotList[rotateIdx]));
	    }
	}

}