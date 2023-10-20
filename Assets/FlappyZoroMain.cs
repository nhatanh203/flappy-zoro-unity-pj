using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyZoroMain : MonoBehaviour
{
    public GameObject zoroObj;
    public GameObject pipeObj;
    public GameObject startGameAction;
    void Start()
    {
        if (startGameAction.activeSelf == true)
        {
            zoroObj.SetActive(false);
            pipeObj.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
