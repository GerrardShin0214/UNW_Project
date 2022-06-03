using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeCharacter : MonoBehaviour
{
	// ĳ���� ����: ���� ������ ������ ���� ��ư�� ������, Ÿ�� ���� �����Ӽ��� ĳ���Ͱ� ��ġ
	// Start is called before the first frame update

	// ��ư�� ������ == ��ư�� ������ ��

	public Button yourButton;

	public GameObject prefabCharacter;
	public Transform parent;
    List<int> poketList = new List<int>();
	List<(int x, int z)> placedCellDataStruct = new List<(int x, int z)>();
	void Start()
	{
        //1.�ָӴϿ� ��ȣǥ�� �ڸ����� �̸� �־��.
        for (int i = 0; i < 24; ++i)
        {
            poketList.Add(i);            
        }

		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	// ��ư�� Ŭ���ϸ� �� �Լ��� ȣ��
	void TaskOnClick()
	{        
        //2.�ָӴ��� �ȿ��� �ƹ��ų� �̴´�.
        // 24 -> 23 -> 22 -> 21
        int randIndex = Random.Range(0, poketList.Count);
        int selectedPlaceNumber = poketList[randIndex];

        //3.�ָӴϿ��� ������ �̾� ��
        poketList.Remove(selectedPlaceNumber);

        // selectedPlaceNumber -> ��ġ�� ��ȯ ���� �� ��.
        // ��ġ�� Ȯ���� �Ǹ� ĳ���͸� �����Ѵ�.
        int x = selectedPlaceNumber / 4;
        int z = selectedPlaceNumber % 4;
        GameObject myInstance = Instantiate(prefabCharacter);
        Vector3 RandomPos = new Vector3(x, 0, z);
        myInstance.transform.position = RandomPos;
    }

    // ��ͷ� �ذ��� ����
    void RecursiveTaskOnClick()
    {
        int mapSizeX = UnityEngine.Random.Range(0, 6);
        int mapSizeZ = UnityEngine.Random.Range(0, 4);
        (int x, int z) cellData = (mapSizeX, mapSizeZ);

        // �ٵ� �̹� ��ġ�� ��ġ���?
        // ĳ���̶�� ����
        // ���� �ѹ� ��ġ�� �Ѱ��� �����ϰ�, ������ ���� ���� ã�� �� �ִ� �ڷ� ����,
        bool isAlreadyPlaced = placedCellDataStruct.Contains(cellData);
        if (isAlreadyPlaced)
        {
            // �ٽ� ��ġ�� ����.
            RecursiveTaskOnClick();
            return;
        }

        // ��ġ�� Ȯ���� �Ǹ� ĳ���͸� �����Ѵ�.
        GameObject myInstance = Instantiate(prefabCharacter);
        Vector3 RandomPos = new Vector3(cellData.x, 0, cellData.z);
        myInstance.transform.position = RandomPos;

        // ��� ��ġ�ߴ��� "�ڷᱸ��" �� ����� �Ѵ�.
        placedCellDataStruct.Add(cellData);

        Debug.Log("Character Generate!");
        // ������ �ݵ�� ĳ���͸� �������� ��ó�� �����ǵ���!
    }
}

