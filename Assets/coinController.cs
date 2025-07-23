using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject[] enemies;
    GameObject GameDirector;
    HashSet<Vector2> tmpHs;
    void Start()
    {
        player = GameObject.Find("player");
        tmpHs = GameObject.Find("coinGenerator").GetComponent<coinGenerator>().visitedPos;
        GameDirector = GameObject.Find("GameDirector");
        enemies = new GameObject[4];
        for(int i=0;i<1; i++)
        {
            enemies[i] = GameObject.Find("monster_" + (i + 1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tmp = player.transform.position - transform.position;
        float len = tmp.magnitude;
        if (len < 1.0f)
        {
            tmpHs.Remove((Vector2)transform.position);
            GameDirector.GetComponent<GameDirector>().AddCoin();
            Destroy(gameObject);
        }

        for (int i = 0; i < 1; i++)
        {
            Vector2 tmp2 = enemies[i].transform.position - transform.position;
            float len2 = tmp2.magnitude;
            if(len2 < 1.0f)
            {
                GameDirector.GetComponent<GameDirector>().AddCoin();
                tmpHs.Remove((Vector2)transform.position);
                Destroy(gameObject);
            }
        }
    }
}
