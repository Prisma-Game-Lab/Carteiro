using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance { get; private set; }
    [SerializeField] private Animator transitionAnim;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void GoToScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string name)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        AudioManager.Instance.StopAllSFX();
        SceneManager.LoadScene(name);
        Debug.Log("Start Anim");
        transitionAnim.SetTrigger("Start");
    }
}
