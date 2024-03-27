using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Project.Runtime.Core.Singleton;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace _Project.Runtime.Core.Bundle.Scripts
{
    public class BundleModel : SingletonModel<BundleModel>
    {
        private Dictionary<string, SceneInstance> _sceneMap = new Dictionary<string, SceneInstance>();
        public async Task<GameObject> LoadPrefab(string key, Transform parent)
        {
            var asyncOperationHandle = Addressables.InstantiateAsync(key,parent);
            await asyncOperationHandle.Task;
            return asyncOperationHandle.Result;
        }
        

        public async Task<Sprite> LoadAssetAsync(string key)
        {
            var asyncOperationHandle = Addressables.LoadAssetAsync<Sprite>(key);
            await asyncOperationHandle.Task;
            return asyncOperationHandle.Result;
        }

        public async Task LoadScene(string sceneKey,LoadSceneMode sceneMode = LoadSceneMode.Single)
        {
            var asyncOperationHandle = Addressables.LoadSceneAsync(sceneKey,sceneMode);
            SceneInstance sceneInstance = await asyncOperationHandle.Task;
            _sceneMap.Add(sceneKey,sceneInstance);
        }
        
        
        public async Task UnLoadScene(string sceneKey)
        {
            var sceneInstance = _sceneMap[sceneKey];
            var asyncOperationHandle = Addressables.UnloadSceneAsync(sceneInstance);
            await asyncOperationHandle.Task;
            _sceneMap.Remove(sceneKey);
        }
    }
}
