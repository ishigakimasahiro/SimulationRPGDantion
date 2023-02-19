using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �}�b�v����
public class MapGenerator : MonoBehaviour
{
    [SerializeField] TileObj GreenObjPrefab;
    [SerializeField] TileObj Green2ObjPrefab;
    [SerializeField] TileObj WaterObjPrefab;
    [SerializeField] Transform tileParent;
    int WIDTH = 15;
    int HEIGHT = 9;
    int GREEN2_RATE = 10;
    int WATER_RATE = 33;

    void Start()
    {
        Generator();
    }

    public void Generator()
    {
        Vector2 offset = new Vector2(-WIDTH / 2, -HEIGHT / 2);
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                Vector2 pos = new Vector2(x, y)+offset;
                int rate = Random.Range(0, 100);
                TileObj tileObj = null;
                if (rate < GREEN2_RATE)
                {
                    tileObj=Instantiate(GreenObjPrefab, pos, Quaternion.identity, tileParent);
                }
                else if (rate < WATER_RATE)
                {
                    tileObj=Instantiate(Green2ObjPrefab, pos, Quaternion.identity, tileParent);
                }
                else
                {
                    tileObj=Instantiate(WaterObjPrefab, pos, Quaternion.identity, tileParent);
                }
                tileObj.positionInt = new Vector2Int((int)pos.x,(int)pos.y);
            }
        }
    }

}
