namespace Mediapipe.Test;

internal class Program
{
    static void Main(string[] args)
    {
        var temp = new FaceDetectorTest();
        temp.Init();
        temp.PutImage("lenna.png");
    }
}
