using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap tilemap;
    public GameObject[] enemies;
    bool move = false;
    void Start()
    {
        
    }
    void MoveEnemies()
    {
        for (int i = 0; i<4;i++)
        {
            enemies[i].GetComponent<monsterController>().MoveMon();
        }
    }
    bool check_bound(Vector2 tmp)
    {
        // -11<=x<=11
        // -6<=y<=6

        if (!(-11 <= tmp.x && tmp.x <= 11 && -7 <= tmp.y && tmp.y <= 6)) return false;
        return true;
    }
    public bool check_move(Vector2 tmp)
    {
        Vector3 tmp2 = new Vector3(tmp.x,tmp.y,transform.position.z);
        Vector3Int cellPos = tilemap.WorldToCell(tmp2);
        TileBase tile = tilemap.GetTile(cellPos);

        if (tile != null)
        {
            if (tile.name == "corner (2)" || tile.name == "cross" || tile.name == "wall" || tile.name == "wall_edge") return false;
        }
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 tmp = new Vector2(transform.position.x, transform.position.y);
        move = false;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            tmp.y += 1.0f;
            move = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tmp.y += -1.0f;
            move = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tmp.x += -1.0f;
            move = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            tmp.x += 1.0f;
            move = true;
        }

        if(tmp.y == -2 && tmp.x==12)
        {
            transform.position = new Vector3(-11f, tmp.y, transform.position.z);
            MoveEnemies();
        }

        if(tmp.y==-2 && tmp.x==-12)
        {
            transform.position = new Vector3(11f, tmp.y, transform.position.z);
            MoveEnemies();
        }
        if (!(check_bound(tmp))) return;
        if (!check_move(tmp)) return;
        transform.position = new Vector3(tmp.x,tmp.y, transform.position.z);
        if(move) MoveEnemies();
    }
}
