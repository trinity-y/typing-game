using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    static string[] textDatabase = new string[7] {"the higher we build, the harder to see, paint over your strokes and the ink will just bleed", 
        "I'm not bitter, I'm just tired - no use getting angry at the way that you're wired", 
        "someone hold me down before I book a flight to your front door, no one else will bring relief, and I don't want to greive", 
        "perhaps the problem lies in the double load I bear, because I ripped myself apart and you just stood there",
    "let me look inside, cause under all that fire, there are knots that I can help undo - my dear I'm only trying to help you",
    "drawing the blinds, thinking of you. poor lonely mind, it's getting confused. will you ever lie next to me in the bed that I dream of us in?",
    "rewire the dread, this whirring machine, if you can't cool it down, steam is still steam. will you ever know of this image of you that can soothe me to sleep?"};
    private CharacterController controller;
    public static bool show;
    static System.Random rng = new System.Random();
    public string text;
    public int playerIndex = 0;
    public int numOfCharsTyped = 0;
    public Text typingObject;
    public Text targetObject;
    public Text wordsPerMinuteObject;
    public Single speed = 1.000f;
    public float timePassed = 0.001f;
    public int wpm;
    Color green = new Color(0.3059f, 0.404f, 0.2392f);
    Color red = new Color(0.502f, 0.0275f, 0.0275f);


    private void Awake()
    {
        text = textDatabase[rng.Next(0, 7)];
        typingObject.text = text;
        targetObject.text = text;
    }
    // Start is called before the first frame update
    void Start()
    {
        show = TextEnabler.show;
        typingObject.gameObject.SetActive(show);
        targetObject.gameObject.SetActive(show);
        wordsPerMinuteObject.gameObject.SetActive(show);
    }

    // Update is called once per frame
    void Update()
    {
        controller = gameObject.GetComponent<CharacterController>();
        speed -= 0.005f;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        controller.SimpleMove(forward * speed);
        if (show)
        {
            timePassed += Time.deltaTime;
        }
        if (Input.anyKeyDown)
        {
            if (char.Parse(Input.inputString) == text[playerIndex])
            {
                playerIndex += 1;
                speed += 0.2f;
                typingObject.color = green;
                numOfCharsTyped += 1;
            }
            else
            {
                speed -= 0.1f;
                typingObject.color = red;
            }
            if (show)
            {
                wpm = (int)Math.Round(numOfCharsTyped / timePassed*12);
                wordsPerMinuteObject.text = "words per minute: " + wpm.ToString();
            }
        }
        
    }
}
