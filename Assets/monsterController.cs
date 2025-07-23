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
     *  MoveMon �Լ� ���͸� �����̴� �Լ�
     * �÷��̾ �������� �� �� ��ġ�� �������� ������ ���Ͱ� ������ ��ġ�� ������
     * �÷��̾��� ��ġ�������� ���� ������Ʈ ������ ��ġ���� bfs�� �����ؼ� ������ ��
     * queue�� �� �� {���� x,y}
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
