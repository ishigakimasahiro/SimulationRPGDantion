using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum Phase
    {
        PlayerCharacterSelection,
        PlayerCharacterMoveSelection,
        EnemyCharacterSelection,
        EnemyCharacterMoveSelection,
    }
    [SerializeField] Phase phase;

    private void Start()
    {
        phase = Phase.PlayerCharacterSelection;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlayerClickAction();
        }
    }

    void PlayerClickAction()
    {
        switch(phase)
        {
            case Phase.PlayerCharacterSelection:
                PlayerCharacterSelection();
                break;
            case Phase.PlayerCharacterMoveSelection:
                PlayerCharacterMoveSelection();
                break;
        }
    }

    void PlayerCharacterSelection()
    {
        phase = Phase.PlayerCharacterMoveSelection;
    }

    void PlayerCharacterMoveSelection()
    {
        phase = Phase.EnemyCharacterSelection;
    }
}
