using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {

    public Sprite idleLeft, idleMid, idleRight;
    public Sprite hitLeft, hitMid, hitRight;
    public PlayerController playerController;
    public float hitTime = 1.0f;
    // Use this for initialization

    bool pause = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    if (pause)
        return;

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

    public void HitLeft(){
        StartCoroutine(HitLeftDelay());
    }

    IEnumerator HitLeftDelay() {
        Debug.Log("Sprite should change");
        playerController.GetComponent<SpriteRenderer>().sprite = hitLeft;
        pause = true;
        yield return new WaitForSeconds(hitTime);
        pause = false;
    }

    public void HitMid(){
        StartCoroutine(HitMidDelay());
    }

    IEnumerator HitMidDelay() {
        Debug.Log("Sprite should change");
        playerController.GetComponent<SpriteRenderer>().sprite = hitMid;
        pause = true;
        yield return new WaitForSeconds(hitTime);
        pause = false;
    }

    public void HitRight() {
        StartCoroutine(HitRightDelay());
    }

    IEnumerator HitRightDelay(){
        Debug.Log("Sprite should change");
        playerController.GetComponent<SpriteRenderer>().sprite = hitRight;
        pause = true;
        yield return new WaitForSeconds(hitTime);
        pause = false;

    }
}
