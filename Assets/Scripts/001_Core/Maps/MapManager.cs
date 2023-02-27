using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] Cursor cursor;
    [SerializeField] CharactersManager charactersManager;
    [SerializeField] MapGenerator mapGenerator;

    Character selectedCharacter;

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

            // Ray���΂��ăq�b�g�����^�C�����擾
            if (hit2D && hit2D.collider)
            {
                cursor.SetPosition(hit2D.transform);
                TileObj tileObj = hit2D.collider.GetComponent<TileObj>();
                // �I���^�C���̍��W
                //Debug.Log(tileObj.positionInt);
                // �L�����̍��W
                // �q�b�g�����^�C����̃L�������擾
                Character character = charactersManager.GetCharacter(tileObj.positionInt);
                if(character)
                {
                    Debug.Log("����");
                    // �I���L�����̕ێ�
                    selectedCharacter = character;
                }
                else
                {
                    Debug.Log("�I�������^�C���ɃL���������Ȃ�");
                    // �L������ێ����Ă���Ȃ�A�I�������^�C���̏ꏊ�Ɉړ�������
                    if(selectedCharacter)
                    {
                        // selectedCharacter��tileObj�܂ňړ�
                        selectedCharacter.Move(tileObj.positionInt);
                        selectedCharacter = null;
                    }
                }
            }
        }
    }
}
