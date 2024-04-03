using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteGrabInteract : MonoBehaviour
{

    
    public bool podeResetar = true;
    

    public void Selecao()
    {
        Debug.Log("Selecionou1111");
        podeResetar = false;
    }
    public void SemSelecao()
    {
        Debug.Log("Sem selecao");
        podeResetar = true;



    }

}
