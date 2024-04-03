using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentificaInteracao : MonoBehaviour
{
    public GameObject canvasFim, canvasInicio;

    private void Start()
    {
        canvasFim.SetActive(false);
        canvasInicio.SetActive(true);
    }
    public void Interacao()
    {
        canvasFim.SetActive(true);
        canvasInicio.SetActive(false);
    }
}
