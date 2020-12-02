using System;
using VideoPlayerController;

public class VolumeListener
{
    private float TargetVolume;

    public VolumeListener(float targetVolume) {
        TargetVolume = targetVolume;
    }

    public void OnVolumeNotification(AudioVolumeNotificationData notificationData)
    {
        float Volume = notificationData.MasterVolume * 100;
        if (Math.Abs(Volume - TargetVolume) >= 1) {
            AudioManager.SetMasterVolume(TargetVolume);
            Console.WriteLine("Volume Adjusted to: {0} from: {1}", TargetVolume, Volume);
        }
    }
}

public static class Gittu
{
    static void Main(string[] args)
    {
        float targetVolume = float.Parse(args[0]);
        VolumeListener listener;

        Console.WriteLine("VolAdj Monitoring started. Target Volume: {0}", targetVolume);
        AudioManager.SetMasterVolume(targetVolume);

        listener = new VolumeListener(targetVolume);
        AudioManager.SetMasterVolumeNotifier(listener);

        while(true)
        {
            System.Threading.Thread.Sleep(10000);
        }
    }
}