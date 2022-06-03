using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeCharacter : MonoBehaviour
{
	// 캐릭터 생성: 전투 시작전 유저가 생성 버튼을 누르면, 타일 위에 랜덤속성의 캐릭터가 배치
	// Start is called before the first frame update

	// 버튼을 누르면 == 버튼이 눌렸을 때

	public Button yourButton;

	public GameObject prefabCharacter;
	public Transform parent;
    List<int> poketList = new List<int>();
	List<(int x, int z)> placedCellDataStruct = new List<(int x, int z)>();
	void Start()
	{
        //1.주머니에 번호표를 자리별로 미리 넣어놈.
        for (int i = 0; i < 24; ++i)
        {
            poketList.Add(i);            
        }

		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	// 버튼을 클릭하면 이 함수를 호출
	void TaskOnClick()
	{        
        //2.주머니의 안에서 아무거나 뽑는다.
        // 24 -> 23 -> 22 -> 21
        int randIndex = Random.Range(0, poketList.Count);
        int selectedPlaceNumber = poketList[randIndex];

        //3.주머니에서 완전히 뽑아 냄
        poketList.Remove(selectedPlaceNumber);

        // selectedPlaceNumber -> 위치로 변환 시켜 야 함.
        // 위치가 확정이 되면 캐릭터를 생성한다.
        int x = selectedPlaceNumber / 4;
        int z = selectedPlaceNumber % 4;
        GameObject myInstance = Instantiate(prefabCharacter);
        Vector3 RandomPos = new Vector3(x, 0, z);
        myInstance.transform.position = RandomPos;
    }

    // 재귀로 해결한 버전
    void RecursiveTaskOnClick()
    {
        int mapSizeX = UnityEngine.Random.Range(0, 6);
        int mapSizeZ = UnityEngine.Random.Range(0, 4);
        (int x, int z) cellData = (mapSizeX, mapSizeZ);

        // 근데 이미 배치된 위치라면?
        // 캐싱이라는 개념
        // 내가 한번 배치를 한곳을 저장하고, 저장한 것을 쉽게 찾을 수 있는 자료 구조,
        bool isAlreadyPlaced = placedCellDataStruct.Contains(cellData);
        if (isAlreadyPlaced)
        {
            // 다시 배치해 본다.
            RecursiveTaskOnClick();
            return;
        }

        // 위치가 확정이 되면 캐릭터를 생성한다.
        GameObject myInstance = Instantiate(prefabCharacter);
        Vector3 RandomPos = new Vector3(cellData.x, 0, cellData.z);
        myInstance.transform.position = RandomPos;

        // 어디에 배치했는지 "자료구조" 에 기록을 한다.
        placedCellDataStruct.Add(cellData);

        Debug.Log("Character Generate!");
        // 숙제로 반드시 캐릭터를 여러개를 펼처서 생성되도록!
    }
}

