using System.Collections;
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
    private float lastDecrease;
    private float lowWater = 0;
    private float highWater = 0;
    private int level;
    public GameObject mm;

    // Use this for initialization
    void Start () {
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
            }
            else
            {
                light.enabled = false;
                secondLight.enabled = false;
            }
        }
        if (level > 26)
        {
            if (Time.time - highWater < 5)
            {
                secondLight.enabled = !secondLight.enabled;
            }
            else
            {
                lampe.enabled = false;
                brokenLampe.enabled = true;
                secondLight.enabled = false;
            }
            if (Time.time - highWater < 10)
            {
                light.enabled = !light.enabled;
            }
            else
            {
                light.enabled = false;
                mm.SendMessage("ReceiveValidation", "CRANK FAILED");
            }
        }
    }
}
