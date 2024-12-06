using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private int _total=4;
    private AudioManager _audioManager;
    private UIManager _uiManager;
    private Timer _timer;

    private void Awake()
    {
        //Gets access to the audio, UI and timer scripts
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        _timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    } 
    
    public void Total_Updated()
    {
        //Checks how many enemies are left (If none, then win)
        _total -= 1;
        _uiManager.UpdateTotal(_total);
        if (_total <= 0)
        {
            _timer.StopGame();
            _audioManager.StopBGM();
            _uiManager.WinScreen();
            _audioManager.PlaySfx(_audioManager.win);
            Application.Quit();
        }
    }
}
