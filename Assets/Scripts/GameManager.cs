using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour{
    // Use this for initialization
    public MonkeyController monkeyControllerLeft;
    public MonkeyController monkeyControllerMid;
    public MonkeyController monkeyControllerRight;
    public PlayerController playerController;
    public SpriteChanger spriteChanger;
    public float moveDelay = 3.0f;
    bool pause = false;

    public ScoreUpdater scoreUpdater;

    public List<GameObject> monkeysLeft = new List<GameObject>();
    public GameObject MonkeyLeft;
    GameObject newMonkeyLeft;
    bool monkeyLeftAlive = false;
    int amountLeft;

    public GameObject MonkeyMid;
    GameObject newMonkeyMid;
    bool monkeyMidAlive = false;
    int amountMid;

    public GameObject MonkeyRight;
    GameObject newMonkeyRight;
    bool monkeyRightAlive = false;
    int amountRight;

    public GameObject coconutOnePrefab;
    public GameObject coconutTwoPrefab;
    public GameObject coconutThreePrefab;
    public GameObject coconutFourPrefab;
    public GameObject coconutFivePrefab;
    public GameObject coconutSixPrefab;
    
    public GameObject Player;
    static int playerPos;
    int score;
    int coconuts;
    List<GameObject> coconutsLeft = new List<GameObject>();
    List<GameObject> coconutsMid = new List<GameObject>();
    List<GameObject> coconutsRight = new List<GameObject>();


    int spawner = 0;

    void Start(){
        Player = Instantiate(Player);
        coconutsLeft.Add(Instantiate(coconutOnePrefab));
        coconutsLeft.Add(Instantiate(coconutTwoPrefab));
        coconutsMid.Add(Instantiate(coconutThreePrefab));
        coconutsMid.Add(Instantiate(coconutFourPrefab));
        coconutsRight.Add(Instantiate(coconutFivePrefab));
        coconutsRight.Add(Instantiate(coconutSixPrefab));
        score = 0;
        StartCoroutine(NewSpawn());
    }

    void NewMonkeyLeft(){
        newMonkeyLeft = Instantiate(MonkeyLeft);
        newMonkeyLeft.GetComponentInChildren<MonkeyController>().gameManager = this;
        Debug.Log("monkey created");
        amountLeft++;
        monkeyLeftAlive = true;
        return;

    }
    void NewMonkeyMid(){
        newMonkeyMid = Instantiate(MonkeyMid);
        newMonkeyMid.GetComponentInChildren<MonkeyController>().gameManager = this;
        amountMid++;
        monkeyMidAlive = true;
        return;

    }
    void NewMonkeyRight(){
        newMonkeyRight = Instantiate(MonkeyRight);
        newMonkeyRight.GetComponentInChildren<MonkeyController>().gameManager = this;
        amountRight++;
        monkeyRightAlive = true;
        return;
    }

    public bool HitCheck(GameObject monkey){
        //Debug.Log("Hitcheck körs");
        if (monkeyLeftAlive == true && newMonkeyLeft.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos == 0){
            spriteChanger.HitLeft();
            Debug.Log("Monkey Left Hit!");
            score++;
            Debug.Log(score);
            amountLeft--;
            return true;
        } else if (monkeyLeftAlive == true && newMonkeyLeft.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos != 0){
            Destroy(coconutsLeft[0]);
            coconutsLeft.RemoveAt(0);
            amountLeft--;
            return false;
        }
        if (monkeyMidAlive == true && newMonkeyMid.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos == 1){
            spriteChanger.HitMid();
            Debug.Log("Monkey Mid Hit!");
            score++;
            Debug.Log(score);
            amountMid--;
            return true;
        } else if (monkeyMidAlive == true && newMonkeyMid.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos != 1){
            amountMid--;
            return false;
        }

        if (monkeyRightAlive == true && newMonkeyRight.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos == 2){
            spriteChanger.HitRight();
            Debug.Log("Monkey Right Hit!");
            score++;
            Debug.Log(score);
            amountRight--;
            return true;
        } else if (monkeyRightAlive == true && newMonkeyRight.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos != 2){
            amountRight--;
            return false;
        }
        return false;
    }

    public void RandomSpawner(){
        Debug.Log("RandomSpawner körs");
        spawner = Random.Range(0, 3);
        if (spawner == 0 && amountLeft < 2){
            if (amountLeft < 1){
                Debug.Log("Amount of monkeys left: " + amountLeft);
                NewMonkeyLeft();
            }
        }
        else if (spawner == 1 && amountMid < 2){
            if (amountMid < 1){
                Debug.Log("Amount of monkeys mid: " + amountMid);
                NewMonkeyMid();
            }
        }
        else if (spawner == 2 && amountRight < 2){
            if (amountRight < 1){
                Debug.Log("Amount of monkeys right: " + amountRight);
                NewMonkeyRight();
            }
        }
        else
            return;
    }

    // Update is called once per frame
    void Update(){
        playerPos = playerController.GetPosition();
        if (amountLeft < 1){
            monkeyLeftAlive = false;
        }
        if (amountMid < 1){
            monkeyMidAlive = false;
        }
        if (amountRight < 1){
            monkeyRightAlive = false;
        }
    }

    IEnumerator NewSpawn(){
        while (true){
            Debug.Log("NewSpawn() körs");
            yield return new WaitForSeconds(moveDelay);
            RandomSpawner();
        }
    }

    public int getScore()
    {
        return score;
    }
}