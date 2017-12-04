using System.Collections;
using UnityEngine;

public class BucketScript : MonoBehaviour
{

    public int maxFill;
    private int _currentFill = 0;

    public Sprite EmptyBucket;
    public Sprite FullBucket;
    public Sprite OverFlowBucket;
    public Sprite SpillingBucket;
    public float DropDiseappearance;

    private float screenPoint = 10;
    private Vector3 offset;

    private Vector3 base_position;
    private AudioSource ploc;

	// Use this for initialization
	void Start ()
	{
	    ploc = GetComponent<AudioSource>();
	    base_position = transform.position;
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

    void OnMouseUp()
    {
        transform.position = base_position;
    }

    void Overflow()
    {
        GetComponent<SpriteRenderer>().sprite = OverFlowBucket;
        GameObject.Find("ModuleManager").SendMessage("ReceiveValidation", "BucketFail");
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
        if (other.name == "WaterHole" && _currentFill > 2)
        {
            GameObject.Find("ModuleManager").SendMessage("ReceiveValidation", "BucketSuccess");
            _currentFill = 0;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name.StartsWith("WaterDrop") && other.transform.position.y < DropDiseappearance)
        {
            AddDrop();
            ploc.Play();
            Destroy(other.gameObject);
        }
    }
}
