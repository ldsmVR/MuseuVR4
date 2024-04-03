using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScens : MonoBehaviour
{

    public string testeVisao;
    public string teleporte;
    public string interacao;
    public string movimento;
    public string totem;

    public GameObject DeviceSimulator;

    public GameObject colisaoOk;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "alvo")
        {
            Debug.Log("Chegou!");
            SceneManager.LoadScene(teleporte);
            Destroy(DeviceSimulator);
        }


    }

    private void Start()
    {
        Debug.Log("TesteScript");
    }
}
