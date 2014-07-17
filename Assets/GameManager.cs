using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


	public GameObject monsterCandidate;
	public List<GameObject> respawnPoints;

	public int monsterCount;
	public int level;

	public GameObject mainCharacter;
	public float levelDelay;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (monsterCount == 0) 
		{
			level ++;
			monsterCount = level;
			Invoke("respawnMonsters",levelDelay);
		}
	}

	void respawnMonsters()
	{

		for (int i=0; i<monsterCount; i++) 
		{
			int respawnIndex = Random.Range(0,respawnPoints.Count);
			GameObject respawnPoint = respawnPoints[respawnIndex];
			GameObject monster = GameObject.Instantiate(monsterCandidate,respawnPoint.transform.position,respawnPoint.transform.rotation) as GameObject;
			MonsterScript monsterScript = monster.GetComponent<MonsterScript>();
			monsterScript.manager = this;
			monsterScript.mainCharacter = mainCharacter;

			monster.transform.Translate(new Vector3((Random.Range(-255,255))/255f,0,(Random.Range(-255,255))/255));

		}
	}
}
