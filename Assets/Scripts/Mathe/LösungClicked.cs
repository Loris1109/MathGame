using UnityEngine;
using UnityEngine.UI;

public class LösungClicked : MonoBehaviour
{
    //Variables Private
    [SerializeField]
    private float invokeTime = 1f;
    
    private bool activated = false;
    [SerializeField]
    private int aufgabenSoll = 5;
    private static int aufgabenKorreckt;

    //Variables Public

    public AufgabeErstellen aufgabeErstellen;
    public Button antwort1;
    public Button antwort2;
    public Button antwort3;

    //Methode
    public void LateUpdate()
    {
        if (activated == false)
        {
            Debug.Log("LösungsLos" + aufgabeErstellen.LösungsLos);
            SetLevelChange();
            activated = true;
        }
    }
    public void ChangeColorClicked()
    {
        if (aufgabeErstellen.LösungsLos == 1)
        {

            ColorBlock colors1 = antwort1.colors;
            colors1.selectedColor = Color.green;
            antwort1.colors = colors1;

            ColorBlock colors2 = antwort2.colors;
            colors2.selectedColor = Color.red;
            antwort2.colors = colors2;

            ColorBlock colors3 = antwort3.colors;
            colors3.selectedColor = Color.red;
            antwort3.colors = colors3;


        }
        if (aufgabeErstellen.LösungsLos == 2)
        {

            ColorBlock colors2 = antwort2.colors;
            colors2.selectedColor = Color.green;
            antwort2.colors = colors2;

            ColorBlock colors3 = antwort3.colors;
            colors3.selectedColor = Color.red;
            antwort3.colors = colors3;

            ColorBlock colors1 = antwort1.colors;
            colors1.selectedColor = Color.red;
            antwort1.colors = colors1;

            
        }
        if (aufgabeErstellen.LösungsLos == 3)
        {

            ColorBlock colors3 = antwort3.colors;
            colors3.selectedColor = Color.green;
            antwort3.colors = colors3;

            ColorBlock colors2 = antwort2.colors;
            colors2.selectedColor = Color.red;
            antwort2.colors = colors2;

            ColorBlock colors1 = antwort1.colors;
            colors1.selectedColor = Color.red;
            antwort1.colors = colors1;

            
        }
    }

    void SetLevelChange()
    {
        if (aufgabeErstellen.LösungsLos == 1)
        {

            antwort1.onClick.AddListener(() =>  ChangeLevelSpiel());
            antwort2.onClick.AddListener(() => ChangeLevelMathe());
            antwort3.onClick.AddListener(() => ChangeLevelMathe());
            
        }
        else if (aufgabeErstellen.LösungsLos == 2)
        {
            
            antwort1.onClick.AddListener(() => ChangeLevelMathe());
            antwort2.onClick.AddListener(() => ChangeLevelSpiel());
            antwort3.onClick.AddListener(() => ChangeLevelMathe());

        }
        else
        {
            antwort1.onClick.AddListener(() => ChangeLevelMathe());
            antwort2.onClick.AddListener(() => ChangeLevelMathe());
            antwort3.onClick.AddListener(() => ChangeLevelSpiel());

        }
    }

    public void ChangeLevelSpiel ()
    {

        aufgabenKorreckt++;
        if (aufgabenKorreckt == aufgabenSoll)
        {
            FindObjectOfType<GameManager>().Invoke("LoadeSpiel", invokeTime);
        }
        else
        {
            FindObjectOfType<GameManager>().Invoke("LoadeMatheLvl", invokeTime);
        }
    }

    public void ChangeLevelMathe ()
    {
        FindObjectOfType<GameManager>().Invoke("LoadeMatheLvl", invokeTime);
    }
}
