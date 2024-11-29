namespace Mediapipe.Test;

internal class Program
{
    static void Main(string[] args)
    {
        var temp = new FaceLandmarkerTest();
        temp.Init();
        temp.PutImage("lenna.png");
    }
}
