using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // Use this for initialization
    public MonkeyController monkeyControllerLeft;
    public MonkeyController monkeyControllerMid;
    public MonkeyController monkeyControllerRight;
    public PlayerController playerController;
    public SpriteChanger spriteChanger;

    public GameObject newMonkeyLeft;
    bool monkeyLeftAlive = false;
    public GameObject newMonkeyMid;
    bool monkeyMidAlive = false;
    public GameObject newMonkeyRight;
    bool monkeyRightAlive = false;
    public GameObject Player;
    static int playerPos;
    static int score;

	void Start () {
        Player = Instantiate(Player);
        score = 0;
        NewMonkey();
        
	}

    void NewMonkey(){
        if(monkeyLeftAlive == false) {
            newMonkeyLeft = Instantiate(newMonkeyLeft);
            newMonkeyLeft.GetComponentInChildren<MonkeyController>().gameManager = this;
            monkeyLeftAlive = true;
            return;
        }
        if (monkeyMidAlive == false)
        {
            newMonkeyMid = Instantiate(newMonkeyMid);
            newMonkeyMid.GetComponentInChildren<MonkeyController>().gameManager = this;
            monkeyMidAlive = true;
            return;
        }
        if (monkeyRightAlive == false)
        {
           
            newMonkeyRight = Instantiate(newMonkeyRight);
            newMonkeyRight.GetComponentInChildren<MonkeyController>().gameManager = this;
            monkeyRightAlive = true;
            return;
        }
    }

    public bool HitCheck(GameObject monkey){
       if(newMonkeyLeft.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos == 0)
        {
            spriteChanger.HitLeft();
            monkeyControllerLeft.Die();
            Debug.Log("Monkey Left Hit!");
            monkeyLeftAlive = false;
            score++;
            NewMonkey();
        }//else apa tar kokosnöt
        
       if(newMonkeyMid.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos == 1)
        {
            spriteChanger.HitMid();
            monkeyControllerMid.Die();
            Debug.Log("Monkey Mid Hit!");
            monkeyMidAlive = false;
            score++;
            NewMonkey();
        }
       
       if(newMonkeyRight.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos == 2)
        {
            spriteChanger.HitRight();
            monkeyControllerRight.Die();
            Debug.Log("Monkey Right Hit!");
            monkeyRightAlive = false;
            score++;
            NewMonkey();
        }

        return false;
    }

	
	// Update is called once per frame
	void Update () {
        playerPos = playerController.GetPosition();
    }
}
