using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    // ������ ���ӿ� �ʿ��� �����͸� �����ϴ� ����
    // ������ ���� == �ڷᱸ���� �ǹ���

    // AI�� �ʿ��� ������,
    // ������

    public List<Transform> Paths = new List<Transform>();
    private void Awake()
    {
        Instance = this;
    }
}
