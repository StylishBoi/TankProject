using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartInput : MonoBehaviour
{
    
    public void OnRestartInput()
    {
        //Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
