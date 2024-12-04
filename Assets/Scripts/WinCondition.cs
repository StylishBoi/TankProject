using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private int _total=4;
    private AudioManager _audioManager;
    private UIManager _uiManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    } 
    
    public void Total_Updated()
    {
        //Checks how many enemies are left (If none, then win)
        _total -= 1;
        _uiManager.UpdateTotal(_total);
        if (_total <= 0)
        {
            _audioManager.StopBGM();
            _audioManager.PlaySfx(_audioManager.win);
            Application.Quit();
        }
    }
}
