var maxSpeed : float;
var facingRight : boolean = false;
var rb2D : Rigidbody2D;
var animator : Animator;
var skills : Array = new Array();
var gamepad : XboxCtrlrInput.XCI;
var castOrigin : Transform;
var target : Transform;
var sprite : Transform;

function Start() {
	animator = GetComponent.<Animator>();
	rb2D = GetComponent.<Rigidbody2D>();
	skills.push(GetComponent.<SkillFireball>() as SkillFireball);
	skills.push(GetComponent.<SkillFireball>() as SkillFireball);
	castOrigin = transform.Find("CastOrigin");
	target = castOrigin.Find("Target");
	sprite = transform.Find("Character");
	maxSpeed = 5;
}

function Update() {
	MoveManager();
	AimManager();
	ButtonManager();
}

function MoveManager(){
	var x = Input.GetAxis("Horizontal");
	var y = Input.GetAxis("Vertical");
	//animator.SetFloat("speed",Mathf.Abs(x));
	rb2D.velocity.x = x * maxSpeed;
	rb2D.velocity.y = y * maxSpeed;
	if(x > 0 && !facingRight || x < 0 && facingRight)
		faceInverse();
	return;
}

function AimManager(){
	var rx = gamepad.GetAxis(XboxCtrlrInput.XboxAxis.RightStickX);
	var ry = gamepad.GetAxis(XboxCtrlrInput.XboxAxis.RightStickY);
	var v1 = Vector3(rx,ry,0);
	v1.Normalize();
	if(v1 == Vector3.zero){
		target.GetComponent.<Renderer>().enabled = false;
	}else{
		target.GetComponent.<Renderer>().enabled = true;
	}
	target.transform.localPosition = v1 * 1.5;
	return;
}

function ButtonManager(){
	if(gamepad.GetAxisRaw(XboxCtrlrInput.XboxAxis.RightTrigger)){
		skills[0].Cast();
	}
	if(gamepad.GetAxisRaw(XboxCtrlrInput.XboxAxis.LeftTrigger)){
		skills[1].Cast();
	}
	if(gamepad.GetButtonDown(XboxCtrlrInput.XboxButton.A)){
		//
	}
	if(gamepad.GetButtonDown(XboxCtrlrInput.XboxButton.B)){
		//
	}
	if(gamepad.GetButtonDown(XboxCtrlrInput.XboxButton.Y)){
		//
	}
	if(gamepad.GetButtonDown(XboxCtrlrInput.XboxButton.X)){
		//
	}
	return;
}

function faceInverse(){
	var scale : Vector3;
	scale = sprite.transform.localScale;
	scale.x *= -1;
	facingRight = !facingRight;
	sprite.transform.localScale = scale;
	return;
}


function OnCollisionEnter2D(other : Collision2D){
	Debug.Log('teste');
}