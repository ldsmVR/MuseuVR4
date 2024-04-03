using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GeraCubos : MonoBehaviour
{
    private Camera VRcamera; // para poder posicionar os cubos
    private XRRig vrRig;    // para poder posicionar os cubos
    //escala e posicionamendto dos cubos 
    [SerializeField] private float distanciaCubos = 2.75f;
    [SerializeField] private float escalaCubos = 0.4f;
    private float ladoPor2Quadrado = 1f;

    private const int NUM_CUBOS = 4; // número de cubos que irei olhar 
    private GameObject[] cubos = new GameObject[NUM_CUBOS]; // cubos das direções
    [SerializeField] GameObject prefabCubo;
    private bool OlhouTodos = false;
    private Dictionary<string, bool> dictCubos = new Dictionary<string, bool>(); // nomes Direita, Esquerda, Cima , Baixo
    private LayerMask layerColisao;
    private float distRaio = 6f;
    private bool iniciarValidacao = false;
    private ParticleSystem ps = null; // particle system que sera preenchido com o componente do objeto de interesse.
    [SerializeField] private List<Material> listMat = new List<Material>(); // lista de materias
    private Dictionary<string, Material> dictMat = new Dictionary<string, Material>(); // lista de materias
    public void Start()
    {
        foreach (Material mat in listMat)
        {
            dictMat[mat.name] = mat;
        }
    }
    /// <summary>
    /// Habilita a validação do cubo 
    /// </summary>
    /// <param name="iniciarValidacao"></param> // habilita o booleano para iniciar o precesso de testes 
    /// <param name="layerColisao"></param> // layer onde deve ser detectada a colisão 
    /// <param name="vrRig"></param>  // VRrig para obter a posição
    /// <param name="camera"></param> // Camera para obter a direção onde o player  está olhando 
    public void setValidacao(bool iniciarValidacao, LayerMask layerColisao, XRRig vrRig, Camera camera)
    {
        this.iniciarValidacao = iniciarValidacao;
        this.layerColisao = layerColisao;
        this.vrRig = vrRig;
        VRcamera = camera;
    }

    //  public void FixedUpdate()
    //  {
    //      if(!OlhouTodos && iniciarValidacao)
    //    {
    //          RaiosCubos();
    //}
    //   }

    /// <summary>
    /// Desativa os cubos caso necessário
    /// </summary>
    public void DesativaCubo()
    {
        for (int i = 0; i < NUM_CUBOS; i++)
        {
            cubos[i].SetActive(false);
        }
    }
    /// <summary>
    /// Ativa os cubos 
    /// </summary>
    public void AtivaCubo()
    {
        for (int i = 0; i < NUM_CUBOS; i++)
        {
            cubos[i].SetActive(true);
            Debug.Log(cubos[i].name);
        }
    }

    /// <summary>
    /// Getter para verificar se olhou todos os cubos
    /// </summary>
    /// <returns></returns> true se olhou todos 
    public bool getOlhouTodos()
    {
        return OlhouTodos;
    }
    /// <summary>
    /// Gera os cubos nas 4 posições principais da rosa dos ventos 
    /// </summary>
    public void GerarCubos()
    { // gera os que devem ser atingidos 
        for (int i = 0; i < NUM_CUBOS; i++) //varre todos os cubos 
        {
            //cubos[i] = GameObject.CreatePrimitive(PrimitiveType.Cube); versão antiga 
            cubos[i] = Instantiate(prefabCubo);
            Renderer cor = cubos[i].GetComponent<Renderer>();
            cor.material = dictMat["Cima"];
            cubos[i].transform.localScale = new Vector3(escalaCubos, escalaCubos, escalaCubos);
            cubos[i].layer = LayerMask.NameToLayer("ColisoesTutorial");
            switch (i)
            {
                case 0:
                    cubos[i].name = "Cima";
                    cubos[i].transform.position = VRcamera.transform.position + VRcamera.transform.forward * distanciaCubos;
                    cubos[i].transform.position = new Vector3(cubos[i].transform.position.x, vrRig.cameraInRigSpaceHeight * 1.7f, cubos[i].transform.position.z); // para ficar um pouco acima 
                    cubos[i].transform.rotation = new Quaternion(0.0f, VRcamera.transform.rotation.y, 0.0f, VRcamera.transform.rotation.w); //ajeita para  a frente da camera 
                    break;
                case 1:
                    cubos[i].name = "Esquerda";
                    cubos[i].transform.position = VRcamera.transform.position + VRcamera.transform.forward - VRcamera.transform.right * distanciaCubos;
                    cubos[i].transform.position = new Vector3(cubos[i].transform.position.x, vrRig.cameraInRigSpaceHeight, cubos[i].transform.position.z); // para ficar à  direita
                    cubos[i].transform.rotation = new Quaternion(0.0f, VRcamera.transform.rotation.y, 0.0f, VRcamera.transform.rotation.w); //ajeita para  a frente da camera 
                    break;
                case 2:
                    cubos[i].name = "Baixo";
                    cubos[i].transform.position = VRcamera.transform.position + VRcamera.transform.forward * distanciaCubos;
                    cubos[i].transform.position = new Vector3(cubos[i].transform.position.x, 0, cubos[i].transform.position.z); // para ficar um pouco acima 60 cm abaixo 
                    cubos[i].transform.rotation = new Quaternion(0.0f, VRcamera.transform.rotation.y, 0.0f, VRcamera.transform.rotation.w); //ajeita para  a frente da camera 
                    break;
                case 3:
                    cubos[i].name = "Direita";
                    cubos[i].transform.position = VRcamera.transform.position + VRcamera.transform.forward + VRcamera.transform.right * distanciaCubos;
                    cubos[i].transform.position = new Vector3(cubos[i].transform.position.x, vrRig.cameraInRigSpaceHeight, cubos[i].transform.position.z); // para ficar à esquerda
                    cubos[i].transform.rotation = new Quaternion(0.0f, VRcamera.transform.rotation.y, 0.0f, VRcamera.transform.rotation.w); //ajeita para  a frente da camera 
                    break;
                default:
                    Debug.Log("erro");
                    break;
            }
            cor.material = dictMat[cubos[i].name];
            dictCubos.Add(cubos[i].name, false); // inicia o estado de todos os  cubos como falso.
        }
    } // ok Esta funcionando na primeira parte e  etc 

    /// <summary>
    /// Emite os raios que irão colidir com os cubos e caso o hit ocorra já atualiza e troca a cor do cubo atingido 
    /// </summary>
    public void RaiosCubos()
    {
        RaycastHit hit; //vou usar esse raycast de forma similar ao que foi utilizado para detectar uma queda no script de Movimento contínuo;
        bool hasHit = Physics.SphereCast(VRcamera.transform.position, 0.4f, VRcamera.transform.forward, out hit, distRaio, layerColisao);
        //Debug.DrawRay(VRcamera.transform.position, VRcamera.transform.forward, Color.yellow);
        bool olhouTodos = true;
        // Debug.Log(hasHit);
        if (hasHit)
        {
            GameObject atingido = hit.collider.gameObject;
            Renderer cor = atingido.GetComponent<Renderer>();
            cor.material = cor.material = dictMat["Atingido"];
            ps = atingido.GetComponentInChildren<ParticleSystem>();
            if (!dictCubos[atingido.name])
            {
                ps.Play();
            }
            //Debug.Log(atingido.name);
            dictCubos[atingido.name] = true;
            // efeito esta mt mt mt ruim mas isso é perfurmaria então dá para fazer depois
            // efeitinho.transform.SetPositionAndRotation(atingido.transform.position, atingido.transform.rotation);
            //  efeitinho.transform.LookAt(personagem.transform);
            //  efeitinho.Play();
        }
        foreach (KeyValuePair<string, bool> elemento in dictCubos)
        {
            if (!elemento.Value)
            {
                olhouTodos = false;

            }
        }
        bool aux = false; //possivel bug ... investigar terça
        if (ps != null)
        {
            aux = ps.isStopped;
        }
        OlhouTodos = olhouTodos && aux;
    }
}
