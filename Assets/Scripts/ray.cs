using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ray : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask layerMask;
    public float distMax;
    public float radius;
    public Material corOk;
    [System.NonSerialized]public bool cubo1 = false, cubo2 = false, cubo3 = false, cubo4 = false, cubo5 = false, cubo6 = false, canvaContorle = false;

    public ProximaSceneVisao tutorial;

    

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
                case 3:
                    canvaContorle = true;

                    break;

                case 6:
                    cor.material = corOk;
                    cubo1 = true;

                    break;

                case 7:
                    cor.material = corOk;
                    cubo2 = true;

                    break;

                case 8:
                    cor.material = corOk;
                    cubo3 = true;

                    break;

                case 9:
                    cor.material = corOk;
                    cubo4 = true;

                    break;

                case 10:
                    cor.material = corOk;
                    cubo5 = true;

                    break;

                case 11:
                    cor.material = corOk;
                    cubo6 = true;

                    break;
            }
        }
        

    }
    


}
