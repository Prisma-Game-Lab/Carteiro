using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToScene : MonoBehaviour
{
    public void goToScene(string name)
    {
        SceneTransition.Instance.GoToScene(name);
    }
}
