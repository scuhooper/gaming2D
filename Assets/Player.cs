using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public float speed = 10.0F;
	public bool isWalking;
	public GameObject hitBox;
	public GameObject lefthitBox;
	public int Speed = 0;
	private float movex = 0f;
	private float movey = 0f;
	private Animator animator;

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
		hitBox.SetActive(false);
		lefthitBox.SetActive(false);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		movex = Input.GetAxis("Horizontal");
		movey = Input.GetAxis("Vertical");
		GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, movey * Speed);


		if ((movex >= 0.1f) || (movey >= 0.1f) || (movex <= -0.1f) || (movey <= -0.1f))
		{
			animator.SetBool("isWalking", true);
		}
		else
			animator.SetBool("isWalking", false);

		if (Input.GetMouseButtonDown(0))
		{
			hitBox.SetActive(true);
			Debug.Log("PIE");
		}
		else {
			hitBox.SetActive(false);
		}
		if (movex <= -0.1f)
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
		else {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}
}