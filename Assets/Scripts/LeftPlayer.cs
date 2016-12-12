using UnityEngine;
using System.Collections;

public class LeftPlayer : MonoBehaviour
{

	public float speed = 10.0F;
	//public bool isWalking;
	public GameObject hitBox;
	public float Speed = 1f;
	//private float movex = 0f;
	//private float movey = 0f;
	private Animator animator;
	public double run = 1.5;

	// variables used for combat and damage. These are accessed in some of the drug scripts.
	// Questions, ask James
	public float armor;
	public int damage;

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
		if (Input.GetKey(KeyCode.W))
		{
			transform.position += Vector3.up * Speed * Time.deltaTime;
			GetComponent<SpriteRenderer>().flipX = true;
			animator.SetBool("isWalking", true);
		}
		else
		{
			animator.SetBool("isWalking", false);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.position += Vector3.down * Speed * Time.deltaTime;
			animator.SetBool("isWalking", true);
		}
		else
		{
			animator.SetBool("isWalking", false);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.position += Vector3.left * Speed * Time.deltaTime;
			animator.SetBool("isWalking", true);
		}
		else
		{
			animator.SetBool("isWalking", false);
		}

		if (Input.GetKey(KeyCode.D))
		{
			transform.position += Vector3.right * Speed * Time.deltaTime;
			animator.SetBool("isWalking", true);
			//GetComponent<Transform>().rotation = ;
		}
		else
		{
			animator.SetBool("isWalking", false);
		}

		if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.LeftShift)))
		{
			transform.position += Vector3.up * Speed * Time.deltaTime * 2;
			animator.SetBool("isWalking", true);
		}
		else
		{
			animator.SetBool("isWalking", false);
		}

		if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftShift)))
		{
			transform.position += Vector3.left * Speed * Time.deltaTime * 2;
			animator.SetBool("isWalking", true);
		}
		else
		{
			animator.SetBool("isWalking", false);
		}

		if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.LeftShift)))
		{
			transform.position += Vector3.down * Speed * Time.deltaTime * 2;
			animator.SetBool("isWalking", true);
		}
		else
		{
			animator.SetBool("isWalking", false);
		}
		if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftShift)))
		{
			transform.position += Vector3.right * Speed * Time.deltaTime * 2;
			animator.SetBool("isWalking", true);
		}
		else
		{
			animator.SetBool("isWalking", false);
		}

		//Attack
		if (Input.GetKeyDown(KeyCode.Q))
		{
			hitBox.SetActive(true);
		}
		else {
			hitBox.SetActive(false);
		}
		/*
				//flips the player left and right
				if (movex <= -0.1f)
				{
					// transform.rotation = Quaternion.Euler(0, 180, 0); **Changed by James. Flipping sprite makes using the transform of player in Teleport.cs easier to manage.**
					GetComponent<SpriteRenderer>().flipX = true;
				}
				if (movex >= 0.1f)
				{
					// transform.rotation = Quaternion.Euler(0, 0, 0); **Changed by James. Flipping sprite makes using the transform of player in Teleport.cs easier to manage.**
					GetComponent<SpriteRenderer>().flipX = false;
				}

		*/
	}
	public void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "ball")
		{
			col.transform.parent = transform;
		}
	}

}
