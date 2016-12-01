/*********
 *		Author:Cameron Asbury 
 *		Purpose:Will Flash a different image on the screen when the Player is attacked
 ********/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour {
    GameObject player;
    public float flashSpeed = 5f;
    public Image flashImage;
    public Color flashColor = new Color(1f, 1f, 1f, 0.1f);
    PlayerHP playerHP;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
        playerHP = player.GetComponent<PlayerHP>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (playerHP.bDamage)
        {
            Debug.Log("INSIDE IF STATEMENT");
                flashImage.color = flashColor;
                playerHP.bDamage = false;
        }
        else
        {
            flashImage.color = Color.Lerp(flashImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
	}
}
