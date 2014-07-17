using UnityEngine;
using System.Collections;

public class ViewportController : MonoBehaviour {

	public Vector3 lastPosition;
	public Transform MainPlayerTransform;


	// Use this for initialization
	void Start () {
		lastPosition = Input.mousePosition;
	}

    float elevationAngle = 0;

	// Update is called once per frame
	void Update () {
	
		Vector3 mouseDiff = Input.mousePosition - lastPosition;


		MainPlayerTransform.Rotate (new Vector3(0,mouseDiff.x,0));



		if(Mathf.Abs(elevationAngle-mouseDiff.y)<=90)
		{
			transform.Rotate(new Vector3(-mouseDiff.y,0,0));
			elevationAngle += -mouseDiff.y;
		}

		lastPosition = Input.mousePosition ;


	}
}
