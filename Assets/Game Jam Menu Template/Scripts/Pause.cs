using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {


	private ShowPanels showPanels;						
	private bool isPaused;								//Si el juego esta o no
	private StartOptions startScript;					//StartB script
	
	//Awake antes q el Start
	void Awake()
	{
		
		showPanels = GetComponent<ShowPanels> ();
		
		startScript = GetComponent<StartOptions> ();
	}

	// Update is called once per frame
	void Update () {

		//Boton Escape para cancelar
		if (Input.GetButtonDown ("Cancel") && !isPaused && !startScript.inMainMenu) 
		{
			//Call the DoPause function to pause the game
			DoPause();
		} 
		//Si se pulsa Escape enmedio de la escena
		else if (Input.GetButtonDown ("Cancel") && isPaused && !startScript.inMainMenu) 
		{
			//Se llama al Pause
			UnPause ();
		}
	
	}


	public void DoPause()
	{
		isPaused = true;
		//Se para todo
		Time.timeScale = 0;
		//Se llama a show Panel
		showPanels.ShowPausePanel ();
	}


	public void UnPause()
	{
		//Pause falso
		isPaused = false;
		//Continua todo
		Time.timeScale = 1;
		//Se oculta el menu
		showPanels.HidePausePanel ();
	}


}
