using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu_Manager : MonoBehaviour
{
    [SerializeField] List<GameObject> lista = new List<GameObject>();
    [SerializeField] int counter = 0;

    public InputActionProperty rightInputButtonA;
    public InputActionProperty leftInputButtonA;

    private int _lenghtList;

    void Start()
    {
        foreach (GameObject baseTime in lista)
        {
            baseTime.gameObject.SetActive(false);
        }
        _lenghtList = lista.Count;
        lista[counter].gameObject.SetActive(true);

       // this.gameObject.SetActive(false);

    }



    public void Proximo()
    {
        lista[counter].gameObject.SetActive(false);
        if (counter < (_lenghtList - 1))
        {
            counter++;
        }
        else
            counter = 0;

        lista[counter].gameObject.SetActive(true);
    }

    public void Anterior()
    {
        lista[counter].gameObject.SetActive(false);
        if (counter > (0))
        {
            counter--;
        }
        else
            counter = _lenghtList - 1;

        lista[counter].gameObject.SetActive(true);
    }

    public void Sair()
    {
        this.gameObject.SetActive(false);
    }

    private void ChamaMenu()
    {
        float rightInput =  rightInputButtonA.action.ReadValue<float>();
        float lefttInput =  leftInputButtonA.action.ReadValue<float>();

        if(rightInput > 0 || lefttInput >0)
        {
            this.gameObject.SetActive(true);
        }

    }
}
