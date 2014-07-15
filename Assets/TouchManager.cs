using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

	public MikeManager mikeManager;

	public bool MousePressed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			MousePressed = true;

			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
			// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
			if(hitInfo)
			{
				if(hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Mike"))
				{
					//Debug.Log("Mike Clicked");
					mikeManager.ClickDown(hitInfo.transform.gameObject);
				}
				else if(hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Reset"))
				{
					//Debug.Log ("reset click");

					ResetManager manager = hitInfo.transform.gameObject.GetComponent<ResetManager>();
					manager.ResetAll();
				}
			}
		}
		else if (Input.GetMouseButtonUp(0)) 
		{
			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			Vector3 world = Camera.main.ScreenToWorldPoint(pos);
			world.z = 0;
			mikeManager.ClickUp(world);

			MousePressed = false;
		}
		else if (MousePressed) 
		{
			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			Vector3 world = Camera.main.ScreenToWorldPoint(pos);
			world.z = 0;
			mikeManager.drag(world);
		}

	}
}
