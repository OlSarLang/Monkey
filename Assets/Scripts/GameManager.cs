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
    bool playing = true;

    public ScoreUpdater scoreUpdater;
    public GameObject gameOverScreen;
    public GameObject gameOverCollider;

    public GameObject MonkeyLeft;
    GameObject newMonkeyLeft;
    bool monkeyLeftAlive = false;

    public GameObject MonkeyMid;
    GameObject newMonkeyMid;
    bool monkeyMidAlive = false;

    public GameObject MonkeyRight;
    GameObject newMonkeyRight;
    bool monkeyRightAlive = false;

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
        playing = true;
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
        monkeyLeftAlive = true;
        return;

    }
    void NewMonkeyMid(){
        newMonkeyMid = Instantiate(MonkeyMid);
        newMonkeyMid.GetComponentInChildren<MonkeyController>().gameManager = this;
        monkeyMidAlive = true;
        return;

    }
    void NewMonkeyRight(){
        newMonkeyRight = Instantiate(MonkeyRight);
        newMonkeyRight.GetComponentInChildren<MonkeyController>().gameManager = this;
        monkeyRightAlive = true;
        return;
    }

    public bool HitCheck(GameObject monkey){
        //Debug.Log("Hitcheck körs");
        if (monkeyLeftAlive == true && newMonkeyLeft != null && newMonkeyLeft.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos == 0){
            spriteChanger.HitLeft();
            Debug.Log("Monkey Left Hit!");
            score++;
            monkeyLeftAlive = false;
            return true;
        } else if (monkeyLeftAlive == true && newMonkeyLeft != null && newMonkeyLeft.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos != 0){
            Destroy(coconutsLeft[0]);
            coconutsLeft.RemoveAt(0);
            monkeyLeftAlive = false;
            return false;
        }
        if (monkeyMidAlive == true && newMonkeyMid != null && newMonkeyMid.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos == 1){
            spriteChanger.HitMid();
            Debug.Log("Monkey Mid Hit!");
            score++;
            monkeyMidAlive = false;
            return true;
        } else if (monkeyMidAlive == true && newMonkeyMid != null && newMonkeyMid.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos != 1){
            Destroy(coconutsMid[0]);
            coconutsMid.RemoveAt(0);
            monkeyMidAlive = false;
            return false;
        }

        if (monkeyRightAlive == true && newMonkeyRight != null && newMonkeyRight.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos == 2){
            spriteChanger.HitRight();
            Debug.Log("Monkey Right Hit!");
            score++;
            monkeyRightAlive = false;
            return true;
        } else if (monkeyRightAlive == true && newMonkeyRight != null && newMonkeyRight.GetComponentInChildren<MonkeyController>().currentPosition == 3 && playerPos != 2){
            Destroy(coconutsRight[0]);
            coconutsRight.RemoveAt(0);
            monkeyRightAlive = false;
            return false;
        }
        return false;
    }

    public void RandomSpawner() {
    Debug.Log("RandomSpawner körs");
        if (playing) { 
            spawner = Random.Range(0, 3);
            if (spawner == 0 && monkeyLeftAlive == false) {
            NewMonkeyLeft();
            }
            else if (spawner == 1 && monkeyMidAlive == false) {
            NewMonkeyMid();
            }
            else if (spawner == 2 && monkeyRightAlive == false) {
            NewMonkeyRight();

            }
        }
        else
            return;
    }

    // Update is called once per frame
    void Update(){
        if (playing) {
        playerPos = playerController.GetPosition();
            if (coconutsLeft.Count == 0) {
    monkeyLeftAlive = false;
            playing = false;
            GameOver();
            }
            if (coconutsMid.Count == 0) {
    monkeyMidAlive = false;
            playing = false;
            GameOver();
            }
            if (coconutsRight.Count == 0) {
    monkeyRightAlive = false;
            playing = false;
            GameOver();
            }
        }
    }

    IEnumerator NewSpawn(){
        while (playing){
            yield return new WaitForSeconds(moveDelay);
            RandomSpawner();
        }
    }

    public void GameOver(){
        StopCoroutine(NewSpawn());
        if(monkeyLeftAlive == true){
            newMonkeyLeft.GetComponentInChildren<MonkeyController>().StopAllCoroutines();
        }
        if(monkeyMidAlive == true){
            newMonkeyMid.GetComponentInChildren<MonkeyController>().StopAllCoroutines();
        }
        if(monkeyRightAlive == true){
            newMonkeyRight.GetComponentInChildren<MonkeyController>().StopAllCoroutines();
        }
        gameOverScreen.SetActive(true);
        GameObject gc = Instantiate(gameOverCollider);


    }
    public int getScore()
    {
        return score;
    }
}