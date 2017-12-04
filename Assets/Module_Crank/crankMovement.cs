using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crankMovement : MonoBehaviour {
    
    public float decelDelta = 0.1f;
    public float decelDeltaTime = 0.3f;
    public CrankLevel level;
    public Transform pivot;
    public Transform parent;
    private Vector3[] positions = new Vector3[64];
    private bool isCrankDown = false;
    private float nextDecel;
    private float speed = 0;
    private float moveLeft = 0;
    private int posIdx = -1;
    private Vector3 mousePos;
    private int deltaMovement = 0;
    private float dist;
    private float[] last_speed = new float[10];
    private int advencement = 0;
    private Vector3 oldMousePos;

	// Use this for initialization
	void Start () {
        float r = Vector3.Distance(transform.position, pivot.position);
        for (int i = 0; i < 64; i++)
        {
            positions[i] = Quaternion.AngleAxis(360f / 64f * i, Vector3.forward) * (Vector3.right * r);
            positions[i].z = 0;
        }
        for (int i = 0; i < last_speed.Length; i++)
        {
            last_speed[i] = 0;
        }
        dist = transform.localPosition.z;
        MovetoNearest(transform.position);
        parent.Rotate(new Vector3(0, 0, -90));
        speed = 0;
    }

    public bool isRunning()
    {
        return speed > 0;
    }

    private void OnMouseDown()
    {
        isCrankDown = true;
        oldMousePos = Input.mousePosition;
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
        if (!isCrankDown && nextDecel < Time.time && Mathf.Abs(speed) > 0.01)
        {
            nextDecel = Time.time + decelDeltaTime;
            if (speed > 0)
                speed -= Mathf.Abs(speed) > decelDelta ? decelDelta : speed;
            else
                speed += Mathf.Abs(speed) > decelDelta ? decelDelta : speed;
        }
    }

    private void Move()
    {
        if (isCrankDown)
        {
            Vector3 dir = mousePos - pivot.position;
            dir = dir.normalized;
            Vector3 tmp = dir * 2.3f;
            MovetoNearest(tmp);
        }
        else
        {
            MovetoNearest();
        }
    }

    private int addToIndex(int idx, int delta)
    {
        idx = idx + delta;
        if (idx < 0)
            idx += 64;
        idx %= 64;
        return idx;
    }

    /*private void MovetoNearest(float dist)
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
            parent.Rotate(new Vector3(0, 0, (float)(idx - posIdx) * 360.0f / 64f));
            deltaMovement += Mathf.Abs(idx - posIdx);
            moveLeft = dist;
            posIdx = idx;
        }
        else
        {
            parent.Rotate(new Vector3(0, 0, (float)(addToIndex(idx, 1) - posIdx) * 360.0f / 64f));
            deltaMovement += Mathf.Abs(addToIndex(idx, 1) - posIdx);
            moveLeft = deltaDist + dist;
            posIdx = addToIndex(idx, 1);
            pos = positions[posIdx];
        }
        transform.position = positions[posIdx];
        if (deltaMovement > 128)
        {
            deltaMovement -= 128;
            level.Increase();
        }
    }*/

    private void MovetoNearest()
    {
        int newIdx = posIdx - (int)speed;
        advencement += (int)speed;
        parent.Rotate(new Vector3(0, 0, -(float)(posIdx - newIdx) * 360.0f / 64));
    }

    private void MovetoNearest(Vector3 pos)
    {
        float minDis = Vector3.Distance(pos, positions[0]);
        int minIdx = 0;
        for (int i = 1; i < 64; i++)
        {
            float dis = Vector3.Distance(pos, positions[i]);
            if (dis < minDis)
            {
                minIdx = i;
                minDis = dis;
            }
        }
        parent.Rotate(new Vector3(0, 0, -(float)(posIdx - minIdx) * 360.0f / 64));
        for (int i = 0; i < last_speed.Length - 1; i++)
        {
            last_speed[i + 1] = last_speed[i];
        }
        for (int i = 0; i < last_speed.Length; i++)
            speed += last_speed[i];
        last_speed[0] = 0;
       while (posIdx != minIdx)
        {
            posIdx = addToIndex(posIdx, -1);
            last_speed[0] += 1;
        }
        if (last_speed[0] > 32)
            last_speed[0] -= 64;
        speed /= last_speed.Length;
        advencement += (int)speed;
        posIdx = minIdx;
    }

    private void checkDistance()
    {
        mousePos = Input.mousePosition;
        Vector3 dir;
        if (Vector3.Distance(mousePos, oldMousePos) > 0.2f)
        {
            dir = mousePos - oldMousePos;
            dir = dir.normalized;
        }
        else
        {
            dir = new Vector3(0, 0, 0);
        }
        mousePos = oldMousePos + dir * speed;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = transform.position.z;
        float distance_pivot_mouse = Vector3.Distance(mousePos, pivot.position);
        float distance_handle_pivot = Vector3.Distance(transform.position, pivot.position);
        oldMousePos = Input.mousePosition;
    }

    private void checkAdvencement()
    {
        if (advencement > 64)
        {
            advencement -= 64;
            level.Increase();
        }
        if (advencement < -64)
        {
            level.Increase();
            advencement += 64;
        }

    }
        // Update is called once per frame
    void Update () {
        checkDistance();
        Accelerate();
        Move();
        checkAdvencement();
    }
}
