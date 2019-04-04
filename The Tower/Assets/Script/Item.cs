using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public PlayerCon player;
    private int select;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("1"))
        {
            select = 0;
        }
        if (Input.GetKeyDown("2"))
        {
            select = 1;
        }
        if (Input.GetKeyDown("3"))
        {
            select = 2;
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (player.items[select] != null)
            {
                if (player.items[select].tag == "Block")
                {
                    Vector3 pos = transform.position + transform.forward * 2;
                    Instantiate(player.itemtype[0], pos, Quaternion.identity);
                    player.items[select] = null;
                }
            }
        }
    }
}
