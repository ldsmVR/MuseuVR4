using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTeste : MonoBehaviour
{

    public GameObject colisaoOk;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "alvo")
        {
            Debug.Log("Chegou!");
            colisaoOk.SetActive(true);
        }


    }

    private void Start()
    {
        Debug.Log("TesteScript");
    }
}
