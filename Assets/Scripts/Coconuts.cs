using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconuts : MonoBehaviour {

    [SerializeField] public GameObject[] coconuts;

    private void Start()
    {
        for (int i = 0; i < coconuts.Length; i++)
        {
            Instantiate(coconuts[i]);
        }
    }
}
