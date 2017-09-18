using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	GameManager gameManager;
	GameObject playerManager;
	GameObject p1;
	Vector2[] spawnPoints;

	// Use this for initialization
	void Start () {
		playerManager = GameObject.Find ("PlayerManager");
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		spawnPoints = new Vector2[2]{new Vector2(-4, 0),new Vector3(4, 0)};
		SpawnPlayers();
		SpawnTargets();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	protected Vector2 getSpawnPoint(int number){
		return spawnPoints[number-1];
	}
	void SpawnPlayer(int number){
		string prefab = gameManager.getPlayer(number).getPrefab();
		p1 = Instantiate(Resources.Load("Prefabs/Characters/"+prefab), getSpawnPoint(number), Quaternion.identity) as GameObject; 
		p1.transform.parent = playerManager.transform;
	}

	void SpawnPlayers(){
		int numPlayers = gameManager.getNumPlayers();
		for(int contPlayer=1; contPlayer<=numPlayers; contPlayer++){
			SpawnPlayer(contPlayer);
		}
	}
	void SpawnTargets(){
		GameObject target;
		target = Instantiate(Resources.Load("Prefabs/Characters/Target"), new Vector2(0,0), Quaternion.identity) as GameObject; 
		target.transform.parent = GameObject.Find ("Obstacles").transform;
	}
}
