using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 1/11更新

public class changescenes : MonoBehaviour
{
    public static string NowSceneName;
    public static string ReturnSceneName;

    public void change_button()
    {
        SceneManager.LoadScene("optionScene");
    }

    //花札
    public void change_game()
    {
        SceneManager.LoadScene("Game");
    }

    //オプションへの遷移
    public void change_option()
    {
        NowSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("optionScene");

    }
    //オプションからの遷移
    public void change_return()
    {
        //アクティブシーンの名前を取り出す
        ReturnSceneName = getSceneName();
        //アクティブシーンの呼出
        SceneManager.LoadScene(ReturnSceneName);
    }


    //アクティブシーンの名前保存
    public static string getSceneName()
    {
        return NowSceneName;
    }


}
