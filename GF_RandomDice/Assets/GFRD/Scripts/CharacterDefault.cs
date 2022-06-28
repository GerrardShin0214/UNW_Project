using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDefault : MonoBehaviour
{
    //public FireSkill 
    // �� ��ȹ�� �����Կ� �־ �ʿ��� ����� has �����.
    public GameObject model;
    public GameObject bulletPrefab;

    float accTime;

    public void Fire()
    {
        var bullet = GameObject.Instantiate(bulletPrefab); // �Ѿ��� prefab ���ҽ��� ���� ����
        bullet.transform.position = transform.position;    // �Ѿ��� ��ġ��, �� �ڽ��� ��ġ�� ����

        var bulletComponent = bullet.GetComponent<Bullet>();        // �Ѿ˿� �ʿ��� Ÿ���� �����ϱ� ����, gameObject�� ���� Bullet ������Ʈ ��������
        var zombie = GFRDMakeZombie.GetZombie();                    // �Ѿ˿� �ʿ��� Ÿ�� ��û
        bulletComponent.SetTarget(zombie);                          // ������ Ÿ���� �Ѿ˿��� ����
    }

    public void Update()
    {
        // 1�ʿ� �ѹ��� �Ѿ� ���.
        accTime += Time.deltaTime;  // Update - Update �ð� ��û ���� �ð� �װ��� dt (�̺нð�) delta time
        if (accTime >= 1)
        {
            accTime = 0;
            Fire();
        }
    }
}
