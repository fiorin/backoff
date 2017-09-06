var rb2D : Rigidbody2D;
var cooldown : float;
var timeReady : float;
var prefab : GameObject;
var castOrigin : Transform;
var castTarget : Transform;
var sprite : Transform;

function Start () {
	rb2D = gameObject.GetComponent.<Rigidbody2D>();
	castOrigin = transform.Find("CastOrigin");
	sprite = transform.Find("Character");
	cooldown = 2;
	timeReady = Time.time;
}

function Update () {
	//Debug.Log(timeReady);
}

function Ready(){
	if(Time.time >= timeReady){
		timeReady = Time.time + cooldown;
		return true;
	}
	return false;
}

function Cast(){
	if(Ready()){
		castTarget = castOrigin.Find("Target");
		var pos : Vector3;
		if(castTarget.transform.localPosition != Vector3.zero){
			Spawn();
		}
	}
}

function Spawn(){
	pos = castTarget.transform.position;
	var instance = Instantiate(prefab,pos,Quaternion.identity);
	var fireball : SkillFireballBehaviour;
	fireball = instance.GetComponent.<SkillFireballBehaviour>();
	fireball.origin = castOrigin.transform.position;
}


/* -------------------------
// projeto de direcao baseada em movimento para sem mira
if(castTarget.transform.localPosition == Vector3.zero){
	var x = transform.position.x + sprite.transform.localScale.x;
	var y = castOrigin.transform.position.y ;
	pos = Vector3(x,y,0);
}else{
	pos = castTarget.transform.position;
}
/ ------------------------- */