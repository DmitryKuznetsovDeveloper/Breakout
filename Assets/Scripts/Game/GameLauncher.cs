using UnityEngine.SceneManagement;

namespace Game
{
    public sealed class GameLauncher
    {
        public void LoadSceneByIndex(int index)
        {
            if (index < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(index);
            else
                SceneManager.LoadScene(0);
        }
        
        public void ResetCurrentScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}