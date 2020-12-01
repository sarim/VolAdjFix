using System;
using VideoPlayerController;

public static class Gittu
{
    static void Main(string[] args)
    {
        float volumeLevel;
        float targetVolume = float.Parse(args[0]);
        Console.WriteLine("VolAdj Monitoring started. Target Volume: {0}", targetVolume);
        while(true)
        {
            volumeLevel = AudioManager.GetMasterVolume();
            if (Math.Abs(volumeLevel - targetVolume) >= 1) {
                AudioManager.SetMasterVolume(targetVolume);
                Console.WriteLine("Volume Adjusted to: {0} from: {1}", targetVolume, volumeLevel);
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}