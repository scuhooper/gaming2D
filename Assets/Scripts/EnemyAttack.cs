/*********
 *		Author:Cameron Asbury 
 *		Purpose:Attack Script enemies to attack the player
 ********/
using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    GameObject player;
    public int attack;
    PlayerHP playerHP;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
        playerHP = player.GetComponent<PlayerHP>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player")
        {
            playerHP.takeDamage(attack);
        }
    }
}
