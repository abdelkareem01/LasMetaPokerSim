using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FusionInit : MonoBehaviour
{
    [SerializeField]
    private NetworkRunner runner;

    async void Start()
    {
        runner.ProvideInput = true;

        await runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = "PokerRoom",
            SceneManager = runner.gameObject.AddComponent<NetworkSceneManagerDefault>()
        });

        FusionLogger fusionLogger = new FusionLogger();
        runner.AddCallbacks(fusionLogger);
        SceneManager.LoadScene("Home");
    }

}
