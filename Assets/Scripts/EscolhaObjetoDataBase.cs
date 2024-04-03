using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class EscolhaObjetoDataBase : ScriptableObject
{
    public escolhaDeObjeto[] character;

    public int CharacterCount
    {
        get
        {
            return character.Length;
        }
    }

    public escolhaDeObjeto GetCharecter (int index)
    {
        return character[index];
    }
}
