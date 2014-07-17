using UnityEngine;
using System.Collections;

public class MonsterScript : MonoBehaviour {

	public float HP;
	public float DeadBodyIdleTime;
	public bool Hurting = false;
	public float moveSpeed;
	public bool angry;
	public bool attacking;

	AnimationClip hitClip;
	AnimationClip idleClip;
	AnimationClip dieClip;
	AnimationClip attackClip;
	AnimationClip moveClip;

	public GameObject mainCharacter;
	public AttackRange attackrange;
	public GameManager manager;


	public void Hurt(float attackValue)
	{
		angry = true;
		if (!Hurting)
		{
			HP-=attackValue;

			if(HP<=0)
			{
				animation.Play(dieClip.name);
				Hurting = true;
				CancelInvoke();
				Invoke ("Dying",dieClip.length+DeadBodyIdleTime);
				Invoke ("StopAnimation",dieClip.length-0.05f);
				//collider.enabled = false;
				//rigidbody.useGravity = false
			}
			else
			{
				animation.Play(hitClip.name);
				Hurting = true;
				CancelInvoke();
				Invoke ("BackToNormal", hitClip.length);
			}
		}
	}

	void Dying()
	{
		manager.monsterCount--;
		GameObject.Destroy(this.gameObject);
	}

	void StopAnimation()
	{
		animation.Stop();
	}
	

	void BackToNormal()
	{
		Hurting = false;
		attacking = false;
		animation.Play (idleClip.name);
	}

	// Use this for initialization
	void Start () {
	
		hitClip = animation.GetClip("Hit");
		idleClip = animation.GetClip("Idle_01");
		dieClip = animation.GetClip("Die");
		attackClip = animation.GetClip ("Attack_01");
		moveClip = animation.GetClip("Run");

	}


	
	// Update is called once per frame
	void Update () {
	
		if(angry)
		{
			if (!Hurting&&!attacking) 
			{
				if(attackrange.touched.Count>0)
				{
					Attack();
				}
				else
				{
					RunToPlayer();
				}
			}
		}

	}

	void Attack()
	{
		attacking = true;
		animation.Play (attackClip.name);

		CancelInvoke();
		Invoke ("BackToNormal", attackClip.length);
	}

	void RunToPlayer()
	{
		if(!animation.IsPlaying(moveClip.name))
		{
			animation.Play(moveClip.name);
		}
		
		Vector3 playerPosition = mainCharacter.transform.position;
		playerPosition.y = transform.position.y;
		transform.LookAt(playerPosition);

		Vector3 originV = rigidbody.velocity;

		rigidbody.velocity = moveSpeed * transform.forward + new Vector3(0,originV.y,0);

	}
}
