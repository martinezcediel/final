using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	void Start()
	{
		//No se destruye cuando se carga una nueva escena
        
		DontDestroyOnLoad(this.gameObject);
	}

	

}
