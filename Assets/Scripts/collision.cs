using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    // identifica colisao

    private void OnTriggerEnter(Collider other)
    {
        print("Colisao detectada");
    }


}
