using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private const int Game = 1;
    public GameObject Overlay;
    public GameObject RunCommand;
    [SerializeField] private float waitTime = 3;

    public void Load(int buildIndex) => StartCoroutine(LoadLevel(buildIndex));

    public IEnumerator LoadLevel(int buildIndex)
    {
        Overlay.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(buildIndex);
    }

    public void PlayGame()
    {
        RunCommand.SetActive(true);
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(waitTime); 
        Load(Game);
    }
    public void QuitGame() => Application.Quit();
}
