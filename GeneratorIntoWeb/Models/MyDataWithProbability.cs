namespace GeneratorIntoWeb.Models
{
    /// <summary>
    /// Answer that has a certain probability of appearing
    /// </summary>
    public class MyDataWithProbability : MyData
    {
        public double probability { get; set; }

        public MyDataWithProbability(string text, int type, bool flag, double probability) : base(text, type, flag)
        {
            this.probability = probability;
        }
    }
}
