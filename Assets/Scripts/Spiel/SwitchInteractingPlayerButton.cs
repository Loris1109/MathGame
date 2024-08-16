using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchInteractingPlayerButton : MonoBehaviour
{


    public Button interactingButton;
    public UfoSlimeControls ufoSlimeControls;
    public SlimeControls slimeControls;


    private void Update()
    {
        if (slimeControls.isActiveAndEnabled == true && ufoSlimeControls.isActiveAndEnabled == false)
        {
            SwitchToStandart();
        }
        else if (slimeControls.isActiveAndEnabled == false && ufoSlimeControls.isActiveAndEnabled == true)
        {
            SwitchToUfo();
        }
    }
    void SwitchToUfo ()
    {
        interactingButton.onClick.RemoveAllListeners();
        interactingButton.onClick.AddListener(Ufo);
    }

    void SwitchToStandart()
    {
        interactingButton.onClick.RemoveAllListeners();
        interactingButton.onClick.AddListener(Standart);
    }

    void Ufo ()
    {
        ufoSlimeControls.InteractingControls();
    }

    void Standart()
    {
        slimeControls.InteractingControls();
    }
}
