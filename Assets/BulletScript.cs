using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float AttackValue;
	public float AliveTime;

	// Use this for initialization
	void Start () 
	{
		Invoke ("KillMyself",AliveTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void KillMyself()
	{
		GameObject.Destroy(this.gameObject);
	}
}
