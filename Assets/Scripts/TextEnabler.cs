using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEnabler : MonoBehaviour
{
<<<<<<< HEAD
    static GameObject typingText;
    static GameObject targetText;
=======
>>>>>>> f5fc538df39db096430167cf55ecb9a842424915
    public static bool show = false;
    public void enableText()
    {
        show = true;
        UnityEngine.Debug.Log("text enabler show: " + show.ToString());
    }
}
