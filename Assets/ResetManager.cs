using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class ResetManager : MonoBehaviour {

	public List<GameObject> DynamicObjects;

	public List<ObjectData> Datas;

	public MikeManager mikeManager;

	public struct ObjectData
	{
		public Vector3 position;
		public Quaternion rotation;
		public bool isKinect;
		public Vector3 velocity;
		public float angularVelocity;
	}


	public void FindAllRigidBody()
	{
		Rigidbody2D[] allRigidBody =  GameObject.FindObjectsOfType<Rigidbody2D>();

		DynamicObjects.Clear();

		foreach (Rigidbody2D rigid in allRigidBody) 
		{
			DynamicObjects.Add(rigid.gameObject);
		}

	}

	public void RememberAll()
	{
		Datas = new List<ObjectData>();
		foreach (GameObject o in DynamicObjects) 
		{
			ObjectData data = new ObjectData();

			data.position = o.transform.position;
			data.rotation = o.transform.rotation;
			data.isKinect = o.rigidbody2D.isKinematic;
			data.velocity = o.rigidbody2D.velocity;
			data.angularVelocity = o.rigidbody2D.angularVelocity;
			Datas.Add(data);
		}

		Debug.Log ("Remember?");
	}


	public void ResetAll()
	{
		mikeManager.curentIndex = 0;

		for (int i =0;i<DynamicObjects.Count;i++) 
		{
			ObjectData data = Datas[i];
			GameObject o = DynamicObjects[i];
			
		    o.transform.position =	data.position;
			o.transform.rotation = data.rotation;
			o.rigidbody2D.isKinematic = data.isKinect;
			o.rigidbody2D.velocity= data.velocity;
			o.rigidbody2D.angularVelocity=data.angularVelocity;
			//Datas.Add(data);
		}
	}

	// Use this for initialization
	void Start () 
	{
		RememberAll ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
