using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscolhaObjeto : MonoBehaviour
{

    public GameObject[] character;
    public Vector3 posicaoInicial0;
    public Vector3 posicaoInicial1;
    public Vector3 posicaoInicial2;
    public Vector3 posicaoInicial3;

    public Quaternion rotation0;
    public Quaternion rotation1;
    public Quaternion rotation2;
    public Quaternion rotation3;

    // Start is called before the first frame update

    public int selectedCharacter = 0;

    public void Start()
    {
        Debug.Log("start");
        character[0].SetActive(true);

        posicaoInicial0 = character[0].transform.position;
        posicaoInicial1 = character[1].transform.position;
        posicaoInicial2 = character[2].transform.position;
        posicaoInicial3 = character[3].transform.position;

        rotation0 = character[0].transform.rotation;
        rotation1 = character[1].transform.rotation;
        rotation2 = character[2].transform.rotation;
        rotation3 = character[3].transform.rotation;
    }

    public void NextCharacter()
    {
        Debug.Log("Next");
        

        character[selectedCharacter].SetActive(false);

        character[0].transform.position = posicaoInicial0;
        character[1].transform.position = posicaoInicial1;
        character[2].transform.position = posicaoInicial2;
        character[3].transform.position = posicaoInicial3;


        character[0].transform.rotation = rotation0;
        character[1].transform.rotation = rotation1;
        character[2].transform.rotation = rotation2;
        character[3].transform.rotation = rotation3;

        Debug.Log(character[0].transform.position);
        Debug.Log(character[1].transform.position);
        Debug.Log(character[2].transform.position);


        selectedCharacter = (selectedCharacter + 1) % character.Length;
        character[selectedCharacter].SetActive(true);
        
    }

    public void PreviousCharacter()
    {
        


        Debug.Log("Antes");
        //character[selectedCharacter].transform.position = posicaoInicial2[selectedCharacter];
        character[selectedCharacter].SetActive(false);

        character[0].transform.position = posicaoInicial0;
        character[1].transform.position = posicaoInicial1;
        character[2].transform.position = posicaoInicial2;
        character[3].transform.position = posicaoInicial3;

        character[0].transform.rotation = rotation0;
        character[1].transform.rotation = rotation1;
        character[2].transform.rotation = rotation2;
        character[3].transform.rotation = rotation3;

        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += character.Length;
        }
        character[selectedCharacter].SetActive(true);
        //posicaoInicial2[selectedCharacter] = character[selectedCharacter].transform.position;
    }
    public void SatartGame()
    {
        Debug.Log("Start Game");
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        
    }


}
