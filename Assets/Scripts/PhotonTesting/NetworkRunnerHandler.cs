using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;
using System.Linq;

public class NetworkRunnerHandler : MonoBehaviour
{
    public NetworkRunner networkRunnerPrefab;
    NetworkRunner networkRunner;
    // Start is called before the first frame update
    void Start()
    {
        networkRunner = Instantiate(networkRunnerPrefab);
        networkRunner.name = "Network Runner";

        var clientTask = InitializeNetworkRunner(networkRunner, GameMode.AutoHostOrClient, NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);

        Debug.Log("Network Server Has Started.");
    }
    //4:30 in video, but go back to 20:20
    protected virtual Task InitializeNetworkRunner(NetworkRunner runner, GameMode gameMode, NetAddress address, SceneRef scene, Action<NetworkRunner> initialized) 
    {
        var sceneManager = runner.GetComponents(typeof(MonoBehaviour)).OfType<INetworkSceneManager>().FirstOrDefault();

        //Make sure there is a sceneManager
        if(sceneManager == null) sceneManager = runner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        runner.ProvideInput = true;

        return runner.StartGame(new StartGameArgs{
            GameMode = gameMode,
            Address = address,
            Scene = scene,
            SessionName = "Test Room",
            Initialized = initialized,
            SceneManager = sceneManager
        });

    }
    
}
