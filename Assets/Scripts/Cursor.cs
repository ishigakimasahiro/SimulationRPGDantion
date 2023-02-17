using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public void SetPosition(Transform target)
    {
        transform.position = target.position;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("ç∂ÉNÉäÉbÉNÇµÇΩÇÊ");

            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(clickPosition, Vector2.down);

            if (hit2D && hit2D.collider)
            {
                SetPosition(hit2D.transform);
            }
        }
    }
}
