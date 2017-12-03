using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crankMovement : MonoBehaviour {

    public float initialSpeed = 0.1f;
    public float accelDelta = 0.01f;
    public float accelDeltaTime = 0.1f;
    public float decelDelta = 0.01f;
    public float decelDeltaTime = 0.1f;
    public float maxSpeed = 1f;
    public float maxDistance = 3f;
    public Transform pivot;
    private Vector3[] positions = new Vector3[64];
    private bool isCrankDown = false;
    private float nextAccel;
    private float nextDecel;
    private float speed = 0;
    private float moveLeft = 0;
    private int posIdx;
    private Vector3 mousePos;

	// Use this for initialization
	void Start () {
        float r = Vector3.Distance(transform.position, pivot.position);
        for (int i = 0; i < 64; i++)
        {
            positions[i] = Quaternion.AngleAxis(360f / 64f * i, Vector3.forward) * (Vector3.right * r);
        }
        MovetoNearest(transform.position);
    }

    public bool isRunning()
    {
        return speed > 0;
    }

    private void OnMouseDown()
    {
        isCrankDown = true;
        speed = initialSpeed;
        nextAccel = Time.time + accelDeltaTime;
    }

    private void OnMouseUp()
    {
            ToggleOff();
    }

    private void ToggleOff()
    {
        if (isCrankDown)
        {
            isCrankDown = false;
            nextDecel = Time.time + decelDeltaTime;
        }
    }

    private void Accelerate()
    {
        if (isCrankDown)
        {
            if (nextAccel < Time.time && speed < maxSpeed)
            {
                nextAccel = Time.time + accelDeltaTime;
                speed += accelDelta;
            }
        }
        else
        {
            if (nextDecel < Time.time && speed > 0)
            {
                nextDecel = Time.time + decelDeltaTime;
                speed -= decelDelta;
            }
        }
    }

    private void Move()
    {
        if (isCrankDown)
        {
            MovetoNearest(speed);
        }
        else
            MovetoNearest(speed);
    }

    private int addToIndex(int idx, int delta)
    {
        idx = idx + delta;
        if (idx < 0)
            idx += 64;
        idx %= 64;
        return idx;
    }

    private void MovetoNearest(float dist)
    {
        Vector3 pos = transform.position;
        int idx = posIdx;
        float deltaDist = 0f;

        dist += moveLeft;
        while (dist > 0)
        {
            int tmpPos = addToIndex(idx, -1);
            deltaDist = Vector3.Distance(pos, positions[tmpPos]);
            dist -= deltaDist;
            idx = tmpPos;
            pos = positions[idx];
        }
        if (deltaDist / 2 < dist * -1 || deltaDist == 0)
        {
            moveLeft = dist;
            posIdx = idx;
            transform.position = pos;
        }
        else
        {
            moveLeft = deltaDist + dist;
            posIdx = addToIndex(idx, 1);
            transform.position = positions[posIdx];
        }
    }

    private void MovetoNearest(Vector3 position)
    {
        float minDis = Vector3.Distance(position, positions[0]);
        int minIdx = 0;
        for (int i = 1; i < 64; i++)
        {
            float dis = Vector3.Distance(position, positions[i]);
            if (dis < minDis)
            {
                minIdx = i;
                minDis = dis;
            }
        }
        transform.position = positions[minIdx];
        posIdx = minIdx;
    }

    private void checkDistance()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = transform.position.z;
        float t = Vector3.Distance(mousePos, transform.position);
        if (t > maxDistance)
            ToggleOff();
    }

    // Update is called once per frame
    void Update () {
        checkDistance();
        Accelerate();
        Move();
	}
}
