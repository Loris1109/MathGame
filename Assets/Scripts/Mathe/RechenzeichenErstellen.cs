using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RechenzeichenErstellen : MonoBehaviour
{
    
    //Variables private
    private int rechenzeichen;
    [SerializeField]
    private bool activated = false;


    //Variables public

    public Text RechenzeichenText;
    


    // Start is called before the first frame update
    void Start()
    {
        rechenzeichen = Random.Range(1, 4);
        Debug.Log("Rechenzeichen" + rechenzeichen.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (activated == false)
        {
            if (rechenzeichen == 1)
            {
                RechenzeichenText.text = "+";
            }
            else if (rechenzeichen == 2)
            {
                RechenzeichenText.text = "-";
            }
            else
            {
                RechenzeichenText.text = "x";
            }

            activated = true;
        }

    }

    public int Rechenzeichen
    {
        get { return rechenzeichen; }
    }
}
