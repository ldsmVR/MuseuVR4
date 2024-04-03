using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;



public class ControleMovimento : MonoBehaviour
{
    public GameObject XRGameObject;

    private ActionBasedContinuousMoveProvider mover = null;
    private ActionBasedContinuousTurnProvider turner = null;



    void Start()
    {
        XRGameObject = FindObjectOfType<XROrigin>().gameObject;
        turner = XRGameObject.GetComponent<ActionBasedContinuousTurnProvider>();
        mover = XRGameObject.GetComponent<ActionBasedContinuousMoveProvider>();
        turner.turnSpeed = 0.0f;
        mover.moveSpeed = 0.0f;
    }

   

    //public void BloqueiaMovimentoContinuo()
    //{
        
    //    turner.turnSpeed = 0.0f;
    //    mover.moveSpeed = 0.0f;
        
    //}

    //public void LiberaMovimentoContinuo()
    //{
    //    turner.turnSpeed = 60f;
    //    mover.moveSpeed = 1f;

    //}
}
