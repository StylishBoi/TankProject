using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 30f;
    private bool gamestopped = false;

    [SerializeField] TextMeshProUGUI countdownText;
    
    TankControls _tankControls;
    UIManager _uiManager;
    private void Awake()
    {
        //Gets tank compoment to later use for the tank death
        _tankControls = GameObject.FindGameObjectWithTag("Tank").GetComponent<TankControls>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }  
    
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gamestopped == false && currentTime > 0)
        {
            //Keeps updating the timer
            currentTime -=1*Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
        }
        else if (gamestopped == true)
        {
            //Stops the timer when you win
        }
        else if (currentTime <= 0)
        {
            //Stops the timer and kills the player when you run out of time
            currentTime = 0;
            _tankControls.PlayerDeath();
            _uiManager.TimesupScreen();
        }
    }

    public void StopGame()
    {
        //Activates to make the timer stop
        gamestopped = true;
    }
}
