using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	protected int life = 100;
	protected string prefab = "Player";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public int getLife(){
		return life;
	}
	public string getPrefab(){
		return prefab;
	}
}
