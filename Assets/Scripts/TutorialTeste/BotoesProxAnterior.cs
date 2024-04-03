using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesProxAnterior : MonoBehaviour
{
    public string proximo, repetir, sair;
    public GameObject DeviceSimulator;

    public void Proximo()
    {
        
        SceneManager.LoadScene(proximo);
        Destroy(DeviceSimulator);

    }

    public void Repetir()
    {

        SceneManager.LoadScene(repetir);
        Destroy(DeviceSimulator);
    }
    public void Sair()
    {
        SceneManager.LoadScene(sair);
        Destroy(DeviceSimulator);
    }

}
