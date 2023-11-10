using UnityEngine;
using UnityEngine.UI;

public class GameExit : MonoBehaviour
{
    public GameObject screenToClose; // ��������ʂ�GameObject

    public void CloseButtonClicked()
    {
        if (screenToClose != null)
        {
            screenToClose.SetActive(false);
        }
    }
}

