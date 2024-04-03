using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject telep1, telep2, telep3, final, canvasMao;
    private int sequencia=0;

    void Start()
    {
        telep2.SetActive(false);
        telep3.SetActive(false);
        final.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colidiu");
        if (other.gameObject.tag == "teleporte")
        {
            Debug.Log("deu bom");

            sequencia++;
            switch (sequencia)
            {
                case 1:
                    telep1.SetActive(false);
                    telep2.SetActive(true);
                    canvasMao.SetActive(false);
                    break;

                case 2:
                    
                    telep2.SetActive(false);
                    telep3.SetActive(true);
                    Debug.Log("Terminou!");
                    break;

                case 3:

                    telep3.SetActive(false);
                    final.SetActive(true);
                    Debug.Log("Terminou!");
                    break;

            }

        }
    }
    
}
