using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class MikeManager : MonoBehaviour {

	public List<GameObject> mikes;
	public int curentIndex;
	public GameObject MikeReadyPosition;
	public float radious;
	public float speed;

	public bool Draging = false;

	public void ClickDown(GameObject mike)
	{
		if (mikes.IndexOf(mike)==curentIndex) 
		{
			Draging = true;
		}
	}

	public void drag(Vector3 worldPosition)
	{
		if(Draging)
		{
			GameObject currentMike = mikes[curentIndex];
			Vector3 difVec3 = worldPosition - MikeReadyPosition.transform.position;

			if (difVec3.magnitude < radious) 
			{
				mikes [curentIndex].transform.position = worldPosition;
			}
			else
			{
				mikes [curentIndex].transform.position = MikeReadyPosition.transform.position + difVec3.normalized * radious;
			}
		}
	}

	public void ClickUp(Vector3 worldPosition)
	{
		if (Draging) 
		{
			GameObject currentMike = mikes[curentIndex];
			Vector3 difVec3 = MikeReadyPosition.transform.position - currentMike.transform.position;
			float powerRatio = difVec3.magnitude / radious;

			currentMike.rigidbody2D.isKinematic = false;

			Vector3 vec = difVec3.normalized*powerRatio*speed;

			currentMike.rigidbody2D.velocity = vec;

			curentIndex++;

			if(curentIndex<mikes.Count)
			{
				ResetNewMike();
			}

			Draging = false;
		}
	}

	void ResetNewMike()
	{
		GameObject currentMike = mikes[curentIndex];
		currentMike.collider2D.enabled = true;

		HOTween.To (currentMike.transform, 0.5f, "position", MikeReadyPosition.transform.position);
	}

	// Use this for initialization
	void Start () 
	{
		HOTween.Init(true, true, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
