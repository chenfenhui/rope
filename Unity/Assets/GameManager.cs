
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int LineID =0;  //Ҫ�����ص�����
    public bool isDuan;  //�жϵ�ǰ�Ƿ����������Ͽ�
    public SATA sata;  //��ǰʹ��ʲô����
    
    public enum SATA
    { 
    red,   //��ɫ
    black,   //��ɫ
        Chain,   //����
    }


    void Start()
    {
   
        RopeManager.instance.LinedATA = LineID;
        RopeManager.instance.isDuan = isDuan;  //�ɲ�����ֵ
        switch (sata) {
            case SATA.red:
                //�������
                print("1");
                break;

            case SATA.black:
                //�ڰ�����
                print("2");
                break;

            case SATA.Chain:
                //����
                print("3");
                break;
        }
    }


}
