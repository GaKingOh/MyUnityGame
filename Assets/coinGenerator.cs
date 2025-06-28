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


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(visitedPos.Count);
        Vector2 pos = new Vector2(Random.Range(-11, 12), Random.Range(-7, 7));
        if (!script.check_move(pos)) return;
        if (visitedPos.Contains(pos)) return;
        if (visitedPos.Count == 20) return;
        Instantiate(coinPrefab);
        coinPrefab.transform.position = (Vector3)pos;
        visitedPos.Add(pos);
    }
}
