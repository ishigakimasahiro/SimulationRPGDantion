using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キャラクター管理
public class Character : MonoBehaviour
{
    [SerializeField] Vector2Int positionInt;

    public Vector2Int Position { get => positionInt; }

    void Start()
    {
        transform.position = (Vector2)positionInt;
    }

    // キャラを移動
    public void Move(Vector2Int pos)
    {
        positionInt = pos;
        transform.position = (Vector2)positionInt;
    }
}
