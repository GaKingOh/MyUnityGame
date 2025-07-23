using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Score;
    GameObject coinGenerator;
    int coin = 150;
    void Start()
    {
        Score = GameObject.Find("score");
        coinGenerator = GameObject.Find("coinGenerator");
    }

    // Update is called once per frame
    public void AddCoin()
    {
        coin--;
        Score.GetComponent<Text>().text = coin+"개 남았어!";
    }
    void Update()
    {            

    }
}
