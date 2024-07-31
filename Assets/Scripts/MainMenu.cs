using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void StartGame()
    {
       
        SceneManager.LoadScene("SongOne");
    }

    
    public void OpenSettings()
    {
        
        SceneManager.LoadScene("Settings");
    }

    
    public void QuitGame()
    {
        
        Application.Quit();

        // If we are running in the Unity editor, stop playing the scene
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
