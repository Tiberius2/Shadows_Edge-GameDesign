using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMonitoring : MonoBehaviour
{
    #region Singleton
    public static PlayerMonitoring instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
