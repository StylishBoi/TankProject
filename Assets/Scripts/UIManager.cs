using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalText;

    void Start()
    {
        totalText.text = "Total - " + 4;
    }

    public void UpdateTotal(int totalLeft)
    {
        //Update the text for total of enemies left
        totalText.text="Total - " + totalLeft.ToString();
    }
}
