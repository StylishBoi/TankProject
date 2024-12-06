using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalText;
    [SerializeField] private Image deathScreen;
    [SerializeField] private Image winScreen;
    [SerializeField] private Image timesupScreen;

    void Start()
    {
        totalText.text = "Enemies left - " + 4;
    }

    public void UpdateTotal(int totalLeft)
    {
        //Update the text for total of enemies left
        totalText.text="Enemies left - " + totalLeft.ToString();
    }

    public void DeathScreen()
    {
        deathScreen.transform.position = new Vector3(550f, 250, 0f);
    }
    
    public void WinScreen()
    {
        winScreen.transform.position = new Vector3(550f, 250, 0f);
    }
    
    public void TimesupScreen()
    {
        timesupScreen.transform.position = new Vector3(550f, 250, 0f);
    }
}
