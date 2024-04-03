using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


/// <summary>
///  Classe muito relevante para a movimentação 
///  Inserir esse componente em um VRrig 
///  Recebe o controle, o botão que aciona o teleport e etc 
///  
/// </summary>
public class ControleTeleport : MonoBehaviour 
{
    // Start is called before the first frame update
    public XRController teleport; // mão do teleport
    public InputHelpers.Button telleportBtn; // botão que habilita o teleport
    public float activationLimit = 0.2f; // para habilitar o raio
    public XRRayInteractor maoEsquerdaUI; //raio mão esquerda 
    /// <summary>
    /// ativa e desativa os statos do teleport 
    /// </summary>
    public bool teleportAtivo { get; set; } = true; // ativar/desativar o teleport se estou segurando algo
    /// <summary>
    ///  Garante se o teleport esta hailitado ou não
    /// </summary>
    public bool teleportHabilitado = true; //booleato se está habilitado ou não verificar se não pode ser private uma vez que tenho o setter ...

    /// <summary>
    /// Setter do habilitar teleport
    /// </summary>
    public void habilitarTeleport() //troca estado da habilitacao
    {
        teleportHabilitado = !teleportHabilitado;
    }

   /// <summary>
   /// Verifica se estou querendo efetuar o teleport 
   /// param
   /// </summary>
   /// <param name="controle"></param> controle que irei ler 
   /// <returns>Booleano para executar de fato o teleport</returns>
    public bool checkActivation(XRController controle) { // verifica se estou ativando  o teleport, passei do meu limite de ativacao
        InputHelpers.IsPressed(controle.inputDevice, telleportBtn, out bool isPressed, activationLimit);  // verifica o quão pressionado esta o trigger;
        return isPressed;
    }

    /// <summary>
    /// Executa  de Fato o teleport 
    /// </summary>
    void Update()
    {   
        // quatrovariáveis auxiliares para poder usar o TryGetHitInfo, ele preenche elas, basicamente passo como ponteiro para esse metodo 
        Vector3 pos = new Vector3();
        Vector3 norm = new Vector3();
        int indice=0;
        bool valido=false;
        if (teleport) { // se existe o objeto 
            bool sobreUI = maoEsquerdaUI.TryGetHitInfo(out pos, out norm, out indice, out valido);
            
            teleport.gameObject.SetActive(teleportAtivo && checkActivation(teleport) &&!sobreUI && teleportHabilitado); // verifico se passa do limite e dai ativo se esta atyivo e  etc 
        }
    }
}
