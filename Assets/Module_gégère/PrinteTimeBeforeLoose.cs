using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinteTimeBeforeLoose : MonoBehaviour {

    public GameObject loosing;
    public Sprite one;
    public Sprite two;
    public Sprite three;

    private SpriteRenderer sprite;
        // Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (loosing.GetComponent<movingNeedle>().loosing)
        {
            case 1:
                sprite.sprite = one;
                break;
            case 2:
                sprite.sprite = two;
                break;
            default:
                sprite.sprite = three;
                break;
        }
    }
}
