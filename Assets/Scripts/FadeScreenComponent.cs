using System.Collections;
using UnityEngine;
/// <summary>
/// Classe que faz a transição de cenas 
/// Deve ser adicionado ao quad que faz a transição da cena
/// </summary>
public class FadeScreenComponent : MonoBehaviour
{
    private bool firstTime = true;
    public bool fadeOnStart = true;
    /// <summary>
    /// Variavel que define o tempo do fade
    /// </summary>
    public float fadeDuration = 2;
    /// <summary>
    /// Cor do fade
    /// </summary>
    public Color fadeColor;
    private Renderer rend; //quem de fato trocará a cor
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (fadeOnStart) FadeIn();
    }
    public void FadeIn()
    {
        Fade(1, 0);
    }
    public void FadeOut()
    {
        Debug.Log("fadeOUTCALL");
        Fade(0, 1);
    }
    /// <summary>
    /// Rotina do Fade
    /// </summary>
    /// <param name="alphaIn"></param>
    /// <param name="alphaOut"></param>
   public void Fade(float alphaIn,  float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }
    /// <summary>
    ///  
    /// Corrotina que ira atuar no load 
    /// </summary>
    /// <param name="alphaIn"></param>
    /// <param name="alphaOut"></param>
    /// <returns></returns>
    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        this.gameObject.SetActive(true);
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color corAux = fadeColor;
            corAux.a = Mathf.Lerp(alphaIn, alphaOut, timer/fadeDuration);
            rend.material.SetColor("_Color", corAux);
            timer += Time.deltaTime;
            yield return null; // espera 1 frame
        }
        Color corAux2 = fadeColor;
        corAux2.a = alphaOut;
        rend.material.SetColor("_Color", corAux2);
        if (firstTime)
        {
            this.gameObject.SetActive(false);
            firstTime = false;
        }
    }
}
