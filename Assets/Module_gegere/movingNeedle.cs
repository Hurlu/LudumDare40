using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingNeedle : MonoBehaviour {

    public int ChangeDirectionSpeed;
    public int Speed;
    int takeANewDirection;
    Vector3 direction;
    private AudioSource lecteur;
    public int loosing;
    System.DateTime sec;
    bool isPlaying;
    public float minClamp;
    public float maxClamp;

	// Use this for initialization
	void Start () {
        takeANewDirection = ChangeDirectionSpeed;
        sec = System.DateTime.Now;
        isPlaying = false;
        lecteur = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (loosing == 0)
	        GameObject.Find("ModuleManager").SendMessage("ReceiveValidation", "GeigerFail");
	    if (takeANewDirection == ChangeDirectionSpeed)
        {
            direction = (Random.Range(0, 2) == 0) ? Vector3.back : Vector3.forward;
        }

        if (takeANewDirection % Speed == 0)
            transform.Rotate(direction);

        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.back);
            takeANewDirection = 0;
        }

        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.forward);
            takeANewDirection = 0;
        }

        if (sec.AddSeconds(1) < System.DateTime.Now)
        {
            sec = System.DateTime.Now;
            if (isPlaying)
                loosing--;
            else if (loosing < 3)
                loosing++;
        }

        float tmp = gameObject.transform.localEulerAngles.z;
        if (tmp > 180)
            tmp -= 360;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.Clamp(tmp, minClamp, maxClamp));
        takeANewDirection++;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isPlaying == false && other.name == "limit")
        {
            lecteur.Play();
            isPlaying = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "limit")
        {
            isPlaying = false;
            lecteur.Stop();
        }
    }
}
