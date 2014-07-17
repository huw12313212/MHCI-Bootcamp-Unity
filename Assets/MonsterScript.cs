using UnityEngine;
using System.Collections;

public class MonsterScript : MonoBehaviour {

	public float HP;
	public float DeadBodyIdleTime;
	public bool Hurting = false;

	AnimationClip hitClip;
	AnimationClip idleClip;
	AnimationClip dieClip;


	public void Hurt(float attackValue)
	{
		if (!Hurting)
		{
			HP-=attackValue;

			if(HP<=0)
			{
				animation.Play(dieClip.name);
				Hurting = true;
				Invoke ("Dying",dieClip.length+DeadBodyIdleTime);
				Invoke ("StopAnimation",dieClip.length-0.05f);
			}
			else
			{
				animation.Play(hitClip.name);
				Hurting = true;
				Invoke ("BackToNormal", hitClip.length);
			}
		}
	}

	void Dying()
	{
		GameObject.Destroy(this.gameObject);
	}

	void StopAnimation()
	{
		
		animation.Stop();
	}
	

	void BackToNormal()
	{
		Hurting = false;

		animation.Play (idleClip.name);
	}

	// Use this for initialization
	void Start () {
	
		hitClip = animation.GetClip("Hit");
		idleClip = animation.GetClip("Idle_01");
		dieClip = animation.GetClip("Die");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
