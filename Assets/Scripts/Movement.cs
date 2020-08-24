using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

/* THIS SCRIPT IS TO BE ATTACHED THE MOVING ENTITY! it..
 * chooses the text to be typed, sets the text objects (attached as 'typing object' and 'target object') to the correct text at start
 * activates wpm/text objects at game start
 * adjusts speed according to typing
 * moves character
 * changes colour of text
 * measures WPM
 */

public class Movement : MonoBehaviour
{
    /* 
     * VARIABLES!!
    */
    // text database - all possibilities for text are here
    static string[] textDatabase = new string[7] {"the higher we build, the harder to see, paint over your strokes and the ink will just bleed", 
        "I'm not bitter, I'm just tired - no use getting angry at the way that you're wired", 
        "someone hold me down before I book a flight to your front door, no one else will bring relief, and I don't want to greive", 
        "perhaps the problem lies in the double load I bear, because I ripped myself apart and you just stood there",
    "let me look inside, cause under all that fire, there are knots that I can help undo - my dear I'm only trying to help you",
    "drawing the blinds, thinking of you. poor lonely mind, it's getting confused. will you ever lie next to me in the bed that I dream of us in?",
    "rewire the dread, this whirring machine, if you can't cool it down, steam is still steam. will you ever know of this image of you that can soothe me to sleep?"};
    // objects that need to be connected (this allows us to change the text on them)
    public Text typingObject;
    public Text targetObject;
    public Text wordsPerMinuteObject;
    // colours for changing colour of text based on key accuracy
    Color green = new Color(0.3059f, 0.404f, 0.2392f);
    Color red = new Color(0.502f, 0.0275f, 0.0275f);
    // classes for their methods
    private CharacterController controller;
    static System.Random rng = new System.Random();
    public static bool gameStarted;
    // variables to measure player acheivement
    public string chosenText; // what the player has to type
    public int playerIndex = 0; // how far along the player is in the text
    public Single speed = 1.000f; // how fast the player is going (units per sec)
    public int numOfCharsTyped = 0; // how many characters the player has typed
    public float timePassed = 0.001f; // how much time has passed since the start of the game
    public int wpm; // how many words per minute the player is typing
    


    private void Awake()
    {
        // choose a random text and update text objects
        chosenText = textDatabase[rng.Next(0, 7)];
        typingObject.text = chosenText;
        targetObject.text = chosenText;
    }
    void Start()
    {
        // show  text objects if the game has started
        gameStarted = TextEnabler.show;
        typingObject.gameObject.SetActive(gameStarted);
        targetObject.gameObject.SetActive(gameStarted);
        wordsPerMinuteObject.gameObject.SetActive(gameStarted);
        // gets character controller component for movement
        controller = gameObject.GetComponent<CharacterController>();//?
    }

    void Update()
    {
        speed -= 0.005f; // decreases speed every frame
        Vector3 forward = transform.TransformDirection(Vector3.forward); // gets the location just moving forward converted
        controller.SimpleMove(forward * speed); //moves forward the location*speed
        if (gameStarted)// a timer to calculate wpm
        {
            timePassed += Time.deltaTime;
        }
        if (Input.anyKeyDown) // any time a key is pressed
        {
            if (char.Parse(Input.inputString) == chosenText[playerIndex])//check if it's the write key that is pressed
            {//if it is
                playerIndex += 1;// add on to the progress
                speed += 0.2f; // increase speed
                typingObject.color = green; // make sure typing progress is green
                numOfCharsTyped += 1; // adds to chars typed for wpm calculations
            }
            else
            {// if it isn't
                speed -= 0.1f; // decrease speed
                typingObject.color = red; // make typing progress red
            }
            if (gameStarted) // if the game has started (and key has been pressed, remember we're in the keypressed if)
            {
                wpm = (int)Math.Round(numOfCharsTyped / timePassed*12); //update wpm
                wordsPerMinuteObject.text = "words per minute: " + wpm.ToString(); //update text object
            }
        }
        
    }
}
