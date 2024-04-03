using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaQuimicaMuseu : MonoBehaviour
{
    public string scene;
    public GameObject DeviceSimulator;

    public void Quimica()
    {
        SceneManager.LoadScene(scene);
        Destroy(DeviceSimulator);
    }

    

}
