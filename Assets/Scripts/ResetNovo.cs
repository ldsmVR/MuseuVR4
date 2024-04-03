using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetNovo : MonoBehaviour
{
    public bool canReset { get; set; } = true;
    private Rigidbody corpoRigido; //atributo para poder aplicar rotações e etc 
    private Quaternion rotacaoIncial;
    private Vector3 posicaoInicial;
    private float velocidadeReset;
    public LayerMask lmask;




    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.layer);
        Debug.Log(lmask);
        if (collision.gameObject.layer == lmask)
        {
            Debug.Log("WTF ");
            //if (canReset)
            //{
            //    //fonte.PlayOneShot(som);
            //    transform.position = posicaoInicial;
            //    transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoIncial, Time.time * velocidadeReset);
            //    corpoRigido.velocity = Vector3.zero;
            //    corpoRigido.angularVelocity = Vector3.zero;
            //}

        }
    }


    /// <summary>
    /// Setar no editor :
    ///  AudioClip som, audio propriamente dito
    ///  GameObject objeto, objeto que ira cair  
    /// </summary>
    //public AudioClip som; //audio propriamente dito
    //private AudioSource fonte; // da o play 

    void Start()
    {
        // Debug.Log(objeto.gameObject.transform.childCount);
        
        corpoRigido = transform.GetComponent<Rigidbody>();
        posicaoInicial = transform.position;
        rotacaoIncial = transform.rotation;
        // Debug.Log("pos" + posicaoInicial);
        // Debug.Log("rot" + rotacaoIncial);
        velocidadeReset = 1.0f;
        //fonte = GetComponent<AudioSource>();
        //fonte.clip = som;
    }
  

    /// <summary>
    /// Verifica se ocorreu a queda e quando ocorreu dispara o som  e reseta a posição
    /// </summary>
    void Update()
    {
        //Debug.Log("Posicao Update"+filho.transform.position.y);
        
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Colidiu");
    //    if (other.gameObject.tag == "alvo")
    //    {
    //        Debug.Log("Chegou!");
            
    //        Debug.Log("WTF ");
    //        //if (canReset)
    //        //{
    //        //    //fonte.PlayOneShot(som);
    //        //    transform.position = posicaoInicial;
    //        //    transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoIncial, Time.time * velocidadeReset);
    //        //    corpoRigido.velocity = Vector3.zero;
    //        //    corpoRigido.angularVelocity = Vector3.zero;
    //        //}
    //    }


    //}
}
