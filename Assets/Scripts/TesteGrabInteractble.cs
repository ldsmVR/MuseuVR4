using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteGrabInteractble : MonoBehaviour
{
    //public ResetarColisao detectarColisao;

    public bool podeResetar = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
