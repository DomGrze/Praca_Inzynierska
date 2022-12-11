using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 10f;
    private int maxHealth = 100;
    private int health;
    private bool doubleJump=false;
    public Animator animator;
    public HealthBar healthBar;
    public GameObject deathMenu;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Time.timeScale = 1f;
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if(IsGrounded())
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump") && (IsGrounded() || (doubleJump==false)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            doubleJump = !doubleJump;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (transform.position.y < -10f)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    public void TakeDamage (int damage)
	{
		health -= damage;
        healthBar.SetHealth(health);

		if (health <= 0)
		{
			Die();
		}
	}
    void Die ()
	{
        Time.timeScale = 0f;
        deathMenu.SetActive(true);
	}
    public void HealDamage (int heal)
	{
		health += heal;
        if(health>maxHealth)
        {
            health=maxHealth;
        }
        healthBar.SetHealth(health);
	}
}