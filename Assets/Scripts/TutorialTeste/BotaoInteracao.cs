using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class BotaoInteracao : MonoBehaviour
{
    public InputActionProperty inputmaoDir, inputmaoEsq;

    [SerializeField] private GameObject DeviceSimulator, maoCtrlDir, maoCtrlEsq;
    [SerializeField] private Material oscilaCor, corIndicada, corNormal;
    [SerializeField] private ray ray;

    private bool naoClicou=true, olhou=false;
    public string botao;


    private void Update()
    {
        Joystick();
    }

    private void Joystick()
    {
        Renderer aux;
        
        float joystickDir = inputmaoDir.action.ReadValue<float>();
        float joystickEsq = inputmaoEsq.action.ReadValue<float>();

        if (naoClicou)
        {
            aux = maoCtrlDir.transform.Find(botao).GetComponent<Renderer>();
            aux.material = corIndicada;
            aux = maoCtrlEsq.transform.Find(botao).GetComponent<Renderer>();
            aux.material = corIndicada;
        }

        //if (ray.canvaContorle)
        //{
        //    olhou = true;
        //}

        if (joystickDir != 0)
        {

            aux = maoCtrlDir.transform.Find(botao).GetComponent<Renderer>();
            aux.material = oscilaCor;
            
            naoClicou = false;

        }
        else
            if (naoClicou == false)
        {
            aux = maoCtrlDir.transform.Find(botao).GetComponent<Renderer>();
            aux.material = corNormal;
        }

        if (joystickEsq != 0)
        {

            aux = maoCtrlEsq.transform.Find(botao).GetComponent<Renderer>();
            aux.material = oscilaCor;

            naoClicou = false;

        }
        else
            if (naoClicou == false)
        {
            aux = maoCtrlEsq.transform.Find(botao).GetComponent<Renderer>();
            aux.material = corNormal;
        }

    }
}
