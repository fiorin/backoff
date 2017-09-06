#pragma strict

var rb2D : Rigidbody2D;
var facingRight : boolean;
var angle : float;
var direction : Vector2;
var origin : Vector2;
var iniciar : boolean;
var projectileSpeed : float;

function Start () {
	rb2D = GetComponent.<Rigidbody2D>();
	direction = transform.position - origin;
	direction.Normalize();
	projectileSpeed = 8;
	rb2D.velocity = direction * projectileSpeed;
	var moveDirection = rb2D.velocity;
    if (moveDirection != Vector2.zero){
        var angle = Mathf.Atan2(-moveDirection.y, -moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

function Update () {
	
}

function OnCollisionEnter2D(other : Collision2D){
	//print("Points colliding: " + other.contacts.Length);
    print("First point that collided: " + other.contacts[0].point);
    Debug.Log(other.contacts.Length);
    Destroy(this.gameObject);
}