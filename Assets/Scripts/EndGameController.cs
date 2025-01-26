using UnityEngine;
using TMPro;

public class EndSceneController : MonoBehaviour
{
    public TMP_Text timerResultText; // Referenca na UI Text gde će se prikazati vreme

    void Start()
    {
        // Prikaži poslednju vrednost tajmera
        float finalTime = ArmController.LastElapsedTime;

        int minutes = Mathf.FloorToInt(finalTime / 60);
        int seconds = Mathf.FloorToInt(finalTime % 60);

        if (timerResultText != null)
        {
            timerResultText.text = string.Format("Ukupno vreme: {0:D2}:{1:D2}", minutes, seconds);
        }

        Debug.Log("Vreme iz prve scene: " + finalTime + " sekundi");
    }
}
