using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Menu_Obras : MonoBehaviour
{
    public GameObject[] obrasList;
    private int count =0;

    private int lengthList = 0;
    private Quaternion[] rotList;
    private Vector3[] positionList;

    void Start()
    {
        foreach (GameObject baseTime in obrasList)
        {
            baseTime.gameObject.SetActive(false);
        }

        lengthList = obrasList.Length;

        // Inicializar arrays rotList e positionList com o mesmo tamanho que obrasList
        rotList = new Quaternion[lengthList];
        positionList = new Vector3[lengthList];

        for (int i = 0; i < lengthList; i++)
        {
            rotList[i] = obrasList[i].transform.localRotation;
            positionList[i] = obrasList[i].transform.localPosition;
            Debug.Log("Testewww");
        }
    }

    public void EscolhaObra(int obra)
    {
        obrasList[count].gameObject.SetActive(false);
        obrasList[count].transform.localPosition = positionList[count];
        obrasList[count].transform.localRotation = rotList[count];

        obrasList[obra].gameObject.SetActive(true);

        count = obra;
    }
}
