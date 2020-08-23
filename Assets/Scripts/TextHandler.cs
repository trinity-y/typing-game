using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    string targetText;
    int playerIndex;
    public Text textObject;
    // Start is called before the first frame update
    void Start()
    {
        targetText = GameObject.Find("Main Camera").GetComponent<Movement>().text;
        playerIndex = GameObject.Find("Main Camera").GetComponent<Movement>().playerIndex;
        
    }

    // Update is called once per frame
    void Update()
    {
        playerIndex = GameObject.Find("Main Camera").GetComponent<Movement>().playerIndex;
        textObject.text = targetText.Substring(0, playerIndex);
    }
}
