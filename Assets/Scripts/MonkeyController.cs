using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour {

    public GameManager gameManager;
    public List<GameObject> positions = new List<GameObject>();
    int currentPosition = 0;
    public float moveDelay = 1.0f;
    float lastMoveTime;

	// Use this for initialization
	private void Start () {
        transform.position = positions[currentPosition].transform.position;

        lastMoveTime = Time.time;

        StartCoroutine(Move());
	}

    private IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            StartCoroutine(MoveToNextPosition());
        }
    }

    IEnumerator MoveToNextPosition()
    {
        currentPosition++;
        if(currentPosition >= positions.Count)
        {
            currentPosition = 0;
        }

        transform.position = positions[currentPosition].transform.position;
        lastMoveTime = Time.time;

        yield return null;
        if (gameManager.HitCheck(gameObject)){
            Die();
        }else{
            Debug.Log("Continue!");
        }
    }

    void Die()
    {
        Destroy(transform.parent.gameObject);
    }
	
	// Update is called once per frame
    private void Update () {
		
	}

    private int getMonkeyPosition()
    {
        return currentPosition;
    }
}
