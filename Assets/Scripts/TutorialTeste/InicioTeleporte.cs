using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioTeleporte : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject primeiroPivot, canvasInicio, canvasMao;

    public string sair, pular;
    public GameObject DeviceSimulator;

    void Start()
    {
        primeiroPivot.SetActive(false);
        canvasMao.SetActive(false);
    }

    // Update is called once per frame
    public void Iniciar()
    {
        primeiroPivot.SetActive(true);
        canvasInicio.SetActive(false);
        canvasMao.SetActive(true);

    }

    public void Pular()
    {

        SceneManager.LoadScene(pular);
        Destroy(DeviceSimulator);

    }


    public void Sair()
    {
        SceneManager.LoadScene(sair);
        Destroy(DeviceSimulator);
    }
}
