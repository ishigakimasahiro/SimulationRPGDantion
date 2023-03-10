using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] Cursor cursor;
    [SerializeField] CharactersManager charactersManager;
    [SerializeField] MapGenerator mapGenerator;

    Character selectedCharacter;
    List<TileObj> tileObjs = new List<TileObj>();
    List<TileObj> movableTiles = new List<TileObj>();

    private void Start()
    {
        tileObjs = mapGenerator.Generator();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(clickPosition, Vector2.down);

            // Rayを飛ばしてヒットしたタイルを取得
            if (hit2D && hit2D.collider)
            {
                cursor.SetPosition(hit2D.transform);
                TileObj tileObj = hit2D.collider.GetComponent<TileObj>();
                // 選択タイルの座標
                //Debug.Log(tileObj.positionInt);
                // キャラの座標
                // ヒットしたタイル上のキャラを取得
                Character character = charactersManager.GetCharacter(tileObj.positionInt);
                if(character)
                {
                    Debug.Log("いる");
                    // 選択キャラの保持
                    selectedCharacter = character;
                    ResetMovablePanels();  // false
                    // 移動範囲表示
                    ShowMovablePanels(selectedCharacter);
                }
                else
                {
                    Debug.Log("選択したタイルにキャラがいない");
                    // キャラを保持しているなら、選択したタイルの場所に移動させる
                    if(selectedCharacter)
                    {
                        // クリックしたtileObjが移動範囲に含まれるなら
                        if(movableTiles.Contains(tileObj))
                        {
                            // selectedCharacterをtileObjまで移動
                            selectedCharacter.Move(tileObj.positionInt);
                        }
                        ResetMovablePanels();  // false
                        selectedCharacter = null;
                    }
                }
            }
        }
    }

    void ShowMovablePanels(Character character)
    {
        // centerPosから上下左右
        {
            movableTiles.Add(tileObjs.Find(tile => tile.positionInt == character.Position));
            movableTiles.Add(tileObjs.Find(tile => tile.positionInt == character.Position+Vector2Int.up));
            movableTiles.Add(tileObjs.Find(tile => tile.positionInt == character.Position+Vector2Int.down));
            movableTiles.Add(tileObjs.Find(tile => tile.positionInt == character.Position+Vector2Int.left));
            movableTiles.Add(tileObjs.Find(tile => tile.positionInt == character.Position+Vector2Int.right));
        };

        foreach (var tile in movableTiles)
        {
            tile.ShowMovablePanel(true);
        }
    }

    void ResetMovablePanels()
    {
        foreach (var tile in movableTiles)
        {
            tile.ShowMovablePanel(false);
        }
        movableTiles.Clear();
    }
}
