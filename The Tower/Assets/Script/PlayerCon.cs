using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour {

    public LayerMask mask;
    public Camera camera;
    public Rigidbody rb;
    public float speed,JumpPower;
    public GameObject[] itemtype;
    public GameObject[] items;

    private bool jumpkey;
    
	// Use this for initialization
	void Start () {
        items = new GameObject[3];
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Itemes();
        Jump();
    }
    void Jump()
    {
        RaycastHit hit;
        Vector3 under=new Vector3(0,-1,0);
       

        if (Physics.BoxCast(transform.position,Vector3.one*0.5f,under,out hit, Quaternion.identity, 1f, LayerMask.GetMask("Ground")))
        {
            jumpkey = true;
            speed = 0.3f;
        }
        else if (Physics.BoxCast(transform.position, Vector3.one * 0.5f, under, out hit, Quaternion.identity, 1f, LayerMask.GetMask("Items")))
        {
            jumpkey = true;
            speed = 0.3f;

        }
        else
        {
            jumpkey = false;
            speed = 0.1f;

        }
    }

    void Move(){
        if (Input.GetKey("a"))
        {
            transform.position-=this.transform.right*speed;
        }
        if (Input.GetKey("d"))
        {
            transform.position += this.transform.right*speed;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= this.transform.forward*speed;
        }
        if (Input.GetKey("w"))
        {
            transform.position += this.transform.forward*speed;
        }
        if (jumpkey)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(0, JumpPower, 0);
            }
        }
    }
    void Itemes()
    {
        Ray ray = new Ray(transform.position, camera.transform.forward);
        RaycastHit hit;


        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 2.0f, mask))
            {
                
                for(int i = 0; i < items.Length; i++)
                {
                    if (items[i] == null)
                    {
                        if (hit.collider.tag == "Block")
                        {
                            items[i] = itemtype[0];
                            
                        }
                        
                        Destroy(hit.collider.gameObject);
                        break;
                    }
                }
                

            }
        }
    }
}
