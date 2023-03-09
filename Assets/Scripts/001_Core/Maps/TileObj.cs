using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 番号をつける
public class TileObj : MonoBehaviour
{
    public Vector2Int positionInt;

    [SerializeField] GameObject movablePanel;

    public void ShowMovablePanel(bool isActive)
    {
        movablePanel.SetActive(isActive);
    }
}
