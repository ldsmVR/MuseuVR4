using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscolhaObjeto : MonoBehaviour
{
    public GameObject[] obrasList;

    private int lengthList = 0;
    private Quaternion[] rotList;
    private Vector3[] positionList;


    public int selectedCharacter = 0;
    
    public void Awake()
    {
        foreach (GameObject gameObject in obrasList)
        {
            gameObject.SetActive(false);
        }
        lengthList = obrasList.Length;

        // Inicializar arrays rotList e positionList com o mesmo tamanho que obrasList
        rotList = new Quaternion[lengthList];
        positionList = new Vector3[lengthList];

        for (int i = 0; i < lengthList; i++)
        {
            rotList[i] = obrasList[i].transform.rotation;
            positionList[i] = obrasList[i].transform.position;
        }

        obrasList[0].SetActive(true);

    }

    public void NextCharacter()
    {
        obrasList[selectedCharacter].SetActive(false);
        obrasList[selectedCharacter].transform.position = positionList[selectedCharacter];
        obrasList[selectedCharacter].transform.rotation = rotList[selectedCharacter];

        selectedCharacter = (selectedCharacter + 1) % obrasList.Length;
        obrasList[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        obrasList[selectedCharacter].SetActive(false);
        obrasList[selectedCharacter].transform.position = positionList[selectedCharacter];
        obrasList[selectedCharacter].transform.rotation = rotList[selectedCharacter];

        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += obrasList.Length;
        }
        obrasList[selectedCharacter].SetActive(true);
    }

    public void SatartGame()
    {
        Debug.Log("Start Game");
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        
    }
}
