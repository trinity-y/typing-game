using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEnabler : MonoBehaviour
{
    static GameObject typingText;
    static GameObject targetText;
    public bool show = false;
    public void enableText()
    {
        show = true;
        UnityEngine.Debug.Log("text enabler show: " + show.ToString());
    }
}
