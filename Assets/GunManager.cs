using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class GunManager : MonoBehaviour {

	public float fireAngle;
	public float pushBackTime;
	public float recoveryTime;
	Sequence sequence;

	//bullet
	public GameObject bulletCandidate;
	public GameObject shootPoint;
	public float bulletSpeed;


	// Use this for initialization
	void Start () {
		HOTween.Init (true,true,true);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)) 
		{
			gunAnimation();

			initBullet();

		}
	}

	void initBullet()
	{
		GameObject bullet = GameObject.Instantiate (bulletCandidate,shootPoint.transform.position,shootPoint.transform.rotation) as GameObject;

		bullet.rigidbody.velocity = bulletSpeed * shootPoint.transform.forward;

	}

	void gunAnimation()
	{
		if(sequence!=null)sequence.Kill();
		//transform.localRotation
		sequence = new Sequence(new SequenceParms());
		sequence.Append(HOTween.To(transform, pushBackTime, new TweenParms().Prop("localRotation", new Vector3(fireAngle, 0, 0),false).Ease(EaseType.EaseInQuart)));
		sequence.Append(HOTween.To(transform, recoveryTime, new TweenParms().Prop("localRotation", new Vector3(0, 0, 0),false).Ease(EaseType.EaseInQuart)));
		
		sequence.Play();
	}
}
