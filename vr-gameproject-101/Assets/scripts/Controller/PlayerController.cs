using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6;                                                  //���� �̵� ���ǽ� �����ϰ� ����
    public GameObject PlayerPivot;                                               //�þ߸� ��� ������ ������ �����ϱ� ���� ��ġ Piovt
    Camera viewCamera;                                                           //���� ī�޶� �������� ���� ī�޶� Ŭ���� ����
    Vector3 velocity;                                                            //�̵� ���� ���͸� ����
    public ProjectileController projectileController;                          //�߻�ü Ŭ���� ����

    public int Player_Hp = 50;                                    //���� HP ����

    public void Damanged(int Damage)                              //������ �޴� �Լ� ����
    {
        Player_Hp -= Damage;                                     //���� ������ HP�� �ݿ�

        if (Player_Hp < 0)                                        //0 ���Ϸ� ��������
        {
            Destroy(this.gameObject);                             //���� ������Ʈ �ı�
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;                                                //���� ī�޶� �������� ���ؼ� start���� ã�Ƽ� �Է�
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))                                         //���콺 ��ư ������
        {
            projectileController.FireProjectile();                              //�߻�ü �߻�
        }

        //��ǻ�� ȭ�� 2D�� ���콺 ��ǥ���� ī�޶� ����� �� 3D ���������� ���콺 ��ġ ���� �������� ���ؼ�
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));

        //�÷��̾ ������ Ÿ�� ����Ʈ
        Vector3 targetposition = new Vector3(mousePos.x, transform.position.y, mousePos.z);

        //�÷��̾� �Ǻ��� ������� �ϴ� ��ǥ�� ����
        PlayerPivot.transform.LookAt(targetposition, Vector3.up);

        //input �� ���� ĳ���� �̵� ���͸� �����Ѵ�.
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;
    }

    private void FixedUpdate()
    {    //����� ���͸� �÷��̾� ��Ʈ�ѷ��� �ִ� Rigidbody�� �����ؼ� �̵� ���͸� �����ð� Time ��ŭ �̵������ִ� ����
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + velocity * Time.fixedDeltaTime);
    }

}
