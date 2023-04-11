using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public GameObject GuideUI;
    public GameObject GuideCredits;
     void Update()
    {
        
    }
    public void GuideON()
    {
        GuideUI.SetActive(true);
        Debug.Log("Guide On");
    }
    public void GuideOff()
    {
        GuideUI.SetActive(false);
        Debug.Log("Guide Off");
    }
    public void CreditsON()
    {
        GuideCredits.SetActive(true);
        Debug.Log("Credits On");
    }
    public void CreditsOff()
    {
        GuideCredits.SetActive(false);
        Debug.Log("Credits Off");
    }
}
