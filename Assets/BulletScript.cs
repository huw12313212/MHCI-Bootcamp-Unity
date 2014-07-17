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

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.layer == LayerMask.NameToLayer ("Monster")) 
		{
			MonsterScript monster = other.gameObject.GetComponent<MonsterScript>();	
			monster.Hurt(AttackValue);
		}

	}


	void KillMyself()
	{
		GameObject.Destroy(this.gameObject);
	}
}
