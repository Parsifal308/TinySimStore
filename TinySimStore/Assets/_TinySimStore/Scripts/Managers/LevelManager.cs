using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TinySimStore.Manager
{
    public class LevelManager : Singleton<LevelManager>
    {
        #region FIELDS
        #endregion

        #region PROPERTIES
        #endregion

        #region UNITY METHODS
        #endregion

        #region PRIVATE METHODS
        #endregion

        #region PUBLIC METHODS

        public void ChangeScene(string _sceneName)
        {
            StartCoroutine(WaitSeconds(3f));
            SceneManager.LoadSceneAsync(_sceneName);
        }
        public void ExitGame()
        {
            StartCoroutine(WaitSeconds(3f));
            Application.Quit();
        }
        #endregion

        #region COROUTINES
        IEnumerator WaitSeconds(float time)
        {
            yield return new WaitForSeconds(time);
        }
        #endregion
    }
}