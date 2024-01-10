using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject pivot;
    public Camera viewCamera;           //���� ī�޶� �޾ƿ��� Camera ������Ʈ
    public Vector3 velocity;            //�̵� ��
    public Rigidbody body;              //���� ȿ���� �ִ� ��ü ���� �����´�. 

    void Start()
    {

        viewCamera = Camera.main;           //��Ʈ��Ʈ�� ���۵ɶ� ī�޶� �޾ƿ´�.
    }    
    void Update()
    {
        if(GameManager.Instance.gameStation != GameManager.GAMESTATION.PLAY) return;

        //����Ű�� ���ؼ� �̵� ���Ͱ��� �����Ѵ�. 
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * GameManager.Instance.moveSpeed;

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
        if(GameManager.Instance.gameStation != GameManager.GAMESTATION.PLAY) return;
        
        body.MovePosition(body.position + velocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag == "ITEM")
        {     
            //Trigger ���� Item�� Box_HP �� ��� 
            if(other.gameObject.GetComponent<ItemController>().itemtype == ItemController.ITEMTYPE.HP_ITEM)
            {
                GameManager.Instance.currentHp += other.gameObject.GetComponent<ItemController>().amount;        //�����ۿ� �ִ� ��(amount)�� Hp�� ���Ѵ�. 
                if(GameManager.Instance.currentHp > GameManager.Instance.maxHp)   //�ִ� HP ���� ������ ��� 
                {
                    GameManager.Instance.currentHp = GameManager.Instance.maxHp;  //�ִ� Hp�� �����. 
                }
            }

            //Trigger ���� Item�� Box_Exp �� ��� 
            if (other.gameObject.GetComponent<ItemController>().itemtype == ItemController.ITEMTYPE.EXP_ITEM)
            {
                GameManager.Instance.ExpUp(other.gameObject.GetComponent<ItemController>().amount);        //�����ۿ� �ִ� ��(amount)�� Exp�� ���Ѵ�. 
            }

            Destroy(other.gameObject);
        }
    }
}
