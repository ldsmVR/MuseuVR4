using UnityEngine;
using UnityEngine.XR;
/// <summary>
/// Classe que faz faz a expasão das obras 
/// </summary>

public class ExpandeObra : MonoBehaviour                                            // Script responsável para expandir obras.
{
    [SerializeField] AudioSource audioSource;                                       // para o som do pinch -> acho bem ruim o som, mas ok
    [SerializeField] AudioClip audioClipPinch;                                     // som do pinch
    public XRNode inputSourceDireto;                                                // o que vou ler 
    private InputDevice deviceDireito;                                               // funcionalidade de controle 
    public XRNode inputSourceEsquerdo;                                              // o que vou ler 
    private InputDevice deviceEsquerdo;                                             // funcionalidade de controle 
    private float leituraDir;                                                       // leitura que terei dos controles 
    private float leituraEsq;
    private float taxa;                                                             // taxa de aumento
    public float tamLimiteMax;                                                     // limites Max e Min
    public float tamlimiteMin;
    private bool holdEsq;                                                           // ver se estou segurando algo ou não
    private bool holdDir;
    public float mmax = 1.7f;                                     // selecionar os limites de aumento e diminuição das obras.                                      
    public float mmin = 0.5f;                                     // depois de definir isso tira o serialized 
    [SerializeField] private float passo = 40f;                                     // Passo de aumento/ diminuição quanto maior menor será o passo/variação
    [SerializeField] private float margemMov = 0.0007f;
    public Transform ctrlEsq;
    public Transform ctrlDir;
    public Vector3 escalaLocal;
    private Vector3 escalaOriginal;  //tamanho original para utilizar no reset 
    private float lastDir;
    public bool segurando = false;
    void Start()
    {
        deviceDireito = InputDevices.GetDeviceAtXRNode(inputSourceDireto);         // inicia selecionando controle que quero, devo selecionar no unity, no caso mao direita
        deviceEsquerdo = InputDevices.GetDeviceAtXRNode(inputSourceEsquerdo);       //
        tamLimiteMax = transform.localScale.x * mmax;                              // define o Máximo                     
        tamlimiteMin = transform.localScale.x * mmin;                              // define o mínimo 
        escalaOriginal = transform.localScale;
        taxa = (transform.localScale.x);
        holdEsq = false;
        holdDir = false;
    }
    /// <summary>
    /// Set Segurando = true
    /// </summary>
    public void SetSegurando()
    {
        segurando = true;
    }
    /// <summary>
    /// Reset Segurando = false 
    /// </summary>
    public void ResetSegurando()  // chamar no XRGrab que é da própria obra 
    {
        segurando = false;
    }
    /// <summary>
    /// Efetua as  leituras 
    /// </summary>
    public void Update()
    {
        if (segurando) { 
        deviceDireito.TryGetFeatureValue(CommonUsages.grip, out leituraDir);// trigger não utilizado para nada na mão direita, não tem nenhum problema 
        deviceEsquerdo.TryGetFeatureValue(CommonUsages.grip, out leituraEsq);// esse botão também está sendo utilizado para o teleport mas dentro do próprio Unity eu desabilito o teleport
        transformar();
        }
    }
    /// <summary>
    /// Efetua a transformação propriamente dita 
    /// </summary>
    public void transformar() // poderia ser private ??
    {
        if (lastDir <= 0.0f) lastDir = Vector3.Distance(ctrlDir.position, ctrlEsq.position);
        if ((leituraDir >= 0.4f) && (leituraEsq >=0.4f) )                                         // se pressionei um pouco mais do controle e estou segurando a obra na minha mão ... 
        {
            if (lastDir <=0.0f) lastDir = Vector3.Distance(ctrlDir.position, ctrlEsq.position);
            float dist = Vector3.Distance(ctrlDir.position, ctrlEsq.position);
            //Debug.Log("dirEsq"+ dist);
            dist = Vector3.Distance(ctrlEsq.position, ctrlDir.position);
           // Debug.Log("esqDir"+dist);
            float delta = (dist - lastDir);
            if (delta < margemMov && delta > -margemMov) delta = 0;// preciso mover mais que 5 mm
            if (transform.localScale.x < tamLimiteMax && (delta > 0.0f))
            {

                transform.localScale += new Vector3(Mathf.Lerp(0, taxa, Time.deltaTime), Mathf.Lerp(0, taxa, Time.deltaTime), Mathf.Lerp(0, taxa, Time.deltaTime)); // expando  // expando 
                if(!audioSource.isPlaying) audioSource.PlayOneShot(audioClipPinch); // verificar se não ira interferir com o som geral
            }
            else if (transform.localScale.x >= tamlimiteMin && (delta < 0.0f))
            {

                transform.localScale -= new Vector3(Mathf.Lerp(0, taxa, Time.deltaTime), Mathf.Lerp(0, taxa, Time.deltaTime), Mathf.Lerp(0, taxa, Time.deltaTime)); // comprimo
                if (!audioSource.isPlaying) audioSource.PlayOneShot(audioClipPinch);
            }
            lastDir = dist;
        }
        escalaLocal = transform.localScale;
        lastDir = Vector3.Distance(ctrlDir.position, ctrlEsq.position);
    }
    /// <summary>
    /// Reseta a escala do objeto 
    /// </summary>
    public void resetScale()
    {
        escalaLocal = escalaOriginal;
    }

}
