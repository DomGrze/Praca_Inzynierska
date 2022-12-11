using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_Tank : MonoBehaviour {

	public int health = 200;
	private AIPath aiPath;
	private GameObject enemies;
	private AudioSource hurt;
	private float timer=0f;
	void Start()
	{
		enemies = GameObject.FindGameObjectWithTag("Enemies");
		aiPath = enemies.GetComponent<AIPath>();
		hurt = GetComponent<AudioSource>();
	}
	void Update()
	{
		timer += Time.deltaTime;
	}
	public void TakeDamage (int damage)
	{
		health -= damage;
		if (timer > 1)
		{
			timer = 0f;
			hurt.Play();
		}
		if (health <= 0)
		{
			Die();
		}
	}
	void FixedUpdate()
	{
		if(aiPath.desiredVelocity.x >= 0.01f)
		{
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}else if (aiPath.desiredVelocity.x <= -0.01f)
		{
			transform.localScale = new Vector3(1f, 1f, 1f);
		}
		if (transform.position.y < -10)
		{
			Die();
		}
	}
	void Die ()
	{
		Destroy(gameObject);
	}

}