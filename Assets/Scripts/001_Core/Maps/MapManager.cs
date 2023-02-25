using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] Cursor cursor;
    [SerializeField] CharactersManager charactersManager;
    [SerializeField] MapGenerator mapGenerator;

    private void Start()
    {
        mapGenerator.Generator();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(clickPosition, Vector2.down);

            if (hit2D && hit2D.collider)
            {
                cursor.SetPosition(hit2D.transform);
                TileObj tileObj = hit2D.collider.GetComponent<TileObj>();
                // 選択タイルの座標
                //Debug.Log(tileObj.positionInt);
                // キャラの座標
                Character character = charactersManager.GetCharacter(tileObj.positionInt);
                if(character)
                {
                    Debug.Log("いる");
                }
                else
                {
                    Debug.Log("いない");
                }
            }
        }
    }
}
