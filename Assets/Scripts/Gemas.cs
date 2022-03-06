using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gemas : MonoBehaviour
{
    public Text GemCountTxt;
    public int GemCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Gem")
        {
            GemCount++;
            GemCountTxt.text = "" + GemCount;
            other.gameObject.SetActive(false);
        }
    }
}
