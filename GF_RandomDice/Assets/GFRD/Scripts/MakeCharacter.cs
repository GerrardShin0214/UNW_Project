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


		/* �ߺ�����
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







		

		// ������ �ݵ�� ĳ���͸� �������� ��ó�� �����ǵ���!
	}
}

