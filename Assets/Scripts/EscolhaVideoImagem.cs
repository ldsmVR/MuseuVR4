using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscolhaVideoImagem : MonoBehaviour
{
    public GameObject[] character;
    public GameObject video;

    private bool imageStatus;
    

    // Start is called before the first frame update

    public int selectedCharacter = 0;

    public void Start()
    {
        imageStatus = true;

    }

    public void Video()
    {
        imageStatus = false;
        character[selectedCharacter].SetActive(false);
        
        video.SetActive(true);


    }

    public void Image()
    {
        imageStatus = true;
        character[selectedCharacter].SetActive(true);
        video.SetActive(false);
        
    }

    public void NextCharacter()
    {
        Debug.Log("Next");

        

        if(imageStatus)
        {
            character[selectedCharacter].SetActive(false);

            selectedCharacter = (selectedCharacter + 1) % character.Length;
            character[selectedCharacter].SetActive(true);
        }
        

    }

    public void PreviousCharacter()
    {

        if(imageStatus)
        {
            character[selectedCharacter].SetActive(false);

            selectedCharacter--;
            if (selectedCharacter < 0)
            {
                selectedCharacter += character.Length;
            }
            character[selectedCharacter].SetActive(true);
        }
        
        
    }
    public void SatartGame()
    {
        Debug.Log("Start Game");
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(1, LoadSceneMode.Single);

    }
}
