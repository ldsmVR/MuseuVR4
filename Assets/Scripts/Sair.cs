using UnityEngine;
//classe mais complexa de todas , serve simplesmente para sair do programa, não funciona no editor, só funciona na versão compilada 
/// <summary>
/// Classe para sair, somente funciona em uma versão compilada
/// </summary>
public class Sair : MonoBehaviour
{
    /// <summary>
    ///  Esse método deve ser pelo botão de sair
    /// </summary>
    public void quit() 
    {
        Application.Quit();
    }
}
