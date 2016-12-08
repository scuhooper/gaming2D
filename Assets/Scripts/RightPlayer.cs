using UnityEngine;
using System.Collections;

public class RightPlayer : MonoBehaviour
{

	public float speed = 10.0F;
	//public bool isWalking;
	public GameObject hitBox;
	public float Speed = 1f;
	private float movex = 0f;
	private float movey = 0f;
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
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += Vector3.up * Speed * Time.deltaTime;
			GetComponent<SpriteRenderer>().flipX = true;
			animator.SetBool("isWalking", true);
		}
		else {
			animator.SetBool("isWalking", false);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.down * Speed * Time.deltaTime;
			animator.SetBool("walkUp", true);
		}
		else {
			animator.SetBool("walkUp", false);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * Speed * Time.deltaTime;
			animator.SetBool("walkDown", true);
		}
		else {
			animator.SetBool("walkDown", false);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * Speed * Time.deltaTime;
			animator.SetBool("walkDown", true);
		}
		else {
			animator.SetBool("walkDown", false);
		}

		//Attack
		if (Input.GetKey(KeyCode.RightShift))
		{
			hitBox.SetActive(true);
		}
		else {
			hitBox.SetActive(false);
		}

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
	}


}
