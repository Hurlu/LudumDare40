﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankLevel : MonoBehaviour {
    public int levelMax = 30;
    public float deltaDecrease = 1;
    public float deltaIncrease = 3; //WAIT FOR X SECOND BEFORE DECREMENTING AGAIN
    public Transform water;
    public SpriteRenderer light;
    public SpriteRenderer secondLight;
    public SpriteRenderer lampe;
    public SpriteRenderer brokenLampe;
    public SpriteRenderer screen;
    private float lastDecrease;
    private float lowWater = 0;
    private float highWater = 0;
    private int level;
    public GameObject mm;

    // Use this for initialization
    void Start ()
    {
        screen = GameObject.Find("black_curtain").GetComponent<SpriteRenderer>();
        mm = GameObject.Find("ModuleManager");
        lastDecrease = Time.time;
        level = levelMax / 2;
        MoveWater(-levelMax / 2);
	}

    void MoveWater(int level)
    {
        Vector3 tmp = water.position;
        tmp.y += level * 2.96f / 30f;
        water.position = tmp;
    }

    public void Decrease()
    {
        if (level > 0)
        {
            level -= 1;
            MoveWater(-1);
            if (level < 3)
            {
                lowWater = Time.time;
            }
        }
    }

    public void Increase()
    {
        if (level < levelMax)
        {
            int oldlevel = level;
            level += 1;
            MoveWater(1);
            if (level > 26 && oldlevel <= 26)
            {
                highWater = Time.time;
            }
            if (level > 3 && oldlevel <= 3)
            {
                light.enabled = true;
                secondLight.enabled = true;
                screen.enabled = false;
                Color c = screen.color;
                c.a = 0;
                screen.color = c;
            }
        }
        lastDecrease = Time.time + deltaIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastDecrease + deltaDecrease < Time.time)
        {
            lastDecrease = Time.time;
            Decrease();
        }
        if (level < 3)
        {
            if (Time.time - lowWater < 5)
            {
                light.enabled = !light.enabled;
                secondLight.enabled = !secondLight.enabled;
                screen.enabled = true;
                Color c = screen.color;
                c.a += 0.002f;
                screen.color = c;
            }
            else
            {
                Color c = screen.color;
                c.a = 1f;
                screen.color = c;
                light.enabled = false;
                secondLight.enabled = false;
            }
        }
    }
}
