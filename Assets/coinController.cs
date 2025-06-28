using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    HashSet<Vector2> tmpHs;
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tmp = player.transform.position - transform.position;
        float len = tmp.magnitude;
        if (len < 1.0f)
        {
            tmpHs = GameObject.Find("coinGenerator").GetComponent<coinGenerator>().visitedPos;
            tmpHs.Remove((Vector2)transform.position);
            Destroy(gameObject);
        }
    }
}
