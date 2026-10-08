using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamescenemanager : MonoBehaviour
{
    public void reloadlevel()
    {
        StartCoroutine(reloadlevelRoutine());
    }

    IEnumerator reloadlevelRoutine()
    {
        yield return new WaitForSeconds(1f);
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneindex);
    }
}
