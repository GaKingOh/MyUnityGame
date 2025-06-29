using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    // -11 ~ 11 : x, -7 ~ 6 : y
    GameObject player;
    public GameObject coinPrefab;
    playerController script;
    public HashSet<Vector2> visitedPos;
    void Start()
    {
        player = GameObject.Find("player");
        script = player.GetComponent<playerController>();
        visitedPos = new HashSet<Vector2>();

        while(visitedPos.Count != 150)
        {
            Vector2 pos = new Vector2(Random.Range(-10, 11), Random.Range(-6, 6));
            if (!script.check_move(pos)) continue;
            if (visitedPos.Contains(pos)) continue;
            Instantiate(coinPrefab);
            coinPrefab.transform.position = (Vector3)pos;
            visitedPos.Add(pos);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
