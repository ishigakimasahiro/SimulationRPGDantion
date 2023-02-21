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
}
