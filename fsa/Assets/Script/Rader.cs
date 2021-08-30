using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testgps : MonoBehaviour
{
    public string Position_X { get; set; }
    public string Position_Y { get; set; }
    public testgps(string x, string y)
    {
        Position_X = x;
        Position_Y = y;
    }
}

public class point : MonoBehaviour
{
    public float Position_X { get; set; }
    public float Position_Y { get; set; }
    public point(float x, float y)
    {
        Position_X = x;
        Position_Y = y;
    }
}
public class Rader : MonoBehaviour
{
    public Image my;
    public double lon;
    public double lat;
    public GameObject raderpoint;
    List<point> pt = new List<point>();
    List<testgps> tg = new List<testgps>();
    public Text testtext;
    // Start is called before the first frame update
    void Start()
    {
        lon = 127.445419;
        lat = 36.33609;
        float fx = my.rectTransform.position.x;
        float fy = my.rectTransform.position.y;
        testgps t = new testgps(127.391234.ToString(), 36.30123.ToString());
        tg.Add(t);
        testgps t1 = new testgps(127.374321.ToString(), 36.345685.ToString());
        tg.Add(t1);
        testgps t2 = new testgps(127.459874.ToString(), 36.31474.ToString());
        tg.Add(t2);
       
            foreach (testgps t5 in tg)
            {
                point p = new point(float.Parse((lon - double.Parse(t5.Position_X)).ToString())*500, float.Parse((lat - double.Parse(t5.Position_Y)).ToString())*500);
            testtext.text += p.Position_X.ToString() + "\n";
            testtext.text += p.Position_Y.ToString() + "\n";
            pt.Add(p);
            }
        
    }
    public void butc()
    {
        foreach(point point in pt)
        {
            GameObject g = Instantiate(raderpoint, transform.position + new Vector3(point.Position_X, point.Position_Y, 0), transform.rotation);
            g.GetComponent<RectTransform>().localScale = new Vector3(0.12f, 0.1f, 0);
        }

    }
}
