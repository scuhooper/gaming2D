using UnityEngine;
using System.Collections;

public class animator : MonoBehaviour
{
	public Animator Player;
	// Use this for initialization
	void Start()
	{
		Player = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		bool walkDown = Input.GetKey("s");
		bool walkUp = Input.GetKey("w");
		bool walkDownRight = Input.GetKey("s") && Input.GetKey("d");

		Player.SetBool("isWalkingUp", walkUp);
		Player.SetBool("isWalkingDown", walkDown);
		Player.SetBool("isWalkingDownRight", walkDownRight);
	}
}
