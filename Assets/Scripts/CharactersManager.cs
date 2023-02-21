using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ƒLƒƒƒ‰‚·‚×‚Ä‚ğŠÇ—‚·‚é
public class CharactersManager : MonoBehaviour
{
    public List<Character> characters = new List<Character>();

    void Start()
    {
        GetComponentsInChildren(characters);
    }

    // À•W‚ªˆê’v‚·‚éƒLƒƒƒ‰‚ğ“n‚·
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
