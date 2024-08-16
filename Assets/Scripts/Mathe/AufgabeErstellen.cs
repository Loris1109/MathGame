using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AufgabeErstellen : MonoBehaviour
{

    #region Variables Private
    [SerializeField]
    private bool activated = false;
    [SerializeField]
    private bool lösungActivated = false;
    private int lösungsmöglichkeit1;
    private int lösungsmöglichkeit2;
    private int lösungsLos;
    private int Zahl1Int;
    private int Zahl2Int;
    private int Lösung;
    #endregion
    #region Variables Public

    public Text Zahl1Text;
    public Text Zahl2Text;
    public Text LösungText1;
    public Text LösungText2;
    public Text LösungText3;
    public RechenzeichenErstellen RzErstellen;
    #endregion

    #region methods
    // Update is called once per frame
    void Update()
    {
        Aufgabe();
        LösungenVerteilen();
    }

    public void Aufgabe ()
    {
        if (activated == false)
        {
            Debug.Log("übergebenes Rechenzeichen" + RzErstellen.Rechenzeichen.ToString());
            activated = true;
            if (RzErstellen.Rechenzeichen == 1)
            {
                Zahl1Int = Random.Range(0, 101);
                Zahl2Int = Random.Range(0, 101);
                Zahl1Text.text = Zahl1Int.ToString();
                Zahl2Text.text = Zahl2Int.ToString();

                Lösung = Zahl1Int + Zahl2Int;


                Debug.Log("Zahl1" + Zahl1Int.ToString());
                Debug.Log("Zahl2" + Zahl2Int.ToString());
                Debug.Log("Lösung" + Lösung.ToString());


            }
            else if (RzErstellen.Rechenzeichen == 2)
            {
                Zahl1Int = Random.Range(0, 101);
                do
                {
                    Zahl2Int = Random.Range(0, 101);
                } while (Zahl2Int > Zahl1Int);

                Zahl1Text.text = Zahl1Int.ToString();
                Zahl2Text.text = Zahl2Int.ToString();

                Lösung = Zahl1Int - Zahl2Int;


                Debug.Log("Zahl1" + Zahl1Int.ToString());
                Debug.Log("Zahl2" + Zahl2Int.ToString());
                Debug.Log("Lösung" + Lösung.ToString());
            }
            else
            {
                Zahl1Int = Random.Range(0, 11);
                Zahl2Int = Random.Range(0, 11);
                Zahl1Text.text = Zahl1Int.ToString();
                Zahl2Text.text = Zahl2Int.ToString();

                Lösung = Zahl1Int * Zahl2Int;


                Debug.Log("Zahl1" + Zahl1Int.ToString());
                Debug.Log("Zahl2" + Zahl2Int.ToString());
                Debug.Log("Lösung" + Lösung.ToString());
            }
        }
    }

    public void LösungenVerteilen ()
    {
        if (lösungActivated == false)
        {
            lösungsmöglichkeit1 = Random.Range(-10, 10) + Lösung;
            lösungsmöglichkeit2 = lösungsmöglichkeit1 + Random.Range(-10, 10) + Lösung;

            lösungsLos = Random.Range(1, 4);
            lösungActivated = true;

            if (lösungsLos == 1)
            {
                LösungText1.text = Lösung.ToString();
                LösungText2.text = lösungsmöglichkeit1.ToString();
                LösungText3.text = lösungsmöglichkeit2.ToString();
            }
            else if (lösungsLos == 2)
            {
                LösungText2.text = Lösung.ToString();
                LösungText1.text = lösungsmöglichkeit1.ToString();
                LösungText3.text = lösungsmöglichkeit2.ToString();
            }
            else
            {
                LösungText3.text = Lösung.ToString();
                LösungText2.text = lösungsmöglichkeit1.ToString();
                LösungText1.text = lösungsmöglichkeit2.ToString();
            }
        }
        
    }

    public int LösungsLos
    {
        get { return lösungsLos; }
    }

    #endregion
}
