using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walls : MonoBehaviour
{
   
    public List<Vector3> wallposition = new List<Vector3>(); 

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] wallArray = GameObject.FindGameObjectsWithTag("wall");

        // Bajar la altura de wall para que coincida con la Target Position
        foreach(GameObject w in wallArray)
        {
            wallposition.Add(w.transform.position - 0.5f * Vector3.up);
        }
    }


   public bool isValidPosition(Vector3 targetPos)
   { 
       if(wallposition.Contains(targetPos))
       {  
            return false;
       }
        return true;

   }
}
