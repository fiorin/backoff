using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFireball : Skill {

	Rigidbody2D rb2D;
	float cooldown;
	float timeReady;
	GameObject prefab;
	Transform castOrigin;
	Transform castTarget;
	Transform sprite;

	// Use this for initialization
	void Start () {
		rb2D = gameObject.GetComponent<Rigidbody2D>();
		castOrigin = transform.Find("CastOrigin");
		sprite = transform.Find("Character");
		cooldown = 2;
		timeReady = Time.time;
		prefab = Resources.Load("Prefabs/Fireball") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool Ready(){
		if(Time.time >= timeReady){
			timeReady = Time.time + cooldown;
			return true;
		}
		return false;
	}

	override public void Cast(){
		Debug.Log("pew");
		if (Ready ()) {
			castTarget = castOrigin.Find ("Target");
			Vector3 pos;
			if (castTarget.transform.localPosition != Vector3.zero) {
				Spawn ();
			}
		}
	}
	void Spawn(){
		Vector3 position = castTarget.transform.position;
		GameObject instance = Instantiate(prefab,position,Quaternion.identity) as GameObject;
		SkillFireballBehaviour fireball;
		fireball = instance.transform.GetComponent<SkillFireballBehaviour>();
		fireball.setOrigin(castOrigin.transform.position);
	}
}

//
// projeto de direcao baseada em movimento para sem mira
//if(castTarget.transform.localPosition == Vector3.zero){
//	var x = transform.position.x + sprite.transform.localScale.x;
//	var y = castOrigin.transform.position.y ;
//	pos = Vector3(x,y,0);
//}else{
//	pos = castTarget.transform.position;
//}
// 