using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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
    /*
     *  MoveMon 함수 몬스터를 움직이는 함수
     * 플레이어가 움직였을 때 그 위치를 기준으로 앞으로 몬스터가 가야할 위치를 결정함
     * 플레이어의 위치에서부터 현재 오브젝트 몬스터의 위치까지 bfs를 실행해서 역추적 함
     * queue에 들어갈 값 {현재 x,y}
     * 
     * 
     */
    
    public void MoveMon()
    {
        Vector2 start = (Vector2)player.GetComponent<playerController>().transform.position;
        Queue<Vector2> q = new Queue<Vector2>();
        q.Enqueue(start);

        HashSet<Vector2> visited = new HashSet<Vector2>();
        visited.Add(start);

        while(q.Any()==true)
        {
            Vector2 here = q.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                Vector2 next = here + new Vector2(dx[i], dy[i]);
                if (!CheckBound(next)) continue;
                if(!player.GetComponent<playerController>().check_move(next)) continue;
                if (visited.Contains(next)) continue;

                if(next==(Vector2)transform.position)
                {
                    transform.position = new Vector3(here.x, here.y, transform.position.z);
                    return;
                }
                q.Enqueue(next);
                visited.Add(next);
            }
        }
    }
    void Update()
    {
        
    }
}
