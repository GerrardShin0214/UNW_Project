using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 이 클래스가 하는 역활
    // 타겟을 향해서 이동해야함.
    // 이동에는 필요한거,

    GameObject target;
    float speed;

    public void SetTarget(GameObject inTarget)
    {
        target = inTarget;
    }

    void TryDoDamageToTarget()
    {
        // 총알이 적에게 부딛혀서, 데미지를 준다.
        // 데미지를 줄수도 있고 안줄 수 도 있다, 부딛혔냐 아니냐에 따라서
        // 체크 & 행위

        // 총알이 부딛혔는지
        var toDir = target.transform.position - transform.position;
        var distance = toDir.magnitude;
        if(distance < 0.5)
        {
            // 충돌
            Destroy(gameObject);

            // 타겟에게 데미지도 줘야함
            // target에게서, 좀비 컴포넌트 가져와서, SetDamage를 호출
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        // 물체가 존재하는데, 그체의 위치는
        // x위치, y 위치, z 위치

        // 위치
        // 타겟으로 향하는 방향,
        // 타겟 위치 - 내 위치
        var dir = target.transform.position - transform.position;       
        transform.position += dir * Time.deltaTime;

        // 타겟에게 데미지를 줄 수 있는지 시도
        TryDoDamageToTarget();
    }
}
