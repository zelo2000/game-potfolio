using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public Vector3 Velocity;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = Velocity;
    }
	
	
}
