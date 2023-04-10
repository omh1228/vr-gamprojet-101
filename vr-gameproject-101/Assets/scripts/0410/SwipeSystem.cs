using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSystem : MonoBehaviour
{
    private Vector2 initialpos;                                                                           //initialpos ����
    public GameObject Character;                                                                          //Character ������ ����

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) initialpos = Input.mousePosition;                                 //������ �� ���콺 ��ġ�� �����Ѵ�. 
        if(Input.GetMouseButtonUp(0)) Calcuate(Input.mousePosition);                                     //���콺�� Up �Ǿ����� �μ��δ� ���콺 ��ġ�� �Է��ϰ� �Լ��� ȣ���Ѵ�.
    }

    void Calcuate(Vector3 finalPos)
    {
        float disX = Mathf.Abs(initialpos.x - finalPos.x);                            //���밪 (Mathf.Abs) dix�� distance�� ���� (�Ÿ�)
        float disY = Mathf.Abs(initialpos.y - finalPos.y);                            //���밪 (Mathf.Abs)

        if (disX > 0 || disY >0)                                                      // || => or
        {
            if (disX > disY)                                                          //������� �������� �˻��ؼ� ū������ �Ǵ�.
            {
                if (initialpos.x > finalPos.x) Character.transform.position += new Vector3(-1.0f, 0.0f, 0.0f);//����
                else Character.transform.position += new Vector3(1.0f, 0.0f, 0.0f); //������
            }
            else
            {
                if(initialpos.y > finalPos.y) Character.transform.position += new Vector3(0.0f, 0.0f, -1.0f); //����
                else Character.transform.position += new Vector3(0.0f, 0.0f, 1.0f); //����
            }
        } 
    }
}
