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
        // ���� ��Ƽ� ������ ��ġ�� �����ߴ�.
        // ü���� ��´�.
        // �׸��� ���� �ı���Ų��.

        Destroy(gameObject);
    }
}
