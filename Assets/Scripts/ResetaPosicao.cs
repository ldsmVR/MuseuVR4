using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetaPosicao : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 posicao;
    public GameObject objeto;

    public void Start()
    {
        posicao = objeto.transform.position;
    }

    public void Update()
    {
        Posicao();
    }
    public void Posicao()
    {
        objeto.transform.position = posicao;
        //Debug.Log("posicao");
    }
}
