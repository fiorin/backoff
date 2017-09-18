using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float currentHealth { get; set; }
	public float maxHealth { get; set; }
	public Slider healthBar;

	void Start () {
		maxHealth = 20f;
		currentHealth = maxHealth;
		healthBar = transform.Find("UI/PlayerHealth").GetComponent<Slider>();
		healthBar.value = CalculateHealth ();
	}

	void Update () {
		
	}
	void DealDamage(float damage){
		currentHealth -= damage;
		healthBar.value = CalculateHealth ();
		if (currentHealth <= 0) {
			Die ();
		}
	}
	protected float CalculateHealth(){
		return currentHealth / maxHealth;
	}

	void Die(){
		currentHealth = 0;
		Debug.Log ("dead");
	}
}
