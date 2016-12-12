/*********
 *		Author:Cameron Asbury 
 *		Purpose:Attack Script enemies to attack the player
 ********/
using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    GameObject player1;
    GameObject player2;
    public int attack;
    PlayerHP player1HP;
    PlayerHP player2HP;

	// Use this for initialization
	void Start () {
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        player1HP = player1.GetComponent<PlayerHP>();
        player2HP = player2.GetComponent<PlayerHP>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player")
        {
            player1HP.takeDamage(attack);
            player2HP.takeDamage(attack);
        }
    }
}
