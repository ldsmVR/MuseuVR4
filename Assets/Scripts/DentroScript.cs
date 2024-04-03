using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DentroScript : MonoBehaviour
{

    private string botao;
    public Vai testeVai;
    public GameObject massa;
    public GameObject posicaoCamera;
    private Transform leituraPosicao;
    private Transform leituraPosicaoPivot;

    public Camera cameraPosition;

    public GameObject posicaoPivot;
    // Start is called before the first frame update
    void Start()
    {
        //botao = testeVai.botaochar();
        //Debug.Log(botao);
        //Rigidbody massa1 = massa.GetComponent<Rigidbody>();
        //massa1.mass = 2;
        //massa.GetComponent<Rigidbody>().mass = 2;
        //Debug.Log(massa.GetComponent<Rigidbody>().mass);

        //Debug.Log(posicaoCamera.GetComponent<Transform>().position);
        //leituraPosicao = Instantiate(posicaoCamera.GetComponent<Transform>());
        //leituraPosicao = posicaoCamera.GetComponent<Transform>().position;
        //Debug.Log(leituraPosicao.position);
        //leituraPosicaoPivot.position = posicaoPivot.GetComponent<Transform>().position;




        Debug.Log(posicaoCamera.transform.position);


        //leituraPosicao.position = cameraPosition.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //leituraPosicao.position = posicaoCamera.GetComponent<Transform>().position;
        if (posicaoCamera.transform.position==posicaoPivot.transform.position)
        {
            Debug.Log("Voce chegou!");
        }

        //Debug.Log(posicaoCamera.transform.position);
    }
}
