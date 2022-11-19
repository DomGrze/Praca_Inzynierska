using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour {

	public int health = 100;

	public AIPath aiPath;

	//public GameObject deathEffect;

	public void TakeDamage (int damage)
	{
		health -= damage;

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