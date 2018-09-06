using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public delegate void ButtonPressed();
    public static event ButtonPressed OnLeftPressed;
    public static event ButtonPressed OnRightPressed;

    public bool left;

    public void OnMouseDown() {
        if(OnLeftPressed != null && left) {
            OnLeftPressed();
        } else if(OnRightPressed != null) {
            OnRightPressed();
        }
        Debug.Log("Pressed Left?" + left);
    }
}
