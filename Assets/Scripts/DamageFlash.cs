/*********
 *		Author:Cameron Asbury 
 *		Purpose:Will Flash a different image on the screen when the Player is attacked
 ********/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour {

    public float flashSpeed;
    public Image flashImage;
    public Color flashColor;
    PlayerHP playerHP;

	// Use this for initialization
	void Start () {
        playerHP = playerHP.GetComponent<PlayerHP>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (playerHP.bDamage)
        {
                flashImage.color = flashColor;
                playerHP.bDamage = false;
        }
        else
        {
            flashImage.color = Color.Lerp(flashImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
	}
}
