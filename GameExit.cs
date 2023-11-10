using UnityEngine;
using UnityEngine.UI;

public class GameExit : MonoBehaviour
{
    public GameObject screenToClose; // •Â‚¶‚½‚¢‰æ–Ê‚ÌGameObject

    public void CloseButtonClicked()
    {
        if (screenToClose != null)
        {
            screenToClose.SetActive(false);
        }
    }
}

