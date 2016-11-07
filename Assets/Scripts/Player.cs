using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public float speed = 10.0F;
	//public bool isWalking;
	public GameObject hitBox;
	public float Speed = 1f;
	private float movex = 0f;
	private float movey = 0f;
	private Animator animator;
	public double run = 1.5;

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
		hitBox.SetActive(false);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//Movement
		movex = Input.GetAxis("Horizontal");
		movey = Input.GetAxis("Vertical");
		GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, movey * Speed);

		if (Input.GetKey("left shift"))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed * 2, movey * Speed * 2);
		}
		else {
			GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, movey * Speed);
		}

		if ((movex >= 0.1f) || (movex <= -0.1f) || (movey <= -0.1f))
		{
			animator.SetBool("isWalking", true);
		}
		else {
			animator.SetBool("isWalking", false);
		}
		if (movey <= -0.1f)
		{
			animator.SetBool("walkUp", true);
		}
		else {
			animator.SetBool("walkUp", false);
		}
		if (movey >= 0.1f)
		{
			animator.SetBool("walkDown", true);
		}
		else {
			animator.SetBool("walkDown", false);
		}

		//Attack
		if (Input.GetMouseButtonDown(0))
		{
			hitBox.SetActive(true);
		}
		else {
			hitBox.SetActive(false);
		}

		//flips the player left and right
		if (movex <= -0.1f)
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
		if (movex >= 0.1f)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}


}
