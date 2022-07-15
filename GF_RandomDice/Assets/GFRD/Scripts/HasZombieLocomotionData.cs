using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasZombieLocomotionData : MonoBehaviour, IHasLocomotionData
{

    [SerializeField]
    LocomotionData locomotionData = new LocomotionData();
    public LocomotionData GetData => locomotionData;
    void Start()
    {
        locomotionData.Pathes = GameDataManager.Instance.Paths;
        locomotionData.OnArrived = OnArrived;
    }

    void OnArrived()
    {
        // 좀비가 살아서 마지막 위치에 도착했다.
        // 체력을 깎는다.
        // 그리고 좀비를 파괴시킨다.

        Destroy(gameObject);
    }
}
