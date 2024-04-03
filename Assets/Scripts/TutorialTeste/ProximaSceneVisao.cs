using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProximaSceneVisao : MonoBehaviour
{
    [SerializeField] private GameObject objCubo5, objCubo6, canvaInicio, canvaVisao;
    [SerializeField] private ray ray;
    [SerializeField] private GameObject DeviceSimulator;
    [SerializeField] private string proximo;
    

    void Update()
    {
        ControleCanvas();
    }

    private void ControleCanvas()
    {
        if (ray.cubo1 == true && ray.cubo2 == true && ray.cubo3 == true && ray.cubo4 == true)
        {
            Debug.Log("Consegui!");
            objCubo5.SetActive(true);
            objCubo6.SetActive(true);
            canvaInicio.SetActive(false);
            canvaVisao.SetActive(true);
        }

        if (ray.cubo5 == true && ray.cubo6 == true)
        {
            SceneManager.LoadScene(proximo);
            Destroy(DeviceSimulator);
        }
    }
}
