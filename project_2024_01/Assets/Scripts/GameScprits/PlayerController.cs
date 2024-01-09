using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public GameObject pivot;
    public Camera viewCamera;           //���� ī�޶� �޾ƿ��� Camera ������Ʈ
    public Vector3 velocity;            //�̵� ��
    public Rigidbody body;              //���� ȿ���� �ִ� ��ü ���� �����´�. 

    public int maxHp;
    public int currentHp;
    public int currentExp;

    void Start()
    {
        maxHp = 1000;
        currentHp = 1000;
        currentExp = 0;

        viewCamera = Camera.main;           //��Ʈ��Ʈ�� ���۵ɶ� ī�޶� �޾ƿ´�.
    }    
    void Update()
    {
        //����Ű�� ���ؼ� �̵� ���Ͱ��� �����Ѵ�. 
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;

        //ȭ�鿡�� -> ���� 3D ���� ��ǥ�� ��ȯ�ؼ� Vector3�� �ִ´�. 
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, viewCamera.transform.position.y));

        //������ǥ�� ĳ���ͺ��� ���� ���� ��� ���� ó�� ���⶧���� ���� y�� ���� �����ش�. 
        Vector3 targetPosition = new Vector3(mousePos.x, pivot.transform.position.y,mousePos.z);

        //�Ǻ��� �ش� Ÿ���� �ٶ󺸰� �Ѵ�. 
        pivot.transform.LookAt(targetPosition, Vector3.up);
    }
    private void FixedUpdate()
    {
        body.MovePosition(body.position + velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag == "ITEM")
        {     
            //Trigger ���� Item�� Box_HP �� ��� 
            if(other.gameObject.GetComponent<ItemController>().itemtype == ItemController.ITEMTYPE.HP_ITEM)
            {
                currentHp += other.gameObject.GetComponent<ItemController>().amount;        //�����ۿ� �ִ� ��(amount)�� Hp�� ���Ѵ�. 
                if(currentHp > maxHp)   //�ִ� HP ���� ������ ��� 
                {
                    currentHp = maxHp;  //�ִ� Hp�� �����. 
                }
            }

            //Trigger ���� Item�� Box_Exp �� ��� 
            if (other.gameObject.GetComponent<ItemController>().itemtype == ItemController.ITEMTYPE.EXP_ITEM)
            {
                currentExp += other.gameObject.GetComponent<ItemController>().amount;        //�����ۿ� �ִ� ��(amount)�� Exp�� ���Ѵ�. 
            }

            Destroy(other.gameObject);
        }
    }
}