using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;
using UnityEngine.UI;
using System.Collections;

/// Classe que carrega de fato as novas cenas
/// </summary>
public class LoadScenes : MonoBehaviour {
    public FadeScreenComponent fader;
    public GameObject UIinfos;
    public GameObject Uiload;
    public Image loadBarra;
    AsyncOperation LoadScene;
    public bool notFirstScene = true;
	// Script para carregar as cenas.
    /// <summary>
    /// String com o nome da cena do museu 
    /// </summary>
	public string museu;     // Cena do Museu. 
    /// <summary>
    /// String com o nome da cena do Química 
    /// </summary>
	public string quimica;   // Cena do Prédio da Química.
    /// <summary>
    /// String com o nome da cena da entrada 
    /// </summary>
    public string entrada;   // cena entrada
    /// <summary>
    /// String com o nome da cena do tutorial 
    /// </summary>
    public string tutorial;  // tutorial 
    [SerializeField] private Toggle comTutorial; // nã oprecisa inicilaizar essa varialvel se esta operando usando esse script para outras trocas
                                                 // Função para carregar a cena do Museu.
                                                 /// <summary>
                                                 /// Carrega a primeira cena 
                                                 /// </summary>
    private void AtivaLoad()
    {
        Uiload.SetActive(true);
    }

    private void DesativaUI()
    {
        UIinfos.SetActive(false);
    }

    public void Start()
    {
        UIinfos.SetActive(true);
        Uiload.SetActive(false);
    }

    public void LoadFirstScene()
    {
        
        //Debug.Log(comTutorial.isOn);
        if (comTutorial.isOn)
        {
            LoadTutorial();            
        }
        else
        {
            LoadMuseu();
        }
        StartCoroutine(TelaLoad());
    }

    IEnumerator TelaLoad() // faz a barra do load
    {
        float loadpercent=0;
        while (!LoadScene.isDone)
        {
            loadpercent += LoadScene.progress;
          //  Debug.Log("Load%" + loadpercent);
            loadBarra.fillAmount = loadpercent/100;
            yield return null;
        }
    }

    // Carrega o museu 
	public void LoadMuseu () {
        //verificar se preciso utilizar isso em qualquer situação, ver se o  tempo de transição sem vr não atrapalha a imersao e etc 
        //Debug.Log("Stopping XR...");
        //XRGeneralSettings.Instance.Manager.StopSubsystems();
        //XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        //Debug.Log("XR stopped completely.");
        DesativaUI();
        if (notFirstScene) 
        {
            StartCoroutine(TrocaCenaComFade(museu));
        }
        else
        {
            AtivaLoad();
            LoadScene = SceneManager.LoadSceneAsync(museu, LoadSceneMode.Single);
        }
       
       
    }
    /// <summary>
    /// Carrega o Tutorial
    /// </summary>
    public void LoadTutorial()
    {
        //verificar se preciso utilizar isso em qualquer situação, ver se o  tempo de transição sem vr não atrapalha a imersao e etc 
        //Debug.Log("Stopping XR...");
        //XRGeneralSettings.Instance.Manager.StopSubsystems();
        //XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        //Debug.Log("XR stopped completely.");
        DesativaUI();
        if (notFirstScene)
        {
            StartCoroutine(TrocaCenaComFade(tutorial));
        }
        else
        {
            AtivaLoad();
            LoadScene = SceneManager.LoadSceneAsync(tutorial, LoadSceneMode.Single);
        }
    }

  /// <summary>
  /// Carrega a entrada 
  /// </summary>

    public void LoadEntrada()
    {
       // Debug.Log("Stopping XR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
       // Debug.Log("XR stopped completely.");
        DesativaUI();
        //AtivaLoad();
        LoadScene = SceneManager.LoadSceneAsync(entrada, LoadSceneMode.Single);
    }

    /// <summary>
    /// Função para carregar a cena do Prédio da Química.
    /// </summary>
    public void LoadQuimica () {

        //Debug.Log("irquimica");
        //Debug.Log("Stopping XR...");
        //XRGeneralSettings.Instance.Manager.StopSubsystems();
        //XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        //Debug.Log("XR stopped completely.");
        DesativaUI();
        if (notFirstScene)
        {
            //Debug.Log("pqraios não estou  aquoi");
            StartCoroutine(TrocaCenaComFade(quimica));
        }
        else
        {
            //Debug.Log("pqraios estou aquoi");
            AtivaLoad();
            LoadScene = SceneManager.LoadSceneAsync(quimica, LoadSceneMode.Single);
        }
    }

    IEnumerator TrocaCenaComFade(string cena)
    {
        //Debug.Log("FazerFade");
        fader.gameObject.SetActive(true);
        fader.FadeOut();
        LoadScene = SceneManager.LoadSceneAsync(cena,LoadSceneMode.Single);
        LoadScene.allowSceneActivation = false;
        float timer = 0;
        while(timer <= fader.fadeDuration && !LoadScene.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        LoadScene.allowSceneActivation = true;
    }
}