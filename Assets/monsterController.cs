using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterController : MonoBehaviour
{
    // Start is called before the first frame update
    int[] dx = { 0, 0, -1, 1 };
    int[] dy = { 1, -1, 0, 0 };
    GameObject player;
    void Start()
    {
        player = GameObject.Find("player");        
    }
    bool CheckBound(Vector2 pos)
    {
        return -11 <= pos.x && pos.x <= 11 && -6 <= pos.y && pos.y <= 6;
    }
    public void MoveMon()
    {
        Vector2 diff = transform.position - player.transform.position; 
        float dis = diff.magnitude;
        float minLen = dis;

        Vector2 tmp = (Vector2)transform.position;
        for (int i = 0; i < 4; i++)
        {
            Vector2 nextPos = new Vector2(transform.position.x + dx[i], transform.position.y + dy[i]);
            if (!CheckBound(nextPos)) continue;
            if (!player.GetComponent<playerController>().check_move(nextPos)) continue;
            Vector2 tmp2 = nextPos - (Vector2)player.transform.position;
            float dis2 = tmp2.magnitude; 
            if(dis > 8.0f && minLen > dis2)
            {
                minLen = dis2;
                tmp = nextPos;
            }
        }

        transform.position = new Vector3(tmp.x,tmp.y,transform.position.z);
    }
    void Update()
    {
        
    }
}
