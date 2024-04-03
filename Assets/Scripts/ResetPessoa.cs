using UnityEngine;
/// <summary>
/// Reseta a posição da pessão se, por algum motivo, sair da área prevista de jogo
/// </summary>
public class ResetPessoa : MonoBehaviour // hoje não estou mais usando isso
{
    private Rigidbody corpoRigido; //atributo para poder aplicar rotações e etc 
    private Quaternion rotacaoIncial;
    private Vector3 posicaoInicial;
    private float velocidadeReset;
    /// <summary>
    /// altura  de reset
    /// </summary>
    public float alturaReset; // definir de acordo com  o objeto que cai 
    //rever parte de som
    public AudioClip som; //audio propriamente dito
    /// <summary>
    /// Fonte de som;
    /// </summary>
    private AudioSource fonte; // da o play 
    /// <summary>
    /// // objeto que ira cair 
    /// </summary>
    public GameObject objeto; 
   // private GameObject filho; // objeto filho que contem todos os atributos da queda
    /// <summary>
    /// Inicializa o script, selecionando todas as propriedades necessárias 
    /// </summary>
    void Start()
    {
        //inicializa os componentes
        corpoRigido = objeto.transform.GetComponent<Rigidbody>();
        posicaoInicial = objeto.transform.position;
        rotacaoIncial = objeto.transform.rotation;
        // Debug.Log("pos" + posicaoInicial);
        // Debug.Log("rot" + rotacaoIncial);
        velocidadeReset = 1.0f;
        fonte = GetComponent<AudioSource>();
        fonte.clip = som;
    }

    /// <summary>
    /// Monitora se ocorreu a queda 
    /// </summary>
    void Update()
    {
        //Debug.Log("Posicao Update"+filho.transform.position.y);
        if (objeto.transform.position.y < alturaReset)
        {
            fonte.PlayOneShot(som);
            objeto.transform.position = posicaoInicial; // reseta posição 
            objeto.transform.rotation = Quaternion.Slerp(objeto.transform.rotation, rotacaoIncial, Time.time * velocidadeReset); // reseta rotação
            //reseta velocidades 
            corpoRigido.velocity = Vector3.zero;
            corpoRigido.angularVelocity = Vector3.zero;
        }
    }
}
