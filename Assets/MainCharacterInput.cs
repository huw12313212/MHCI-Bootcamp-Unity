﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainCharacterInput : MonoBehaviour {

	public float RotationSpeed;
	public float MoveSpeed;
	public float JumpSpeed;

	public List<Collider> floor = new List<Collider>();

	// Use this for initialization
	void Start () {
	
	}



	void OnCollisionEnter(Collision collision) 
	{

		Vector3 normal = collision.contacts [0].normal;

		if (Vector3.Dot (normal, new Vector3 (0, 1, 0)) > 0.8) 
		{
			floor.Add(collision.collider);
		}
	}


	void OnCollisionExit(Collision collisionInfo) 
	{
		floor.Remove(collisionInfo.collider);
	}

	// Update is called once per frame
	void Update () {

		/*
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			Debug.Log("W Down");
			
		}*/

		Vector3 VelocityXZ = Vector3.zero;
		float VelocityY = rigidbody.velocity.y;

		if (Input.GetKey (KeyCode.W)) 
		{
			Debug.Log("W pressed");
			VelocityXZ += MoveSpeed * transform.forward;
				
		}
		
		if (Input.GetKey (KeyCode.S)) 
		{
			Debug.Log("W pressed");
			
			VelocityXZ = -MoveSpeed * transform.forward;
		}

		if (floor.Count > 0) {
						if (Input.GetKeyDown (KeyCode.Space)) {
								Debug.Log ("W pressed");
			
								VelocityY += (JumpSpeed * transform.up).y;
						}
				}

		rigidbody.velocity = new Vector3 (VelocityXZ.x,VelocityY,VelocityXZ.z);


		/*
		if (Input.GetKeyUp(KeyCode.W)) 
		{
			Debug.Log("W Up");
			
		}*/
	
	}
}