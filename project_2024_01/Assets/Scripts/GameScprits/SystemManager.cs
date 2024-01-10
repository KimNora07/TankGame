using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public enum ROUNDTYPE : int{
        NORMAL,
        BOSS
    }

    public ROUNDTYPE roundType = ROUNDTYPE.NORMAL;

    public int roundIndex = 1;
    public float roundTime = 0.0f;
    public float roundEndTime = 30.0f;

    public float spawnTime = 0.0f;
    public float nextspawnTime = 2.0f;

    public GameObject[] EnemyObjects;
    public GameObject[] EnemyBossObj;
    public Transform[] spawntransform;
    public GameObject EnemyBossCheck;

    public GameObject player;

    // Update is called once per frame
    void Update()
    { 
        if(GameManager.Instance.gameStation != GameManager.GAMESTATION.PLAY) return;

        if (player != null)
        {
            if(roundType == ROUNDTYPE.NORMAL){
                spawnTime += Time.deltaTime;
                roundTime += Time.deltaTime;
            }
            else if(roundType == ROUNDTYPE.BOSS){
                if(EnemyBossCheck == null){
                    roundType = ROUNDTYPE.NORMAL;
                    roundIndex  += 1;
                    if(EnemyBossObj.Length < roundIndex){
                        roundIndex = EnemyBossObj.Length;
                    }
                }
            }

            if(roundEndTime <= roundTime){
                int SpawntransformCount = spawntransform.Length;
                int RandSpawntransformNumer = Random.Range(0, SpawntransformCount);
                GameObject temp = (GameObject)Instantiate(EnemyBossObj[roundIndex - 1], spawntransform[RandSpawntransformNumer].position, Quaternion.identity);
                EnemyBossCheck = temp;
                roundTime = 0.0f;
                roundType = ROUNDTYPE.BOSS;
            }

            if(nextspawnTime <= spawnTime)
            {
                spawnTime = 0.0f;
                nextspawnTime = Random.Range(0.5f, 2.0f);   //�������� ���� ���� �ð��� �����Ѵ�. 

                int EnemyObjectsCount = EnemyObjects.Length;            //����� �� ��ü�� ���ڸ� �����´�.
                int SpawntransformCount = spawntransform.Length;        //����� ���� ����Ʈ�� ������ �����´�.

                int RandEnemyObjectNumer = Random.Range(0, EnemyObjectsCount);      //������ ���ڸ� �ִ�� ���� ���� ���ڸ� ���� 
                int RandSpawntransformNumer = Random.Range(0, SpawntransformCount); //������ ���ڸ� �ִ�� ���� ���� ���ڸ� ���� 

                //�ش� ���� ���ڸ� ������� ��ϵ� ���� �迭 ��ȣ�� ���� ����Ʈ ��ȣ�� ��ġ�� ���� ���� ��Ų��. 
                GameObject temp = (GameObject)Instantiate(
                    EnemyObjects[RandEnemyObjectNumer] , spawntransform[RandSpawntransformNumer].position , Quaternion.identity);

            }


            if (player.transform.position.y < -50.0f)        //position �� y ���� ��ȸ�� ���� ���� �Է� �Ұ� (Vector3�θ� ������ �Է� ����)
            {
                player.transform.position = Vector3.zero + new Vector3(0.0f, 1.0f, 0.0f);   //Vector3.zero => new Vector3(0.0f,0.0f,0.0f)
                player.transform.rotation = Quaternion.identity;    //Quaternion.identity => new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            }
        }
    }
}
