using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe para Resetar objetos individuais 
/// </summary>
public class ResetUnico : MonoBehaviour
{
    private Rigidbody corpoRigido; //atributo para poder aplicar rotações e etc 
    private Quaternion rotacaoIncial;
    private Vector3 posicaoInicial;
    private float velocidadeReset;
    /// <summary>
    /// Setar no editor :
    ///  AudioClip som, audio propriamente dito
    ///  GameObject objeto, objeto que ira cair  
    /// </summary>
    public float alturaReset; // definir de acordo com  o objeto que cai 
    //rever parte de som
    public AudioClip som; //audio propriamente dito
    private AudioSource fonte; // da o play 
    public GameObject objeto; // objeto que ira cair 
    private GameObject filho; // objeto filho que contem todos os atributos da queda
                              /// <summary>
                              /// Inicializa os componentes privados... 
                              /// </summary>
    public bool CanReset { get; set; } = true;
    void Start()
    {
        // Debug.Log(objeto.gameObject.transform.childCount);
        filho = objeto.transform.GetChild(0).gameObject;
        corpoRigido = filho.transform.GetComponent<Rigidbody>();
        posicaoInicial = filho.transform.position;
        rotacaoIncial = filho.transform.rotation;
        // Debug.Log("pos" + posicaoInicial);
        // Debug.Log("rot" + rotacaoIncial);
        velocidadeReset = 1.0f;
        fonte = GetComponent<AudioSource>();
        fonte.clip = som;
    }

    /// <summary>
    /// Verifica se ocorreu a queda e quando ocorreu dispara o som  e reseta a posição
    /// </summary>
    void Update()
    {
        //Debug.Log("Posicao Update"+filho.transform.position.y);
        if (CanReset) { 
            if (filho.transform.position.y < alturaReset)
            {
                fonte.PlayOneShot(som);
                filho.transform.position = posicaoInicial;
                filho.transform.rotation = Quaternion.Slerp(filho.transform.rotation, rotacaoIncial, Time.time * velocidadeReset);
                corpoRigido.velocity = Vector3.zero;
                corpoRigido.angularVelocity = Vector3.zero;
            }
            
        }
    }
}

