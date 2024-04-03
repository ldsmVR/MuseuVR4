using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesIniciais : MonoBehaviour
{
    public string pular, iniciar, sair;
    public GameObject DeviceSimulator;

    public void Pular()
    {

        SceneManager.LoadScene(pular);
        Destroy(DeviceSimulator);

    }

    public void Iniciar()
    {

        SceneManager.LoadScene(iniciar);
        Destroy(DeviceSimulator);
    }
    public void Sair()
    {
        SceneManager.LoadScene(sair);
        Destroy(DeviceSimulator);
    }
}
