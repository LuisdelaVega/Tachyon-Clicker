using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private const int Game = 1;
    public GameObject Overlay;

    public void Load(int buildIndex) => StartCoroutine(LoadLevel(buildIndex));

    public IEnumerator LoadLevel(int buildIndex)
    {
        Overlay.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(buildIndex);
    }

    public void PlayGame() => Load(Game);
    public void QuitGame() => Application.Quit();
}
