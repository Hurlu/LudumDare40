using System;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class BucketScript : MonoBehaviour
{

    public int maxFill;
    private int _currentFill = 0;

    public Sprite EmptyBucket;
    public Sprite FullBucket;


    private float screenPoint = 10;
    private Vector3 offset;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown() {

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    void Overflow()
    {
        Debug.Log("Oh noes, it overflowes !");
    }

    void AddDrop()
    {
        if (_currentFill == maxFill)
            this.Overflow();
        _currentFill++;
        if (_currentFill == maxFill)
            GetComponent<SpriteRenderer>().sprite = FullBucket;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.StartsWith("WaterDrop"))
        {
            AddDrop();
            Destroy(other.gameObject);
        }
        else if (other.name == "WaterHole")
        {
            _currentFill = 0;
            GetComponent<SpriteRenderer>().sprite = EmptyBucket;
        }
    }
}
