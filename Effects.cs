#region

using System.Numerics;

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;


#endregion

namespace Claneder;
public sealed partial class MainWindow : Window
{
 private MediaPlayer _mediaPlayer = new MediaPlayer(); // Initialize the field to resolve CS8618  

 public enum SoundType
 {
  Azan,
  Hour
 }

 private void PlaySound(SoundType soundType)
 {
  // Set the sound file based on the sound type  
  string soundFilePath = soundType switch
  {
   SoundType.Azan => "Sounds/Azan.wav",
   SoundType.Hour => "Sounds/Hour.mp3",
   _ => throw new ArgumentOutOfRangeException(nameof(soundType), soundType, null)
  };

  try
  {
   // Use the full path for the sound file  

   _mediaPlayer.Open(new Uri(soundFilePath, UriKind.Relative));
   

   _mediaPlayer.Play();
  }
  catch (Exception ex)
  {
   MessageBox.Show($"Error playing sound: {ex.Message}");
  }
 }
}

