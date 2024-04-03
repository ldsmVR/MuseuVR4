using UnityEngine;
// carregando os pacotes necessarios 
using UnityEngine.XR; 
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Classe para o movimento contínuo 
/// </summary>
public class MovimentoContinuo : MonoBehaviour
{
    public XRNode inputSource; // controle que irei ler
    private Vector2 inputDoControle; // para receber os eixo do controle 
    private CharacterController personagem; // controle do personagem/pessoa 3d virtual do unity
    public float velocidade = 1.5f; // velocidade de movimento da pessoa 
    private XRRig rig; // possibilita pegar a camera 
    public float gravidade = -9.81f; // gravidade 
    public LayerMask planoChao; // plano onde a pessoa pode se mover
    private float velocidadeDeQueda = 0f;
    public bool habilitado { get; set; }


    void Start()
    {
        habilitado = true;
        personagem = GetComponent<CharacterController>();//incia meu personagem
        rig = GetComponent<XRRig>(); // incia a camera
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource); // inicia  os dispositivos 
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputDoControle);
    }
     private void FixedUpdate() // essa função é chamada cada vez que rodamos a física do jgo
    {

        if (habilitado) {
            CapsuleFollowHeadset(); // função para o caracter  controller seguir o HMD
            Quaternion posCabeca = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
            Vector3 direcao = posCabeca * (new Vector3(inputDoControle.x, 0, inputDoControle.y));
            personagem.Move(direcao * Time.fixedDeltaTime * velocidade); //movendo o personagem  em x,z
            bool estaNoChao = VerSeEstouNoChao();
            if (estaNoChao)
            {
                velocidadeDeQueda = 0f;
            }
            else
            {
                velocidadeDeQueda += gravidade * Time.fixedDeltaTime;
             //   Debug.Log("velocidade de queda" + velocidadeDeQueda);
            }
            personagem.Move(Vector3.up * Time.fixedDeltaTime * velocidadeDeQueda);
        }
    }
    private bool VerSeEstouNoChao() {// essa função vai ver se estou no chão, para isso tem que lançar raios suficientes sobre uma superfície.
        Vector3 rayStart = transform.TransformPoint(personagem.center); //  ponto central do corpo 
        float comprimentoDosRaios = personagem.center.y+0.01f; // com isso garanto que vou estar medindo uma distância um pouco maior 
        bool atingiu = Physics.SphereCast(rayStart, personagem.radius, Vector3.down , out RaycastHit hitINFO , comprimentoDosRaios , planoChao);
        //Debug.Log("Chão  =  " +atingiu);
        return atingiu;
    }
    /// <summary>
    /// possibilita que o colider que representa o personagem ande sempre junto com o HMD
    /// </summary>
    public void CapsuleFollowHeadset() // ajeita a posição do personagem para sempre ser a mesma da camera 
    {
        personagem.height = rig.cameraInRigSpaceHeight + 0.3f; 
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position); //da a posicao local se fosse um filho da camera 
        personagem.center = new Vector3(capsuleCenter.x, personagem.height / 2 + personagem.skinWidth, capsuleCenter.z); //skinwidth é para evitar um bug

        
    }


}
