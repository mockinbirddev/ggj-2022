using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerData : MonoBehaviour
{
    // [SerializeField]
    // private string _nickName = null;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     var count = FindObjectsOfType<PlayerData>().Length;
    //         if (count > 1)
    //         {
    //             Destroy(gameObject);
    //             return;
    //         }
    //         DontDestroyOnLoad(gameObject);
    // }

    // public void SetNickName(string nickName)
    // {
    //     _nickName = nickName;
    // }

    // public string GetNickName()
    // {
    //     if (string.IsNullOrWhiteSpace(_nickName))
    //     {
    //         _nickName = GetRandomNickName();
    //     }

    //     return _nickName;
    // }
    // public static string GetRandomNickName()
    // {
    //     var rngPlayerNumber = Random.Range(0, 9999);
    //     return $"Player {rngPlayerNumber.ToString("0000")}";
    // }
}
