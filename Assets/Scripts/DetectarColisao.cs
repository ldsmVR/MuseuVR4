using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColisao : MonoBehaviour
{

    public LayerMask lmask;

    private bool canReset = true;
    private Rigidbody corpoRigido; //atributo para poder aplicar rotações e etc 
    private Quaternion rotacaoIncial;
    private Vector3 posicaoInicial;
    private float velocidadeReset;
    public TesteGrabInteract canReset1;

    private bool Colisao = false;


    // Start is called before the first frame update
    void Start()
    {
        corpoRigido = transform.GetComponent<Rigidbody>();
        posicaoInicial = transform.position;
        rotacaoIncial = transform.rotation;
        velocidadeReset = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        canReset=canReset1.podeResetar;
        
    }
    
    
    public void OnCollisionStay(Collision collision)
    {
        Debug.Log("Valor da mask de colisao" + collision.gameObject.layer);
        Debug.Log("Valor da mask escolida" + lmask.value);

        if(collision.gameObject.tag == "colisao" || collision.gameObject.tag == "limiteChao")
        {

            Debug.Log("Colidiu!");
            if (canReset)
            {
                //fonte.PlayOneShot(som);
                transform.position = posicaoInicial;
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoIncial, Time.time * velocidadeReset);
                corpoRigido.velocity = Vector3.zero;
                corpoRigido.angularVelocity = Vector3.zero;
            }
        }

     
        

    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Valor da mask de colisao" + collision.gameObject.layer);
    //    Debug.Log("Valor da mask escolida" + lmask.value);

    //    if (collision.gameObject.tag == "colisao")
    //    {
    //        Debug.Log("Colidiu!");
    //        if (canReset)
    //        {
    //            //fonte.PlayOneShot(som);
    //            transform.position = posicaoInicial;
    //            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoIncial, Time.time * velocidadeReset);
    //            corpoRigido.velocity = Vector3.zero;
    //            corpoRigido.angularVelocity = Vector3.zero;
    //        }
    //    }




    //}
}
