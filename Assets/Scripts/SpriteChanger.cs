using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {

    public Sprite idleLeft, idleMid, idleRight;
    public Sprite hitLeft, hitMid, hitRight;
    public PlayerController playerController;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (playerController.GetPosition() == 0) {
            playerController.GetComponent<SpriteRenderer>().sprite = idleLeft;
        }
        if (playerController.GetPosition() == 1)
        {
            playerController.GetComponent<SpriteRenderer>().sprite = idleMid;
        }
        if (playerController.GetPosition() == 2)
        {
            playerController.GetComponent<SpriteRenderer>().sprite = idleRight;
        }
	}
}
