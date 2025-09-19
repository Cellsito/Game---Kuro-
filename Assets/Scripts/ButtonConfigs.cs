using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonConfigs : MonoBehaviour
{
    // Nome da cena para onde vai mudar
    public string sceneName;
    public GameObject canva;
    public GameObject buttonMenu;

    // Carrega a cena definida
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void MainMOptions()
    {
        canva.SetActive(true);
        EventSystem.current.SetSelectedGameObject(buttonMenu);
    }

    public void MainMBack()
    {
        EventSystem.current.SetSelectedGameObject(buttonMenu);
        canva.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    // Sai do jogo
    public void QuitGame()
    {
        // Isso funciona no jogo compilado
        Application.Quit();

        // Só pra debug dentro do editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
