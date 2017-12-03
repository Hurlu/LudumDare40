using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage_ventilo : MonoBehaviour
{
    public float pressure_speed;
    private float unpress_speed;
    public GameObject NeedlePivot;
    public SpriteRenderer VaporRender;
    public SpriteRenderer HandleRender;
    public Sprite pressureSprite;
    public Sprite unpressSprite;
    public Vector3 unpressSpritePos;
    public Vector3 pressSpritePos;

    private bool releasing = false;

    // Use this for initialization
    void Start()
    {
        unpress_speed = pressure_speed * 2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(NeedlePivot.transform.eulerAngles);

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Release");
            ReleasePressure();
        }
        else
        {
            Debug.Log("Accu");
            AccumulatePressure();
        }
    }

    void ReleasePressure()
    {
        if (!releasing)
        {
            releasing = true;
            HandleRender.sprite = unpressSprite;
            HandleRender.transform.position = unpressSpritePos;
            VaporRender.enabled = true;
        }
        if (NeedlePivot.transform.localEulerAngles.z < 122 || NeedlePivot.transform.localEulerAngles.z > 240)
        {
            NeedlePivot.transform.localEulerAngles =
                new Vector3(NeedlePivot.transform.localEulerAngles.x, NeedlePivot.transform.localEulerAngles.y,
                    NeedlePivot.transform.localEulerAngles.z + unpress_speed);
        }
    }

    void AccumulatePressure()
    {
        if (releasing)
        {
            releasing = false;
            HandleRender.sprite = pressureSprite;
            HandleRender.transform.position = pressSpritePos;
            VaporRender.enabled = false;
        }
        if (NeedlePivot.transform.localEulerAngles.z < 240 || NeedlePivot.transform.localEulerAngles.z > 250)
        {
            NeedlePivot.transform.localEulerAngles =
                new Vector3(NeedlePivot.transform.localEulerAngles.x, NeedlePivot.transform.localEulerAngles.y,
                    NeedlePivot.transform.localEulerAngles.z - pressure_speed);
        }
    }
}
