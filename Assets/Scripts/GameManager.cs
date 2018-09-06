using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // Use this for initialization

    public GameObject MonkeyLeft;
    bool monkeyLeftAlive = false;
    public GameObject MonkeyMid;
    bool monkeyMidAlive = false;
    public GameObject MonkeyRight;
    bool monkeyRightAlive = false;
    public GameObject Player;

	void Start () {
        NewMonkey();
	}

    void NewMonkey(){
        if(monkeyLeftAlive == false) {
            GameObject newMonkey = Instantiate(MonkeyLeft);
            newMonkey.GetComponentInChildren<MonkeyController>().gameManager = this;
            monkeyLeftAlive = true;
            return;
        }
        if (monkeyMidAlive == false)
        {
            GameObject newMonkey = Instantiate(MonkeyMid);
            newMonkey.GetComponentInChildren<MonkeyController>().gameManager = this;
            monkeyMidAlive = true;
            return;
        }
        if (monkeyRightAlive == false)
        {
            GameObject newMonkey = Instantiate(MonkeyRight);
            newMonkey.GetComponentInChildren<MonkeyController>().gameManager = this;
            monkeyRightAlive = true;
            return;
        }
    }

    public bool HitCheck(GameObject monkey){
        if (monkey.getMonkeyPosition)
        {
            return false;
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
