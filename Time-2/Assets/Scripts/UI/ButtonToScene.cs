using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToScene : MonoBehaviour
{
    public void goToScene(string name)
    {
        MenuPrincipalManager.cenaRetorno = SceneManager.GetActiveScene().name;
        SceneTransition.Instance.GoToScene(name);
    }

    public void backToScene()
    {
        SceneTransition.Instance.GoToScene(MenuPrincipalManager.cenaRetorno);
    }
}
