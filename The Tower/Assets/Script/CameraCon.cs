using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour {
    public Transform verRot;
    public Transform horRot;
    public float bectorspeed=1.0f;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");
        verRot.transform.Rotate(0, X_Rotation*bectorspeed, 0);
        horRot.transform.Rotate(-Y_Rotation*bectorspeed, 0, 0);
    }
}
