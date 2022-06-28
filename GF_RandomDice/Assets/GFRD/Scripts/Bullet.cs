using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // �� Ŭ������ �ϴ� ��Ȱ
    // Ÿ���� ���ؼ� �̵��ؾ���.
    // �̵����� �ʿ��Ѱ�,

    GameObject target;
    float speed;

    public void SetTarget(GameObject inTarget)
    {
        target = inTarget;
    }

    void TryDoDamageToTarget()
    {
        // �Ѿ��� ������ �ε�����, �������� �ش�.
        // �������� �ټ��� �ְ� ���� �� �� �ִ�, �ε����� �ƴϳĿ� ����
        // üũ & ����

        // �Ѿ��� �ε�������
        var toDir = target.transform.position - transform.position;
        var distance = toDir.magnitude;
        if(distance < 0.5)
        {
            // �浹
            Destroy(gameObject);

            // Ÿ�ٿ��� �������� �����
            // target���Լ�, ���� ������Ʈ �����ͼ�, SetDamage�� ȣ��
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

        // ��ü�� �����ϴµ�, ��ü�� ��ġ��
        // x��ġ, y ��ġ, z ��ġ

        // ��ġ
        // Ÿ������ ���ϴ� ����,
        // Ÿ�� ��ġ - �� ��ġ
        var dir = target.transform.position - transform.position;       
        transform.position += dir * Time.deltaTime;

        // Ÿ�ٿ��� �������� �� �� �ִ��� �õ�
        TryDoDamageToTarget();
    }
}
