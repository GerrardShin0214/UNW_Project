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
	void Start()
	{


		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		GameObject myInstance = Instantiate(prefabCharacter);

		int mapSizeX = UnityEngine.Random.Range(0,5);
		int mapSizeY = UnityEngine.Random.Range(0,3);


		/* 중복제거
		void RemoveOverlap(int min, int max)
        {
			int currentNumber = Random.Range(min, max);

			for(int i = 0; i < max;)
            {
				if(
				
            }
        }
		*/

		Vector2 RandomPos = new Vector2(mapSizeX, mapSizeY);
		myInstance.transform.position = RandomPos;

		Debug.Log("Character Generate!");







		

		// 숙제로 반드시 캐릭터를 여러개를 펼처서 생성되도록!
	}
}

