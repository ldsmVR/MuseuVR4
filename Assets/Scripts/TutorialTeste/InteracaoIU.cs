using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoIU : MonoBehaviour
{
    public GameObject cliqueAqui, canvaProximo;


    public void CliqueAqui()
    {
        cliqueAqui.SetActive(false);
        canvaProximo.SetActive(true);
    }
}
