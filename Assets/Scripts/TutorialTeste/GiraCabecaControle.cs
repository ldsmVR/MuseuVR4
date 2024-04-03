using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GiraCabecaControle : MonoBehaviour
{

    [SerializeField] private GameObject painel, canva1, canva3, canvaJoystick, canvaMuitoBem, CavaMovimente, cubo1, cubo2;
    [SerializeField] private ray ray;
    [SerializeField] private GameObject DeviceSimulator, maoCtrlDir, regiaoOlharCanvas,canvasMao;
    [SerializeField] private string proximo;
    [SerializeField] private Material oscilaCor, corIndicada, corNormal;

    private bool olhou = false, naoClicou = true;

    public InputActionProperty inputGiraCamera;
    private int sequencia=1, quantidadeClique=0;

    private void Start()
    {
        cubo1.SetActive(false);
        cubo2.SetActive(false);
    }
    void Update()
    {
        Renderer aux;
        Debug.Log("funfa");
        
        Joystick();
        switch (sequencia)
        {
            case 1:
                
                    sequencia+=1;
                
           

                break;

            case 2:
                    aux = maoCtrlDir.transform.Find("J").GetComponent<Renderer>();
                    aux.material = corIndicada;
                    painel.SetActive(true);
                    canvaJoystick.SetActive(true);
                    regiaoOlharCanvas.SetActive(false);

                    sequencia += 1;

                break;

            case 3:
                if (!naoClicou)
                {
                    canvaJoystick.SetActive(false);
                    canvaMuitoBem.SetActive(true);
                    AcionaCubos();

                    canva1.SetActive(false);
                    CavaMovimente.SetActive(true);

                    sequencia += 1;

                }

                if (quantidadeClique > 30)
                {
                   canvaMuitoBem.SetActive(false);
                   canvasMao.SetActive(false);
                }

                 break;

            case 4:
                VerificaCubos();
                if (quantidadeClique > 30)
                {
                    canvaMuitoBem.SetActive(false);
                    canvasMao.SetActive(false);
                }


                break;
        }
    }

    private void Joystick()
    {
        Renderer aux;
        Vector2 compara = new Vector2(1, 0);
        Vector2 compara2 = new Vector2(-1, 0);
        Vector2 joystick = inputGiraCamera.action.ReadValue<Vector2>();
        Debug.Log(joystick);

        if ((joystick == compara || joystick == compara2) && sequencia>1)
        {

            aux = maoCtrlDir.transform.Find("J").GetComponent<Renderer>();
            aux.material = oscilaCor;


            quantidadeClique += 1;
            naoClicou = false;

            Debug.Log("Entrou no joy");
            Debug.Log(joystick);

        }
        else
            //if(naoClicou == false && sequencia > 1)
        {
            aux = maoCtrlDir.transform.Find("J").GetComponent<Renderer>();
            aux.material = corNormal;
        }

    }

    private void AcionaCubos()
    {
        cubo1.SetActive(true);
        cubo2.SetActive(true);
    }
    

    private void VerificaCubos()
    {
        
        if (ray.cubo1 == true && ray.cubo2 == true)
        {
            //objCubo3.SetActive(true);
            //CavaMovimente.SetActive(false);
            //canva3.SetActive(true);
            SceneManager.LoadScene(proximo);
            Destroy(DeviceSimulator);

        }

       
    }
}


