using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                                   //UI�� �����ϱ� ���ؼ� ���
public class Player
{
    private int hp = 100;                                               //hp �� �������� 100�� ���� �Է�
    private int Power = 50;                                             //power�� ������ �� 50�� ���� �Է�
    public void Attack()
    {
        Debug.Log(this.Power + "�������� ������.");                    //this�� Player Ŭ������ �̾߱��Ѵ�.
    }
    public void Damage(int damage)                                     //Damage �Լ��� int ���·� ���� ���̹� �μ��� �޴´�.
    {
        this.hp -= damage;                                             
        Debug.Log(damage + " �������� �Ծ���.");
    }
    public int GetHp()                                                //Private �� ����Ǿ��ִ� Hp ���� ���� �Լ��� ���ؼ� ����
    {
        return this.hp;
    }
}
public class Test_008 : MonoBehaviour
{
    Player Player_01 = new Player();                                 //���� ���� �÷��̾� Ŭ������ �����Ѵ�.(������ ����ϱ� ���ؼ�)
    Player Player_02 = new Player();                                 //���� ���� �÷��̾� Ŭ������ �����Ѵ�.(������ ����ϱ� ���ؼ�)
    public Text Player01HP;                                          //�÷��̾� HP�� �����ִ� UI ����
    public Text Player02HP;                                          //�÷��̾� HP�� �����ִ� UI ����
    // Start is called before the first frame update
    void Start()
    {
        
        Player_01.Attack();                                           //������ Player_01 �� Attack �Լ��� �����Ų��.
        Player_01.Damage(30);                                         //������ Player_01 �� Damage �Լ��� �����Ų��. (�μ� 30�� �־��ش�.)
    }

    // Update is called once per frame
    void Update()
    {   //UI�� ������Ʈ�� ���
        Player01HP.text = "Player 01 HP : " + Player_01.GetHp().ToString();                        //GetHp() �Լ��� ȣ���ϰ� ToString���� ���ڿ��� ��ȯ
        Player02HP.text = "Player 02 HP : " + Player_02.GetHp().ToString();                        //GetHp() �Լ��� ȣ���ϰ� ToString���� ���ڿ��� ��ȯ

        if (Input.GetMouseButtonDown(0))                                        //���� ���콺�� ��������
        {
            Player_01.Damage(1);                                                //Player_01�� ��ü�� �Լ� Damage�� ���� (�Ķ���ͷδ� 1�� ����)
        }

        if(Input.GetMouseButtonDown(1))                                         //������ ���콺�� ��������
        {
            Player_02.Damage(1);                                                // Player_02�� ��ü�� �Լ� Damage�� ����(�Ķ���ͷδ� 1�� ����)
        }
    }
}
