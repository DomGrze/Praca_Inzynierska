using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_Tank : MonoBehaviour {

	private int health = 200;

	public AIPath aiPath;
	//public HealthBar healthBar;

	//public GameObject deathEffect;
	void Start()
	{
		//healthBar.SetMaxHealth(health);
		//healthBar.SetHealth(health);
	}

	public void TakeDamage (int damage)
	{
		health -= damage;
		//healthBar.SetHealth(health);

		if (health <= 0)
		{
			Die();
		}
	}

	void Update()
	{
		if(aiPath.desiredVelocity.x >= 0.01f)
		{
			transform.localScale = new Vector3(-1f, 1f, 1f);

		}else if (aiPath.desiredVelocity.x <= -0.01f)
		{
			transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}

	void Die ()
	{
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}