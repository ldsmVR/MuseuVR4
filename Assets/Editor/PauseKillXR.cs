using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Management;

[InitializeOnLoad]
public static class PauseKillXR
{

    static PauseKillXR()
    {
        EditorApplication.playmodeStateChanged += ModeChanged;
    }

    static void ModeChanged()
    {
        if (!EditorApplication.isPlayingOrWillChangePlaymode &&
             EditorApplication.isPlaying)
        {
            Debug.Log("Exiting playmode.");
            StopXR();
        }
    }
    static void StopXR()
    {
        Debug.Log("Stopping XR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR stopped completely.");
    }
}