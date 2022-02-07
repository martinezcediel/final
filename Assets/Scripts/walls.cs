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
        //GameObject.FindGameObjectstWithTag("wall");
        //wallList.Add("w");
        foreach(GameObject w in wallArray)
        {
            wallposition.Add(w.transform.position - 0.5f * Vector3.up);
        }
    }



   public bool isValidPosition(Vector3 targetPos)
   { 
       if(wallposition.Contains(targetPos))
       {
            Debug.Log("he entrado");    
            return false;
       }
         return true;

   }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
