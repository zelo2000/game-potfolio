using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour {
    public float Speed = 1.0f;
    private Material material;
	// Use this for initialization
	void Start () {
        material = GetComponent<MeshRenderer>().sharedMaterial;
	}
	
	// Update is called once per frame
	void Update () {
        material.mainTextureOffset = new Vector2(0.0f, Time.time*Speed);
	}
}
