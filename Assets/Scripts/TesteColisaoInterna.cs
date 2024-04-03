using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteColisaoInterna : MonoBehaviour
{
    public LayerMask lmask;

    private bool canReset = true;
    private Rigidbody corpoRigido; //atributo para poder aplicar rotações e etc 
    private Quaternion rotacaoIncial;
    private Vector3 posicaoInicial;
    private float velocidadeReset;
    public TesteGrabInteract canReset1;

    private bool colidiu = false;


    //public AudioClip som; //audio propriamente dito
    //private AudioSource fonte; // da o play 



    private bool Colisao = false;

    private void Update()
    {
        //transform.position = posicaoInicial;
        canReset = canReset1.podeResetar;

        if (canReset && colidiu)
        {

            //fonte.PlayOneShot(som);
            transform.position = posicaoInicial;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoIncial, Time.time * velocidadeReset);
            corpoRigido.velocity = Vector3.zero;
            corpoRigido.angularVelocity = Vector3.zero;
            colidiu = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        //fonte = GetComponent<AudioSource>();
        corpoRigido = transform.GetComponent<Rigidbody>();
        posicaoInicial = transform.position;
        rotacaoIncial = transform.rotation;
        velocidadeReset = 1.0f;

        //fonte.clip = som;
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Valor da mask de colisao" + other.gameObject.layer);
        Debug.Log("Valor da mask escolida" + lmask.value);


        if (other.gameObject.tag == "colisao" || other.gameObject.tag == "limiteChao")
        {
            colidiu = true;
            Debug.Log("Colidiu!");
            
        }
    }

    
}
