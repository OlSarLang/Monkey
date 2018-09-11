using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUpdater : MonoBehaviour {
    public Text scoreText;
    public GameManager gameManager;
    static int score;
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + gameManager.getScore().ToString();
    }
}
