
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int LineID =0;  //要被拦截的线条
    public bool isDuan;  //判断当前是否拦截线条断开
    public SATA sata;  //当前使用什么铁链
    
    public enum SATA
    { 
    red,   //红色
    black,   //黑色
        Chain,   //锁链
    }


    void Start()
    {
   
        RopeManager.instance.LinedATA = LineID;
        RopeManager.instance.isDuan = isDuan;  //吧参数赋值
        switch (sata) {
            case SATA.red:
                //红白绳子
                print("1");
                break;

            case SATA.black:
                //黑白绳子
                print("2");
                break;

            case SATA.Chain:
                //铁链
                print("3");
                break;
        }
    }


}
