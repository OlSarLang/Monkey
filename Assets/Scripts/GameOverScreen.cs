using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {

    //public Text gameOverText;
    Text textOver;
   // public GameManager gameManager;
    //Collider2D touch;
    //public Collider2D touchArea;
    bool gameOver;

    public void Start(){
       // textOver = Instantiate(gameOverText);
       // touch = Instantiate(touchArea);
       // gameOverText.text = "Game Over";
    }

    private void OnMouseDown() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
