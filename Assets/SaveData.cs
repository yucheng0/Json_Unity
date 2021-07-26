using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;                                                // 引用這個才能使用Filestream
using System.Runtime.Serialization.Formatters.Binary;          //引用這個才能用Binary
using System.Xml.Serialization;                                //引用這個才能使用序串化




public class SaveData : MonoBehaviour
{ 
 [SerializeField]
    Text ui_text;
    [SerializeField]
PlayData data;

void Start()
{

}

// Update is called once per frame
void Update()
{
if (Input.GetKeyDown(KeyCode.S))
{
            /* 玩家偏愛 PlayerPref 序列化  */
            /*PlayerPrefs.SetString("name", data.name);
            PlayerPrefs.SetInt("level", data.level);  */


            /* 檔案File 序列化 */
            /*      FileStream fs = new FileStream(Application.dataPath + "/Save.txt", FileMode.Create);                            // 要using system.IO 才能用  FileStream 檔案流
                  StreamWriter sw = new StreamWriter(fs);         //要寫
                  sw.WriteLine(data.name);                      // 一行一寫資料
                  sw.WriteLine(data.level);                   // 一行一寫資料
                  sw.Close();
                  fs.Close();   */

            /*   xml 序列化 */
            /*        BinaryFormatter bf = new BinaryFormatter();
                    Stream s = File.Open(Application.dataPath + "/Save.ept", FileMode.Create);    //文件流
                    bf.Serialize(s, data); //直接寫入  
                    s.Close();  */


            /*       XmlSerializer xml = new XmlSerializer(data.GetType());
                     Stream s = File.Open(Application.dataPath + "/Save.xml", FileMode.Create);    //文件流
                     xml.Serialize(s, data); //直接寫入
                     s.Close();   */

            /* Json 的序列化  */

            //      string a = JsonUtility.ToJson(data);               //這一行就可以轉換data 為Jason的格式了,得到字串
            PlayerPrefs.SetString("jsondata", JsonUtility.ToJson(data));   //存在玩家偏好內

       


            ui_text.text = "儲存完成";
}
    if (Input.GetKeyDown(KeyCode.L))
{
/* 玩家偏愛 PlayerPref 反序列  */
            //      ui_text.text = PlayerPrefs.GetString("name");
            /* data.name = PlayerPrefs.GetString("name");
            data.level = PlayerPrefs.GetInt("level"); */

/* 檔案File 反序列 */
            /*     FileStream fs = new FileStream(Application.dataPath + "/Save.txt", FileMode.Open);                            // 要using system.IO 才能用  FileStream 檔案流
                 StreamReader sr = new StreamReader(fs);  //要讀
                 data.name = sr.ReadLine();
                 data.level = int.Parse(sr.ReadLine());    //因為它讀出來是字串所以要變成整數     */

            /* Binary 反序列  */

            /*       BinaryFormatter bf = new BinaryFormatter();
                   Stream s = File.Open(Application.dataPath + "/Save.ept", FileMode.Open);    //文件流
                   data = (PlayData) bf.Deserialize(s); //直接寫入    強制轉型  */

            /*   xml 反序列 */
    
            /*   XmlSerializer xml = new XmlSerializer(data.GetType());
                   Stream s = File.Open(Application.dataPath + "/Save.xml", FileMode.Open);    //文件流
                   data = (PlayData) xml.Deserialize(s); //直接寫入    強制轉型   */

/* Json 的反序列  */
            data = JsonUtility.FromJson<PlayData>(PlayerPrefs.GetString("jsondata"));  //把json內容拿出來->翻譯成Json的格式（並轉成資料PlayData的類型）

        }
    }

[System.Serializable]
public class PlayData
{
    public string name;
    public int level;
}
}
