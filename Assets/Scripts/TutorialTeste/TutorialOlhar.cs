using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialOlhar : MonoBehaviour
{

    [SerializeField] private GeraCubos testeVisaoCubos;
    [SerializeField] LayerMask layerColisao;
    [SerializeField] XRRig vrRig;
    [SerializeField] private Camera VRcamera;


    // Start is called before the first frame update
    void Start()
    {
        testeVisaoCubos.setValidacao(true, layerColisao, vrRig, VRcamera);
        testeVisaoCubos.GerarCubos();
    }

    // Update is called once per frame
    void Update()
    {
        if (!testeVisaoCubos.getOlhouTodos())
        {
            testeVisaoCubos.RaiosCubos();
            Debug.Log("Olhou Todos");
        }
    }
}
