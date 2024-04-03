using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InicioMovimentoConti : MonoBehaviour
{
    public GameObject primeiroPivot, canvasInicio, canvasMao;

    public string museuVR;
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

    public void Sair()
    {
        SceneManager.LoadScene(museuVR);
        Destroy(DeviceSimulator);
    }
}
