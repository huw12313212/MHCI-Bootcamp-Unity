using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackRange : MonoBehaviour {

	public List<GameObject>touched = new List<GameObject>();

	public LayerMask mask;

	void OnTriggerEnter(Collider other) 
	{


		if ((1<<other.gameObject.layer & mask.value) > 0)
		{
			touched.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other) 
	{
		touched.Remove(other.gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
