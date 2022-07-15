using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    // 한판의 게임에 필요한 데이터를 저장하는 공간
    // 데이터 저장 == 자료구조를 의미함

    // AI에 필요한 데이터,
    // 목적지

    public List<Transform> Paths = new List<Transform>();
    private void Awake()
    {
        Instance = this;
    }
}
