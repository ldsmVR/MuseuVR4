using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class BotaoMovConti : MonoBehaviour
{

    public InputActionProperty inputmaoEsq;// inputmaoEsq;

    [SerializeField] private GameObject DeviceSimulator, maoCtrlEsq;
    [SerializeField] private Material oscilaCor, corIndicada, corNormal;
    [SerializeField] private ray ray;

    private bool naoClicou = true, olhou = false;
    public string botao;
    private Vector2 compara1 = new Vector2(0, 0);
    //private Vector2 compara2 = new Vector2(1, 0);


    private void Update()
    {
        Joystick();
    }

    //private void Joystick()
    //{
    //    Renderer aux;

    //    Vector2 joystickesq = inputmaoEsq.action.ReadValue<Vector2>();
        
    //    if (naoClicou)
    //    {
            
    //        aux = maoCtrlEsq.transform.Find(botao).GetComponent<Renderer>();
    //        aux.material = corIndicada;
    //    }

    //    if (ray.canvaContorle)
    //    {
    //        olhou = true;
    //    }
        

    //    if (joystickesq != compara && olhou)
    //    {

    //        aux = maoCtrlEsq.transform.Find(botao).GetComponent<Renderer>();
    //        aux.material = oscilaCor;

    //        naoClicou = false;

    //    }
    //    else
    //        if (naoClicou == false)
    //    {
    //        aux = maoCtrlEsq.transform.Find(botao).GetComponent<Renderer>();
    //        aux.material = corNormal;
    //    }

    //}

    private void Start()
    {
        Renderer aux;

        Vector2 joystickEsq = inputmaoEsq.action.ReadValue<Vector2>();


        aux = maoCtrlEsq.transform.Find(botao).GetComponent<Renderer>();
        aux.material = corIndicada;

    }

    private void Joystick()
    {
        Renderer aux;

        Vector2 joystickEsq = inputmaoEsq.action.ReadValue<Vector2>();

        Debug.Log(joystickEsq);

        if (naoClicou)
        {
            aux = maoCtrlEsq.transform.Find(botao).GetComponent<Renderer>();
            aux.material = corIndicada;
        }



        if (joystickEsq != compara1 )
        {

            aux = maoCtrlEsq.transform.Find(botao).GetComponent<Renderer>();
            aux.material = oscilaCor;

            

            naoClicou = false;

        }
        else
        {
            aux = maoCtrlEsq.transform.Find(botao).GetComponent<Renderer>();
            aux.material = corNormal;
        }



    }
}




