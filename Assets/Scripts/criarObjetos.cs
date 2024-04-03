using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criarObjetos : MonoBehaviour
{


    public GameObject prefabCubo;
    private GameObject cubo1, cubo2;

    public Camera VRcamera;
    private float distRaio = 6f;
    public LayerMask layerColisao;
    public Material corAchou;

    //private ParticleSystem ps = null; // particle system que sera preenchido com o componente do objeto de interesse.



    // Start is called before the first frame update
    void Start()
    {
        cubo1 = Instantiate(prefabCubo);
        cubo1.transform.position = new Vector3(0, 2, 0);
        cubo1.transform.localScale= new Vector3(0.3f, 0.3f, 0.3f);

        cubo2 = Instantiate(prefabCubo);
        cubo2.transform.position = new Vector3(-1, 1, 0);
        cubo2.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
