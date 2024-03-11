using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Task = UnityEditor.VersionControl.Task;

public class Bundle : SingletonModel<Bundle>
{
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

    public async Task<SceneInstance> LoadScene(string sceneKey, LoadSceneMode sceneMode = LoadSceneMode.Single)
    {
        var asyncOperationHandle = Addressables.LoadSceneAsync(sceneKey, sceneMode);
        await asyncOperationHandle.Task;
        return asyncOperationHandle.Result;
    }

    
}
