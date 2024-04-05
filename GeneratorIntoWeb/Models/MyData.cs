using System.ComponentModel.DataAnnotations;

namespace GeneratorIntoWeb.Models
{
    [Serializable]
    public class MyData
    {
        [Key]
        public int Id { get; set; }
        
        public string text { get; set; }
        public int type { get; set; }
        public bool flag { get; set; }

       // public MyData() { }
        public MyData(string text, int type, bool flag)
        {
            this.text = text;
            this.type = type;
            this.flag = flag;
        }


    }
}
