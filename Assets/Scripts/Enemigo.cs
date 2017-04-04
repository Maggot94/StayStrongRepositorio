using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

	public int vida = 100; 
	private Animator Ataques; 

	public float TimeAttack = 8f; 
	public float stay = 10f; 

	private BoxCollider2D attack; 
	public bool rigth = false;
	public bool left = false; 
	public bool NextAttackBool = false; 

	public int StateAttack;

	//----- parte roger---

	// Use this for initialization
	void Start () {

		Ataques = GetComponent<Animator> (); 
		attack = GetComponent<BoxCollider2D> (); 
	
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (NextAttackBool == false) {

		
			stay -= Time.deltaTime;
		}
		if (stay <= 8f) {
			
			Ataques.SetInteger ("Attack", 0); 
			TimeAttack -= Time.deltaTime; 
			//attack.enabled = false; 
			left = false;
			rigth = false;
		}

		if (TimeAttack <= 0) {
			
			stay = 10f; 
			NextAttackBool = true; 
		}
			
		if( NextAttackBool == true)
		{
			StateAttack = Random.Range (0, 3);
			Attack (StateAttack); 
		}
		
	}

	public void Attack (int a) {
		
		if (a == 1) 
		{

			Ataques.SetInteger ("Attack", a); 
			//attack.enabled = true;
			left = true; 
			NextAttackBool = false; 
			TimeAttack = 8f;

		}

		if (a == 2) 
		{
			Ataques.SetInteger ("Attack", a); 
			//attack.enabled = true; 
			rigth = true; 
			NextAttackBool = false; 
			TimeAttack = 8f;
		}


	}

	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0))
		{
			vida = vida - 10;
			//Debug.Log("vida - 1");
		}
		if (vida == 0)
		{
            NotificationCenter.DefaultCenter().PostNotification(this, "AnotherEnemy");
            NotificationCenter.DefaultCenter().PostNotification(this, "SetCountText");
			Destroy(gameObject);
		}
	}

}



