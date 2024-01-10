using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour         //�Ѿ� Ŭ���� ����
{
    public enum PROJECTILETYPE : int                //ENUM ������ �Ѿ��� ���� ������ ����
    {
        PLAYER,
        ENEMY,
    }

    public float lifeTime = 10.0f;              //�Ѿ� ���� �� ������� �ð� ex) 10�� 
    public float moveSpeed = 20.0f;             //�Ѿ� �ӵ� ����
    public int damage = 1;                      //���� ������ ����

    public GameObject VFX_Fire_B;
    public GameObject VFX_WW_Explosion;

    public PROJECTILETYPE projectileType = PROJECTILETYPE.PLAYER;        //����Ʈ�� �÷��̾� 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ENEMY" && projectileType == PROJECTILETYPE.PLAYER)     //Tag ���� Enemy�̰� �÷��̾ ������
        {
            Destroy(this.gameObject);

            Vector3 point = other.ClosestPoint(transform.position);     //�浹�� �Ͼ ����Ʈ 
            GameObject tempVFX = (GameObject)Instantiate(VFX_Fire_B, point ,Quaternion.identity);   //�浹�� �Ͼ ����Ʈ�� ����Ʈ �߰�

            other.gameObject.GetComponent<EnemyController>().currentHP -= damage;

            if(other.gameObject.GetComponent<EnemyController>().currentHP <= 0)
            {
                Instantiate(VFX_WW_Explosion, point, Quaternion.identity);   //������ �ı��Ǵ� ����Ʈ�� ����Ʈ �߰�
                other.gameObject.GetComponent<EnemyController>().DropItems();   //������ �ı��Ǳ� ������ ��� ������ �߰� 
                Destroy(other.gameObject);               
            }
        }

        if (other.gameObject.tag == "Player" && projectileType == PROJECTILETYPE.ENEMY)     //Tag ���� Enemy�̰� �÷��̾ ������
        {
            Destroy(this.gameObject);
            Vector3 point = other.ClosestPoint(transform.position);     //�浹�� �Ͼ ����Ʈ 
            GameObject tempVFX = (GameObject)Instantiate(VFX_Fire_B, point, Quaternion.identity);   //�浹�� �Ͼ ����Ʈ�� ����Ʈ �߰�

            GameManager.Instance.currentHp -= damage;

            if (GameManager.Instance.currentHp <= 0)
            {
                Instantiate(VFX_WW_Explosion, point, Quaternion.identity);   //�÷��̾ �ı� �Ǵ� ����Ʈ�� �ش�. 
                Destroy(other.gameObject);
            }
        }

    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);  //�Ѿ��� Z�� �չ������� �̵��ϰ� 

        lifeTime -= Time.deltaTime;                                         //�ʸ� �����Ͽ� �ð� Ȯ��
        if (lifeTime < 0.0f)
        {
            Destroy(this.gameObject);                                       //������Ʈ �ı�
        }
    }
}
