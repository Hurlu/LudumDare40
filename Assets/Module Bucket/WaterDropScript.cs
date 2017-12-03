﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropScript : MonoBehaviour
{
    public float Speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = new Vector3(transform.position.x, transform.position.y - Speed, transform.position.z);
	    if (transform.position.y < -20)
	    {
	        Destroy(this.gameObject);
	    }
	}
}
