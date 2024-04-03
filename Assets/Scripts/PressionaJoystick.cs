using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressionaJoystick : MonoBehaviour
{
    
    public InputActionProperty inputGripDir;
    public InputActionProperty inputGripEsq;

    public InputActionProperty inputTriggerDir;
    public InputActionProperty inputTriggerEsq;

    [SerializeField] private GameObject maoCtrlDir, maoCtrlEsq; // controle  direito
    
    [SerializeField] private Material oscilaCor, corNormal;
    

    private void Update()
    {
        
        float gripValueDir = inputGripDir.action.ReadValue<float>();
        float griptValueEsq = inputGripEsq.action.ReadValue<float>();

        float triggerValueDir = inputTriggerDir.action.ReadValue<float>();
        float triggerValueEsq = inputTriggerEsq.action.ReadValue<float>();



        MudarCor(gripValueDir, griptValueEsq, triggerValueDir, triggerValueEsq);


    }

    private void MudarCor(float gripValueDir, float griptValueEsq, float triggerValueDir, float triggerValueEsq)
    {
        
        //Muda cor do Grip Direito e Esquerdo

        if (gripValueDir > 0)
            OscilaCor(maoCtrlDir, "G");
        else
            CorNormal(maoCtrlDir, "G");

        if (griptValueEsq > 0)
            OscilaCor(maoCtrlEsq, "G");
        else
            CorNormal(maoCtrlEsq, "G");

        //Muda cor do Trigger Direito e Esquerdo

        if (triggerValueDir > 0)
            OscilaCor(maoCtrlDir, "T");
        else
            CorNormal(maoCtrlDir, "T");

        if (triggerValueEsq > 0)
            OscilaCor(maoCtrlEsq, "T");
        else
            CorNormal(maoCtrlEsq, "T");




    }
    
    private void OscilaCor(GameObject objBotao, string nomeBotao)
    {
        Renderer aux;

        aux = objBotao.transform.Find(nomeBotao).GetComponent<Renderer>();
        aux.material = oscilaCor; 
    }

    private void CorNormal(GameObject objBotao, string nomeBotao)
    {
        Renderer aux;

        aux = objBotao.transform.Find(nomeBotao).GetComponent<Renderer>();
        aux.material = corNormal;
    }



}

   

