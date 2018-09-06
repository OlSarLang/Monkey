using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public List<Transform> positions = new List<Transform>();
    public int currentPos = 1;

    private void OnEnable() {
        PlayerInput.OnLeftPressed += Input_OnLeftPressed;
        PlayerInput.OnRightPressed += Input_OnRightPressed;
    }
    private void OnDisable() {
        PlayerInput.OnLeftPressed -= Input_OnLeftPressed;
        PlayerInput.OnRightPressed -= Input_OnRightPressed;
    }
    // Use this for initialization
    void Start () {
        transform.position = positions[currentPos].position;
	}
    private void Update() {
        
    }

    void Input_OnLeftPressed(){
        if(currentPos > 0)
        {
            currentPos--;
            transform.position = positions[currentPos].position;
        }
        else
        {
            return;
        }
    }

    void Input_OnRightPressed(){
        if(currentPos < positions.Count - 1){
            currentPos++;
            transform.position = positions[currentPos].position;
        }else{
            return;
        }
    }

    public int GetPosition(){
        return currentPos;
    }
}
