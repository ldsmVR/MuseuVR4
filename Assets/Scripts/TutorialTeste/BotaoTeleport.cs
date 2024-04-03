using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class BotaoTeleport : MonoBehaviour
{

    public InputActionProperty inputmaoDir;// inputmaoEsq;

    [SerializeField] private GameObject DeviceSimulator, maoCtrlDir; //maoCtrlEsq;
    [SerializeField] private Material oscilaCor, corIndicada, corNormal;
    [SerializeField] private ray ray;

    private bool naoClicou = true, olhou = false;
    public string botao;
    private Vector2 compara = new Vector2(0, 1);


    private void Update()
    {
        Joystick();
    }

    private void Start()
    {
        Renderer aux;

        Vector2 joystickDir = inputmaoDir.action.ReadValue<Vector2>();
        
       
        aux = maoCtrlDir.transform.Find(botao).GetComponent<Renderer>();
        aux.material = corIndicada;
       
    }

    private void Joystick()
    {
        Renderer aux;

        Vector2 joystickDir = inputmaoDir.action.ReadValue<Vector2>();

        if (naoClicou)
        {
            aux = maoCtrlDir.transform.Find(botao).GetComponent<Renderer>();
            aux.material = corIndicada;
        }

       

        if (joystickDir == compara)
        {

            aux = maoCtrlDir.transform.Find(botao).GetComponent<Renderer>();
            aux.material = oscilaCor;

            Debug.Log(joystickDir);

            naoClicou = false;

        }
        else
        {
            aux = maoCtrlDir.transform.Find(botao).GetComponent<Renderer>();
            aux.material = corNormal;
        }

       

    }
}


