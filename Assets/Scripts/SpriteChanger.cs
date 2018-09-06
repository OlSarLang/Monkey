using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {

    public Sprite idleLeft, idleMid, idleRight;
    public Sprite hitLeft, hitMid, hitRight;
    public PlayerController playerController;
    public float hitTime = 0.2f;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (playerController.GetPosition() == 0) {
            playerController.GetComponent<SpriteRenderer>().sprite = idleLeft;
            Debug.Log("idleLeft");
        }
        if (playerController.GetPosition() == 1)
        {
            playerController.GetComponent<SpriteRenderer>().sprite = idleMid;
            Debug.Log("idleMid");
        }
        if (playerController.GetPosition() == 2)
        {
            playerController.GetComponent<SpriteRenderer>().sprite = idleRight;
            Debug.Log("idleRight");
        }
	}

    public void HitLeft()
    {
        playerController.GetComponent<SpriteRenderer>().sprite = hitLeft;
        hitTime = Time.time;
        playerController.GetComponent<SpriteRenderer>().sprite = idleLeft;
    }
    public void HitMid()
    {
        playerController.GetComponent<SpriteRenderer>().sprite = hitMid;
        hitTime = Time.time;
        playerController.GetComponent<SpriteRenderer>().sprite = idleMid;
    }
    public void HitRight()
    {
        playerController.GetComponent<SpriteRenderer>().sprite = hitRight;
        hitTime = Time.time;
        playerController.GetComponent<SpriteRenderer>().sprite = idleRight;
    }
}
