using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterController : MonoBehaviour
{
    // Start is called before the first frame update
    int[] dx = { 0, 0, -1, 1 };
    int[] dy = { 1, -1, 0, 0 };
    bool randomMove = false;
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
        Debug.Log(dis + '\n');
        Vector2 tmp = (Vector2)transform.position;
        for (int i = 0; i < 4; i++)
        {
            float minLen = dis;
            Vector2 nextPos = new Vector2(transform.position.x + dx[i], transform.position.y + dy[i]);
            if (!CheckBound(nextPos)) continue;
            if (!player.GetComponent<playerController>().check_move(nextPos)) continue;
            Vector2 tmp2 = nextPos - (Vector2)player.transform.position;
            float dis2 = tmp2.magnitude; 
            if(dis > 4.0f)
            {
                if(dis > dis2) tmp = nextPos;
            }
            else if(!randomMove)
            {
                int pick = Random.Range(0, 2);
                if (pick == 1) tmp = nextPos;
            }
        }

        transform.position = new Vector3(tmp.x,tmp.y,transform.position.z);
    }
    void Update()
    {
        
    }
}
