using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemChecker : MonoBehaviour
{
	//Se llama a OnLevelWasLoaded cuando la nueva escena se carga
	void OnLevelWasLoaded ()
	{
		//Si no hay EventSystem
		if(!FindObjectOfType<EventSystem>())
		{
			//Se instancia el event
			GameObject obj = new GameObject("EventSystem");

			//Se añaden los componentes
			obj.AddComponent<EventSystem>();
			obj.AddComponent<StandaloneInputModule>().forceModuleActive = true;
			//No se si funciona
			obj.AddComponent<TouchInputModule>();
		}
	}
}
