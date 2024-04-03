using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoConti : MonoBehaviour
{
    public GameObject alvo1, alvo2, alvo3, alvo4, final, canvasMao;
    private int sequencia = 0;

    void Start()
    {
        alvo2.SetActive(false);
        alvo3.SetActive(false);
        alvo4.SetActive(false);
        final.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "alvo")
        {
            sequencia++;
            switch (sequencia)
            {
                case 1:
                    alvo1.SetActive(false);
                    alvo2.SetActive(true);
                    canvasMao.SetActive(false);
                    break;

                case 2:

                    alvo2.SetActive(false);
                    alvo3.SetActive(true);
                    break;

                case 3:

                    alvo3.SetActive(false);
                    alvo4.SetActive(true);
                    break;

                case 4:

                    alvo4.SetActive(false);
                    final.SetActive(true);
                    break;

            }

        }
    }
}
