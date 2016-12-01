/*********
 *		Author:Cameron Asbury 
 *		Purpose:Controls HP and eventually Death of player.
 ********/
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {

    public int sHealth = 100;
    int cHealth;
    public Slider hSlider;
    public bool bDamage;
    private bool bDead;
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("player");
        bDead = false;
        cHealth = sHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Public function so the player can take damage
    /// </summary>
    /// <param name="attack"></param>
    public void takeDamage(int attack)
    {
        bDamage = true;
        cHealth -= attack;
        hSlider.value = cHealth;

        if(cHealth <= 0 && !bDead)
        {
            PlayerDead();
        }
    }

    void PlayerDead()
    {
        bDead = true;
        Debug.Log("Player is Dead!!");
    }
}
