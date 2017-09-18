using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {

	protected int numPlayers = 1;
	protected Player[] player = new Player[4];

	void Awake (){
		DontDestroyOnLoad (transform.gameObject);
	}

	void Start () {
		for(int contPlayer = 0; contPlayer<numPlayers; contPlayer++){
			player[contPlayer] = new Player();
		}
	}

	void Update () {
		
	}

	public int getNumPlayers (){
		return numPlayers;
	}

	public Player getPlayer(int number){
		return player[number-1];
	}
}