/*********
 *		Author:Cameron Asbury 
 *		Purpose:Pauses the game, as well shows a menu of options.
 ********/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

	List<Player> playerList = new List<Player>();	// list to hold all players in game
    public Canvas pauseCanvas;
	public GameObject cardboardSign;
	public GameObject pauseMenuButtons;
	public GameObject controlsMenu;
	public GameObject playerMenu;
	public GameObject customControlMenu;
	public Text[] customControlsText;
    bool isPaused;
	
	Player p;
	ControlsCustomizer contCustom;
	Dictionary<string, KeyCode> playersControlMappings;

	// Use this for initialization
	void Start () {
		foreach ( Player p in FindObjectsOfType<Player>() )	// initialize list
		{
			playerList.Add( p );
		}
        pauseCanvas.enabled = false;
        isPaused = false;
		contCustom = GetComponent<ControlsCustomizer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            pauseCanvas.enabled = true;

			// cycle through list and disable player and teleport components
			foreach ( Player p in playerList )
			{
				p.enabled = false;
				p.GetComponent<Teleport>().enabled = false;
			}
            Time.timeScale = 0;
        }
        else
        {
            pauseCanvas.enabled = false;

			// cycle through list and enable player and teleport components
			foreach ( Player p in playerList )
			{
				p.enabled = true;
				p.GetComponent<Teleport>().enabled = true;
			}
            Time.timeScale = 1;
        }
    }

	public void OnControlsButtonClick()
	{
		StartCoroutine( TurnCardboard() );
	}

	public void OnOptionsButtonClick()
	{

	}

	public void OnQuitButtonClick()
	{
		Application.Quit();
	}

	public void OnPlayerButtonClick()
	{
		string playerName = EventSystem.current.currentSelectedGameObject.gameObject.GetComponentInChildren<Text>().text.ToLower();
		string[] tempArr = playerName.Split( ' ' );
		playerName = tempArr[ 0 ] + tempArr[ 1 ];
		Debug.Log( playerName );
		p = GameObject.Find( playerName ).GetComponent<Player>();
		playerMenu.SetActive( false );
		ShowControlButtonMappings( p );
		customControlMenu.SetActive( true );
	}

	public void OnCustomControlButtonClick()
	{
		GameObject currentButton = EventSystem.current.currentSelectedGameObject;
		StartCoroutine( contCustom.WaitForInput( p, currentButton ) );
	}

	public void OnBackButtonClick()
	{
		if ( playerMenu.activeInHierarchy )
			StartCoroutine( TurnCardboard() );
		else
		{
			p.SaveControlsToFile();
			customControlMenu.SetActive( false );
			playerMenu.SetActive( true );
		}
	}

	void ShowControlButtonMappings( Player player )
	{
		int count = 0;
		foreach ( KeyValuePair<string, KeyCode> pair in player.GetControlMappings() )
		{
			customControlsText[ count ].text = pair.Value.ToString();
			count++;
		}
	}
	IEnumerator TurnCardboard()
	{
		if ( cardboardSign.transform.rotation.eulerAngles == Vector3.zero )
		{
			float angle = 0f;
			while ( angle != 180 )
			{
				angle += 5;
				if ( angle == 90 )
				{
					pauseMenuButtons.SetActive( false );
					controlsMenu.SetActive( true );
					playerMenu.SetActive( true );
				}
				cardboardSign.transform.rotation = Quaternion.Euler( 0, angle, 0 );
				yield return null;
			}
		}
		else
		{
			float angle = 180;
			while ( angle != 0 )
			{
				angle -= 5;
				if ( angle == 90 )
				{
					pauseMenuButtons.SetActive( true );
					controlsMenu.SetActive( false );
					playerMenu.SetActive( false );
				}
				cardboardSign.transform.rotation = Quaternion.Euler( 0, angle, 0 );
				yield return null;
			}
		}
	}
}
