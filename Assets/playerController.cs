using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool check_bound(Vector2 tmp)
    {
        // -11<=x<=11
        // -6<=y<=6

        if (!(-11 <= tmp.x && tmp.x <= 11 && -7 <= tmp.y && tmp.y <= 6)) return false;
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 tmp = new Vector2(transform.position.x, transform.position.y);
        if (Input.GetKeyDown(KeyCode.UpArrow)) tmp.y += 1.0f;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) tmp.y += -1.0f;
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) tmp.x += -1.0f;
        else if (Input.GetKeyDown(KeyCode.RightArrow)) tmp.x += 1.0f;

        if (!(check_bound(tmp))) return;

        transform.position = new Vector3(tmp.x,tmp.y, transform.position.z);
    }
}
