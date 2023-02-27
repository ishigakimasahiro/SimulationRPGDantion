using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �L�����N�^�[�Ǘ�
public class Character : MonoBehaviour
{
    [SerializeField] Vector2Int positionInt;

    public Vector2Int Position { get => positionInt; }

    void Start()
    {
        transform.position = (Vector2)positionInt;
    }

    // �L�������ړ�
    public void Move(Vector2Int pos)
    {
        positionInt = pos;
        transform.position = (Vector2)positionInt;
    }
}
