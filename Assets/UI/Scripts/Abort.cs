using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Abort : MonoBehaviour
{
    public void Click() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
