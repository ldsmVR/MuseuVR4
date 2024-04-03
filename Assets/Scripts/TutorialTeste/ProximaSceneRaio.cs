using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProximaSceneRaio : MonoBehaviour
{
    public bool cubo1 = false, cubo2 = false, cubo3 = false, cubo4 = false, cubo5 = false, cubo6 = false;
    
    public GameObject DeviceSimulator;
    public string proximo;




    void Update()
    {



        if (cubo1 == true && cubo2 == true && cubo3 == true && cubo4 == true)
        {
            Debug.Log("Consegui!");
            SceneManager.LoadScene(proximo);
            Destroy(DeviceSimulator);
        }

       

    }
}
