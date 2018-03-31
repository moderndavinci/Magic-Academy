using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Tools
{
    public class ReadDataBase : MonoBehaviour
    {

        string appDBPath;
        public void CreateDB()
        {
#if UNITY_EDITOR
            appDBPath = Application.streamingAssetsPath + "/MySql.db";
#elif UNITY_ANDROID
            appDBPath = Application.persistentDataPath + "/MySql.db";
#endif
            if(!File.Exists(appDBPath))
            {
                StartCoroutine(CopyDataBase());
            }
        }
        private IEnumerator CopyDataBase()
        {
            WWW www = new WWW(Application.streamingAssetsPath + "/MySql.db");
            yield return www;
            File.WriteAllBytes(appDBPath,www.bytes);
        }
    }
}
