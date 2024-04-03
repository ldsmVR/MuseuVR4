using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteChao : MonoBehaviour
{
    public GameObject cameralocal, maoDir, maoEsq;

    private Rigidbody rigCamera, rigMaoDir, rigMaoEsq; //atributo para poder aplicar rotações e etc 
    private Quaternion rotacaoCamera, rotacaoMaoDir, rotacaoMaoEsq;
    private Vector3 posiIniCamera, posiIniMaoDir, posiIniMaoEsq;
    private float velocidadeReset;

    // Start is called before the first frame update
    void Start()
    {
        rigCamera = cameralocal.transform.GetComponent<Rigidbody>();
        posiIniCamera = cameralocal.transform.position;
        rotacaoCamera = cameralocal.transform.rotation;
        velocidadeReset = 1.0f;

        rigMaoDir = maoDir.transform.GetComponent<Rigidbody>();
        posiIniMaoDir = maoDir.transform.position;
        rotacaoMaoDir = maoDir.transform.rotation;
       

        rigMaoEsq = maoEsq.transform.GetComponent<Rigidbody>();
        posiIniMaoEsq = maoEsq.transform.position;
        rotacaoMaoEsq = maoEsq.transform.rotation;
       


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "limiteChao")
        {

            Debug.Log("Resetou!");

            //fonte.PlayOneShot(som);

            //camera
                cameralocal.transform.position = posiIniCamera;
                cameralocal.transform.rotation = Quaternion.Slerp(cameralocal.transform.rotation, rotacaoCamera, Time.time * velocidadeReset);
                rigCamera.velocity = Vector3.zero;
                rigCamera.angularVelocity = Vector3.zero;

            //marDir

                maoDir.transform.position = posiIniMaoDir;
                maoDir.transform.rotation = Quaternion.Slerp(maoDir.transform.rotation, rotacaoMaoDir, Time.time * velocidadeReset);
                rigMaoDir.velocity = Vector3.zero;
                rigMaoDir.angularVelocity = Vector3.zero;

            //maoEsq
                maoEsq.transform.position = posiIniMaoEsq;
                maoEsq.transform.rotation = Quaternion.Slerp(maoEsq.transform.rotation, rotacaoMaoEsq, Time.time * velocidadeReset);
                rigMaoEsq.velocity = Vector3.zero;
                rigMaoEsq.angularVelocity = Vector3.zero;

        }




    }
}
