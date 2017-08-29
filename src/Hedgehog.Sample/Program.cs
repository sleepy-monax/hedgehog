namespace Hedgehog.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new Vector3D(0, 0, 0) + new Vector3D(0, 0, 0);
            new SampleGame().Start(60f);
        }
    }
}
