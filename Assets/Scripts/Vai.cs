using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vai : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionReference botao1 = null;
    public InputActionReference botao2 = null;
    public InputActionReference botao3 = null;
    public InputActionReference botao4 = null;
    public InputActionReference botao5 = null;

    public GameObject texto1;
    public GameObject texto2;
    public GameObject texto3;

    public GameObject[] textos;
    public GameObject canvas;

    public char[] botoes = {'A', 'B', 'X', 'Y', 'S', 'K'};
    public string[] texto = { "botao a", "botao b", "botao x", "botao t", "sair", "k" };

    public char botao=' ';
    public string vaibotao = "VaiBotao";
    public int sequencia = 0;

    private bool botao01=false;
    private bool botao02 = false;
    private void Awake() // inicia antes de tudo
    {
        botao1.action.started += BotaoA;
        botao2.action.started += BotaoB;
        botao3.action.started += BotaoX;
        botao4.action.started += BotaoY;

        botao5.action.started += BotaoS;


    }

    private void Update()
    {
        //if (botao01 == true)
        //Debug.Log("Ok");
        //acaosemordem();

        acaocomordem();
    }

    private void OnDestroy()
    {

        botao1.action.started -= BotaoA;
        botao2.action.started -= BotaoB;
        botao3.action.started -= BotaoX;
        botao4.action.started -= BotaoY;
    }


    private void BotaoA(InputAction.CallbackContext context)
    {
        botao = 'A';
       // Debug.Log("boatao A");
        //Debug.Log(botao);
    }

    private void BotaoB(InputAction.CallbackContext context)
    {
        botao = 'B';
        //Debug.Log("botao B");
    }

    private void BotaoX(InputAction.CallbackContext context)
    {
        botao = 'B';
    }

    private void BotaoY(InputAction.CallbackContext context)
    {
        botao = 'C';
    }

    private void BotaoS(InputAction.CallbackContext context)
    {
        botao = 'D';
    }

    //private void Botao2(InputAction.CallbackContext context)
    //{
    //    botao02 = true;
    //    //Debug.Log(botao02 + "botao2");

    //}

    //public void acaosemordem()
    //{
    //    // int i;

    //    for (int i = 0; i < 4; i++)
    //    {
    //        if (botao == botoes[i])
    //            Debug.Log(texto[i]);
    //        botao = ' ';
    //    }

    //}

    public string botaochar()
    {
        return vaibotao;
    }

    public void acaocomordem()
    {
        //if (botao == 'A')
        //{
        //    Debug.Log("Funcionou!");
        //}

        if (botao == botoes[sequencia])
        {
            if (sequencia < 4)
            {
                Debug.Log(texto[sequencia]);
                textos[sequencia].SetActive(false);

                sequencia++;
                textos[sequencia].SetActive(true);
            }
            else
            {
                switch (botao)
                {
                    case 'D':
                        Debug.Log("Letra D");

                        break;

                    //case 'E'
                }
                    


            }


            //botao = ' ';
        }
        
        //Debug.Log(botao);
    }


    //public void acao1()
    //{
    //    if (botao01 == true)
    //    {
    //        gameObject.SetActive(false);
    //        proximo.SetActive(true);

    //        Debug.Log(botao01 +"botao1");

    //        if (botao02 == true)
    //        {
    //            //proximo.SetActive(false);
    //            teste3.SetActive(true);
    //            Debug.Log(botao02 +"boatao2");
    //        }
    //    }





    // }

}
