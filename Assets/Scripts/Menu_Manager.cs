using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Manager : MonoBehaviour
{
    [SerializeField] List<GameObject> lista = new List<GameObject>();
    [SerializeField] int counter = 0;

    private int _lenghtList;

    void Start()
    {
        foreach (GameObject baseTime in lista)
        {
            baseTime.gameObject.SetActive(false);
        }
        _lenghtList = lista.Count;
        lista[counter].gameObject.SetActive(true);

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
        if (counter >= (_lenghtList - 1))
        {
            counter--;
        }
        else
            counter = _lenghtList - 1;

        lista[counter].gameObject.SetActive(true);
    }

}
