using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class NativePluginLoader : MonoBehaviour
{
    [DllImport("UnityTransparentizeBackgroundPlugin")]
    private static extern void TransparentizeBackground();

    // Use this for overall initialization on load
    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        // Invoke transparent script when it's not on editor
        #if UNITY_EDITOR
        // None
        #else
        TransparentizeBackground();
        #endif
    }

}