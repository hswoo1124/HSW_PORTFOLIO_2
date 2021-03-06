using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

public class Resturant : MonoBehaviour
{
    #region 프로퍼티
    public string DCodeNm { get; private set; } //식당 분류 => 한식, 중식, 양식, 일식
    public string Seq { get; private set; }
    public string Name { get; private set; }//식당 이름
    public string Addr { get; private set; }//식당 주소
    public string OpenTime { get; private set; }//개점 시간
    public string CloseTime { get; private set; }//폐점 시간
    public string Table1 { get; private set; }//테이블개수 1
    public string[] Price { get; private set; } //음식 가격
    public string[] Title { get; private set; }//음식 이름
    #endregion

    #region 생성자
    public Resturant(string dcodenm, string seq, string name, string addr, string opentime, string closetime, string table1, string[] price, string[] title)
    {
        DCodeNm = dcodenm;
        Seq = seq;
        Name = name;
        Addr = addr;
        OpenTime = opentime;
        CloseTime = closetime;
        Table1 = table1;
        Price = price;
        Title = title;
    }
    #endregion

    #region 파서
    static public Resturant MakeResturant(XmlNode xn)
    {
        string dcodenm = string.Empty;
        string seq = string.Empty;
        string name = string.Empty;
        string addr = string.Empty;
        string opentime = string.Empty;
        string closetime = string.Empty;
        string table1 = string.Empty;
        string price_d = string.Empty;
        string title_d = string.Empty;

        string[] price = new string[10];
        string[] title = new string[10];

        XmlNode dcodenm_node = xn.SelectSingleNode("dCodeNm");
        dcodenm = ConvertString(dcodenm_node.InnerText);

        XmlNode seq_node = xn.SelectSingleNode("foodSeq");
        seq = ConvertString(seq_node.InnerText);

        XmlNode name_node = xn.SelectSingleNode("name");
        name = ConvertString(name_node.InnerText);

        XmlNode addr_node = xn.SelectSingleNode("addr1");
        addr = ConvertString(addr_node.InnerText);

        XmlNode opentime_node = xn.SelectSingleNode("openTime");
        opentime = ConvertString(opentime_node.InnerText);

        XmlNode closetime_node = xn.SelectSingleNode("closeTime");
        closetime = ConvertString(closetime_node.InnerText);

        XmlNode table1_node = xn.SelectSingleNode("table2");
        table1 = ConvertString(table1_node.InnerText);

        XmlNode el = xn.SelectSingleNode("foodMenuEtcListAll");

        int i = 0;
        foreach (XmlNode el2 in el.SelectNodes("FoodMenuEtcList"))
        {
            XmlNode price_d_node = el2.SelectSingleNode("price");
            price_d = ConvertString(price_d_node.InnerText);

            XmlNode title_d_node = el2.SelectSingleNode("title");
            title_d = ConvertString(title_d_node.InnerText);

            price[i] = price_d;
            title[i] = title_d;
            i++;
        }
        for (int i1 = 9; i1 >= 0; i1--)
        {
            if (title[i1] == null)
            {
                title[i1] = "정보없음";
            }
        }
        for (int i2 = 9; i2 >= 0; i2--)
        {
            if (price[i2] == null)
            {
                price[i2] = "정보없음";
            }
        }
        return new Resturant(dcodenm, seq, name, addr, opentime, closetime, table1, price, title);
    }

    static private string ConvertString(string str) //<>없애줌
    {
        int sindex = 0;
        int eindex = 0;
        while (true)
        {
            sindex = str.IndexOf('<');
            if (sindex == -1)
            {
                break;
            }
            eindex = str.IndexOf('>');
            str = str.Remove(sindex, eindex - sindex + 1);
        }
        return str;
    }
    #endregion

}
