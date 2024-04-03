using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Classe para o "extra da  química"
/// </summary>
public class Extra : MonoBehaviour
{
    /// <summary>
    /// Texto ...
    /// </summary>
    public GameObject texto;
    /// <summary>
    /// Audio Source do VR Rig. Parar a barulheira da quimica e botar a outra música
    /// </summary>
    public AudioSource audio;
    /// <summary>
    /// clip da outra musica
    /// </summary>
    public AudioClip clip;
    /// <summary>
    /// Fogos de artificio.
    /// </summary>
    public ParticleSystem fireworks;
    /// <summary>
    /// Luzes dos postes etc para setar na noite
    /// </summary>
    public List<Light> luzesNoite; 
    /// <summary>
    /// Para fazer a noite
    /// </summary>
    public Light Sol; //para poder fazer a noite de fato 
    /// <summary>
    /// Setar os n objetos necessários no editor
    /// </summary>
    public List<Renderer> listRend;
    /// <summary>
    /// Lista de materiais extra necessários definir no editor
    /// </summary>
    public List<Material> lisMatNoite;
    private List<Material> listMatDia; 
    // Start is called before the first frame update
    void Start()
    {
        listMatDia = new List<Material>();
        foreach(Renderer rend in listRend)
        {
            listMatDia.Add(rend.GetComponent<Material>());
        }
    }

    public void ExtraInic()
    {
        audio.Stop();
        for (int i =0; i< listRend.Count;i++)
        {
            listRend[i].material = lisMatNoite[i];
        }
        Sol.gameObject.SetActive(false);
        foreach(Light luz in luzesNoite)
        {
            luz.gameObject.SetActive(true);
        }
        fireworks.Play();
        texto.SetActive(true);
    }
}
