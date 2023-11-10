using UnityEngine;
using UnityEngine.UI;

public class GameExit : MonoBehaviour
{
    public GameObject screenToClose; // 閉じたい画面のGameObject

    public void CloseButtonClicked()
    {
        if (screenToClose != null)
        {
            screenToClose.SetActive(false);
        }
    }
}

