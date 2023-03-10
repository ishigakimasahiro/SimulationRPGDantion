using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キャラすべてを管理する
public class CharactersManager : MonoBehaviour
{
    public List<Character> characters = new List<Character>();

    void Start()
    {
        GetComponentsInChildren(characters);
    }

    // 座標が一致するキャラを渡す
    public Character GetCharacter(Vector2Int pos)
    {
        foreach(var character in characters)
        {
            if(character.Position==pos)
            {
                return character;
            }
        }
        return null;
    }
}
