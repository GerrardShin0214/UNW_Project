using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDefault : MonoBehaviour
{
    //public FireSkill 
    // 이 기획을 구현함에 있어서 필요한 관계는 has 관계다.
    public GameObject model;
    public GameObject bulletPrefab;

    float accTime;

    public void Fire()
    {
        var bullet = GameObject.Instantiate(bulletPrefab); // 총알을 prefab 리소스로 부터 생성
        bullet.transform.position = transform.position;    // 총알의 위치를, 나 자신의 위치로 변경

        var bulletComponent = bullet.GetComponent<Bullet>();        // 총알에 필요한 타겟을 설정하기 위해, gameObject로 부터 Bullet 컴포넌트 가져오기
        var zombie = GFRDMakeZombie.GetZombie();                    // 총알에 필요한 타겟 요청
        bulletComponent.SetTarget(zombie);                          // 가져온 타겟을 총알에게 셋팅
    }

    public void Update()
    {
        // 1초에 한번씩 총알 쏜다.
        accTime += Time.deltaTime;  // Update - Update 시간 엄청 작은 시간 그것을 dt (미분시간) delta time
        if (accTime >= 1)
        {
            accTime = 0;
            Fire();
        }
    }
}
