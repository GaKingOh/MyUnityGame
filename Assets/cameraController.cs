using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = player.transform.position;

        transform.position = new Vector3(tmp.x, tmp.y, transform.position.z);
    }
}
