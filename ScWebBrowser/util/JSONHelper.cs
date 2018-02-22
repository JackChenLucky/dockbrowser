using System;
using System.Collections.Generic;
using System.Text;

namespace ScWebBrowser.util
{
    public class Json
    {
        public Json() { }
        public Json(string firstname, object lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private object _lastName;

        public object LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
    }

    public class JSONHelper
    {
        public static List<Json> Serialize(string str, Queue<object> quStr)
        {
        if (quStr == null) {
            string[] sArray = str.Split(new char[6] { '{', '}', ',', ':', '\"', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            quStr = new Queue<object>();
            for (int i = 0; i < sArray.Length; i++)
                if (sArray[i] != "\"")
                {
                    int a;
                    if (int.TryParse(sArray[i], out a))
                        quStr.Enqueue(a);
                    else
                        quStr.Enqueue(sArray[i]);
                }
        }
        List<Json> json = new List<Json>();
        json.Add(new Json());
        for (int i = 0; i < str.Length; i++)
        {
            switch (str[i])
            {
                case '{':
                    Stack<char> parentheses = new Stack<char>();
                    parentheses.Push('{');
                    int j = i;
                    while (parentheses.Count > 0)//找到与之匹配的反括号的位置
                    {
                        j++;
                        if (str[j] == '}')
                            parentheses.Pop();
                        if (str[j] == '{')
                            parentheses.Push('{');
                    }
                    if (json[json.Count - 1].FirstName == null)
                        json = Serialize(str.Substring(i + 1, j - i - 1), quStr);
                    else
                        json[json.Count - 1].LastName = Serialize(str.Substring(i + 1, j - i - 1), quStr);//解析括号里的json数据
                    i = j;
                    break;
                case ',':
                    json[json.Count - 1].LastName = quStr.Dequeue();
                    json.Add(new Json());
                    continue;
                case ':':
                    json[json.Count - 1].FirstName = quStr.Dequeue().ToString();
                    continue;
                case '\\': continue;
                case '\"': continue;
                default: continue;
            }
        }
        if (quStr.Count > 0)
            json[json.Count - 1].LastName = quStr.Dequeue();
        return json;
    }
    public static string DeSerialize(List<Json> json, string mark)
    {
        if(string.IsNullOrEmpty(mark)){
            mark = "\"";
        }
        if (json == null)
            return null;
        Queue<object> quStr = new Queue<object>();
        quStr.Enqueue("{");
        for (int i = 0; i < json.Count; i++)
        {
            quStr.Enqueue(mark + json[i].FirstName + mark);
            quStr.Enqueue(":");
            if (json[i].LastName.GetType() == json.GetType())
                quStr.Enqueue(string.Format("{0}{1}{2}", mark, DeSerialize(json[i].LastName as List<Json>, "\\\""), mark));//解析json子节点的内容
            else if (json[i].LastName.GetType() == (":").GetType())
                quStr.Enqueue(mark + json[i].LastName + mark);
            else
                quStr.Enqueue((int)json[i].LastName);
            if (i < json.Count - 1)
                quStr.Enqueue(",");
        }
        quStr.Enqueue("}");
        string[] sarr = new string[quStr.Count];
        for (int j = 0; j < sarr.Length; j++)
            sarr[j] = quStr.Dequeue().ToString();
        return string.Join("", sarr);
    }
    }
}
