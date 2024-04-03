using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IdentificaBotoes : MonoBehaviour
{
    public InputActionReference botao1 = null;
    public InputActionReference botao2 = null;
    public InputActionReference botao3 = null;
    public InputActionReference botao4 = null;

    private char botao = ' ';


    private void Awake() // inicia antes de tudo
    {
        botao1.action.started += BotaoA;
        botao2.action.started += BotaoB;
        botao3.action.started += BotaoC;
        botao4.action.started += BotaoD;
        


    }

    private void OnDestroy()
    {

        botao1.action.started -= BotaoA;
        botao2.action.started -= BotaoB;
        botao3.action.started -= BotaoC;
        botao4.action.started -= BotaoD;
    }


    private void BotaoA(InputAction.CallbackContext context)
    {
        botao = 'A';
        Debug.Log("Botao A");
    }

    private void BotaoB(InputAction.CallbackContext context)
    {
        botao = 'B';
        Debug.Log("Botao B");
    }

    private void BotaoC(InputAction.CallbackContext context)
    {
        botao = 'C';
        Debug.Log("Botao C");
    }

    private void BotaoD(InputAction.CallbackContext context)
    {
        botao = 'D';
        Debug.Log("Botao D");
    }

    

    public char Botao
    {
        get{ return botao; }
    }
}
