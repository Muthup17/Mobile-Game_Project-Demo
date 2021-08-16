using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyExploration.Saving
{
    /// <summary>
    /// This component provides the interface to the saving system. It provides
    /// methods to save and restore a scene.
    ///
    /// This component should be created once and shared between all subsequent scenes.
    /// </summary>
    /// 
    public class SavingSystem : MonoBehaviour
    {
        /// <summary>
        /// Will load the last scene that was saved and restore the state. This
        /// must be run as a coroutine.
        /// </summary>
        /// <param name="saveFile">The save file to consult for loading.</param>
        ///
        public IEnumerator LoadLastScene(string saveFile)
        {
            Dictionary<string, object> state = LoadFile(saveFile);
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            if (state.ContainsKey("lastSceneBuildIndex"))
            {
                buildIndex = (int)state["lastSceneBuildIndex"];
            }
            yield return SceneManager.LoadSceneAsync(buildIndex);
            RestoreState(state, null);
        }

        /// <summary>
        /// Save the current scene to the provided save file.
        /// </summary>
        /// 
        public void Save(string saveFile, SaveableEntity sEntity)
        {
            Dictionary<string, object> state = LoadFile(saveFile);
            CaptureState(state, sEntity);
            SaveFile(saveFile, state);
        }

        private void SaveFile(string saveFile, object state)
        {
            string path = GetDirectory(saveFile);
            print("Saving to " + path);
            using (FileStream stream = File.Open(path, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, state);
            }
        }

        private void CaptureState(Dictionary<string, object> state, SaveableEntity sEntity)
        {
            state[sEntity.GetUniqueIdentifier()] = sEntity.CaptureState();

            /* state["lastSceneBuildIndex"] = SceneManager.GetActiveScene().buildIndex;*/
        }

        private Dictionary<string, object> LoadFile(string saveFile)
        {
            string path = GetDirectory(saveFile);
            if (!File.Exists(path))
            {
                return new Dictionary<string, object>();
            }
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (Dictionary<string, object>)formatter.Deserialize(stream);
            }
        }
        /// <summary>
        /// Delete the state in the given save file.
        /// </summary>
        public void Delete(string saveFile)
        {
            File.Delete(GetDirectory(saveFile));
        }

        // PRIVATE

        public void Load(string saveFile, SaveableEntity sEntity)
        {
            RestoreState(LoadFile(saveFile), sEntity);
        }

        private void RestoreState(Dictionary<string, object> state, SaveableEntity sEntity)
        {
            /*foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>())
            {
                string id = saveable.GetUniqueIdentifier();
                if (state.ContainsKey(id))
                {
                    saveable.RestoreState(state[id]);
                }
            }*/

            sEntity.RestoreState(state[sEntity.GetUniqueIdentifier()]);
        }

        private string GetDirectory(string saveFile)
        {
            if(!Directory.Exists(Application.persistentDataPath + "/Saves"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
            }
            return Path.Combine(Application.persistentDataPath + "/Saves", saveFile + ".sav");
        }
    }
}