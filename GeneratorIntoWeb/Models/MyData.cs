namespace GeneratorIntoWeb.Models
{
    public class MyData
    {
        public string text;
        public int type;
        public bool flag;
        public double probability;

        public MyData(string text, int type, bool flag, double probability)
        {
            this.text = text;
            this.type = type;
            this.flag = flag;
            this.probability = probability;
        }


    }
}
