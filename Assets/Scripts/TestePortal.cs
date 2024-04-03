using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestePortal : MonoBehaviour
{
    public string scene;
    public GameObject DeviceSimulator;

    public void Interacao()
    {
        Debug.Log("Interacao!!");
        SceneManager.LoadScene(scene);
        Destroy(DeviceSimulator);
        
    }
}
