using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRaio : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask layerMask;
    public float distMax;
    public float radius;
    public Material corOk;

    public ProximaSceneRaio tutorial;



    void Update()
    {
        bool hasHitted = Physics.SphereCast(this.transform.position, this.radius, this.transform.forward, out hit, distMax, layerMask, QueryTriggerInteraction.UseGlobal);
        Debug.DrawRay(this.transform.position, this.transform.forward, Color.yellow);
        if (hasHitted)
        {


            GameObject atingido = hit.collider.gameObject;
            Renderer cor = atingido.GetComponent<Renderer>();

            Debug.Log(atingido.layer);


            switch (atingido.layer)
            {
                case 6:
                    cor.material = corOk;
                    tutorial.cubo1 = true;


                    break;

                case 7:
                    cor.material = corOk;
                    tutorial.cubo2 = true;

                    break;

                case 8:
                    cor.material = corOk;
                    tutorial.cubo3 = true;

                    break;

                case 9:
                    cor.material = corOk;
                    tutorial.cubo4 = true;

                    break;
                    
            }
        }


    }
}
