using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public IdentificaBotoes identifiaBotoes;
    public ControleMovimento ControleMovimento;

    private char botao;
    private int sequencia=0;
    private bool olhouOK=false;
    

    //void Update()
    //{
    //    botao = identifiaBotoes.Botao;
    //    sequenciaTutorial();

    //}

    //private void sequenciaTutorial()
    //{
    //    switch (sequencia)
    //    {
    //        case 0:
    //            ControleMovimento.BloqueiaMovimentoContinuo();
    //            if(botao == 'A')
    //            {
    //                sequencia++;
    //            }
                
    //            break;
    //        case 1:
    //            ControleMovimento.LiberaMovimentoContinuo();

    //            break;
    //    }
    //}
}
