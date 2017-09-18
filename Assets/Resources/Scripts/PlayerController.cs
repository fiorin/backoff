using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	float maxSpeed;
	bool facingRight = false;
	Rigidbody2D rb2D;
	Animator animator;
	Skill[] skills = new Skill[4];
	//XboxCtrlrInput.XCI gamepad;
	Transform castOrigin;
	Transform target;
	Transform sprite;

	void Start () {
		animator = transform.GetComponent<Animator>();
		rb2D = transform.GetComponent<Rigidbody2D>();
		skills[0] = transform.GetComponent<SkillFireball>() as SkillFireball;
		skills[1] = transform.GetComponent<SkillFireball>() as SkillFireball;
		castOrigin = transform.Find("CastOrigin");
		target = castOrigin.Find("Target");
		sprite = transform.Find("Character");
		maxSpeed = 5;
	}
	
	// Update is called once per frame
	void Update () {
		MoveManager();
		AimManager();
		ButtonManager();
	}

	void MoveManager(){
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		//animator.SetFloat("speed",Mathf.Abs(x));
		rb2D.velocity = new Vector2 (x * maxSpeed,y * maxSpeed);
		if(x > 0 && !facingRight || x < 0 && facingRight)
			faceInverse();
	}

	void faceInverse(){
		Vector3 scale;
		scale = sprite.transform.localScale;
		scale.x *= -1;
		facingRight = !facingRight;
		sprite.transform.localScale = scale;
	}

	void AimManager(){
		float x = XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.RightStickX);
		float y = XboxCtrlrInput.XCI.GetAxis(XboxCtrlrInput.XboxAxis.RightStickY);
		Vector3 direction = new Vector3(x,y,0);
		direction.Normalize();
		if(direction == Vector3.zero){
			target.transform.GetComponent<Renderer>().enabled = false;
		}else{
			target.transform.GetComponent<Renderer>().enabled = true;
		}
		target.transform.localPosition = new Vector3(direction.x,direction.y,0);
	}

	void ButtonManager(){
		if(XboxCtrlrInput.XCI.GetAxisRaw(XboxCtrlrInput.XboxAxis.RightTrigger) > 0){
			//Debug.Log("pew");
			skills[0].Cast();
		}
		if(XboxCtrlrInput.XCI.GetAxisRaw(XboxCtrlrInput.XboxAxis.LeftTrigger) > 0){
			skills[1].Cast();
		}
		if(XboxCtrlrInput.XCI.GetButtonDown(XboxCtrlrInput.XboxButton.A)){
			//
		}
		if(XboxCtrlrInput.XCI.GetButtonDown(XboxCtrlrInput.XboxButton.B)){
			//
		}
		if(XboxCtrlrInput.XCI.GetButtonDown(XboxCtrlrInput.XboxButton.Y)){
			//
		}
		if(XboxCtrlrInput.XCI.GetButtonDown(XboxCtrlrInput.XboxButton.X)){
			//
		}
	}
	void OnCollisionEnter2D(Collision2D other){
		Debug.Log("teste");
	}
}
