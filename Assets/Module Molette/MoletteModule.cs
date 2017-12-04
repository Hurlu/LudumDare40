using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoletteModule : MonoBehaviour
{

    public List<int> PivotList = new List<int>{0};    
    public float rotaSpeed;
    public float rotaWait;
    private bool isRotating = false;
    public int StartInList;

    public List<Vector2> BubblePositions;
    private List<GameObject> _bubbles = new List<GameObject>();
    public GameObject BubblePrefab;

    private System.Random _randomizer = new System.Random();

	// Use this for initialization
	void Start ()
	{
	    for (int idx = 0; idx < BubblePositions.Count; idx++)
	    {
	        var new_bubble = Instantiate(BubblePrefab);
	        BubblePrefab.transform.position = BubblePositions[idx];
	        BubblePrefab.GetComponent<SpriteRenderer>().enabled = false;
	        _bubbles.Add(new_bubble);
	    }
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
        _bubbles[StartInList].GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Finished rotating !");
        isRotating = false;
    }

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.C) && !isRotating)
	    {
	        StartInList = (StartInList + 1) % PivotList.Count;
	        Debug.LogFormat("New values from W are Pivotlist[{0}] = {1}", StartInList, PivotList[StartInList]);
	        StartCoroutine(rotateTo(PivotList[StartInList]));
	    }
		else if (Input.GetKeyDown(KeyCode.W) && !isRotating)
	    {
	        StartInList = (StartInList == 0) ? PivotList.Count - 1 : StartInList - 1;
	        Debug.LogFormat("New values from C are Pivotlist[{0}] = {1}", StartInList, PivotList[StartInList]);
	        StartCoroutine(rotateTo(PivotList[StartInList]));
	    }
	}


    public void SpawnRandomBubble()
    {
        _bubbles[_randomizer.Next(_bubbles.Count)].GetComponent<SpriteRenderer>().enabled = true;
    }
}