# Intralism Bot
 Basic Bot, that works with the latest Update. This will definetly get you banned in it's current state. It hits every Arc perfect which is not humanly possibly.

### TODO: Bypass Process List
The Game creates a Demo of you playing the Map. This Demo contains Keypresses and Input in general and a process List that gets gathered like so:
```csharp
// Token: 0x0600F1E3 RID: 61923 RVA: 0x005178DC File Offset: 0x00515ADC
protected override void JAFCCBIPELN()
{
 this.activeProcesses = new List<string>();
 try
 {
  Process process = new Process();
  process.StartInfo = new ProcessStartInfo
  {
   WindowStyle = ProcessWindowStyle.Hidden,
   FileName = "cmd.exe",
   Arguments = "/C tasklist",
   Verb = "runas",
   RedirectStandardOutput = true,
   RedirectStandardError = true,
   UseShellExecute = false,
   CreateNoWindow = true
  };
  process.Start();
  while (!process.HasExited)
  {
   while (process.StandardOutput.Peek() >= 0)
   {
    this.activeProcesses.Add(process.StandardOutput.ReadLine());
   }
  }
 }
 catch (Exception)
 {
  this.activeProcesses.Add("Error0");
 }
}
```
An easy fix for that is by editing the Projects Properties and change everything to something legit like ``Wallpaper Engine.exe`` or ``Explorer.exe``, you get it. I prefer implementing ``Process Hollowing`` or a direct ``Patch`` to that method though.

### TODO: Add an Humanizer
This is neccessary to trick the Moderators and Oxy to believe that the replay doesn't contain anything abnormal. My old version made in late 2018 had a somewhat simple randomizer built-in. Which was already too good for their eyes, I didn't get manual banned with it. But they really were suspicious, but without being able to proof anything, they didn't do anything. I plan to add a panic key, to intentionally play worse / miss arcs, and make everything based on how the Maps Storyboard is. Is there a Zoom right now that makes hitting a 100% there impossible (without having enough experience, I can get the current tries count out of the memory for that)? And stuff like that. Of course I will try to find out the exact time window you have from a ``100%`` to a ``99%`` Arc Press. Since then I can make this small 1-layer Randomizer for every Arc. The Randomizer will contain multiple layers that affect multiple arcs at the same time (you can't hit them all at the same time, always) and the single ones.

### TODO: Add Input Injection
Who wants to play that game anyways. Wouldn't it be cool to send Keyboard Input to Intralism without it even having to be in the foreground and or active? You could do productive things instead, than playing all those 1-10* Maps that are boring, slow and too long, doesn't matter how good you talk them.

### TODO: Add a Patch for the Family Sharing Check
This Patch won't make it possible for you to rank-up in the Leaderboard, since Ranking will be disabled in case you use Family Share to play on an alt. This is all client-sided and only a check if the App Owner's SteamID is equal to the current playing SteamID, so shouldn't be a problem.

### TODO: Add a Patch for the Kick Method
It happens quite often, that you get kicked out of a lobby of some friends that want just to play together for no reason. Since Oxy still didn't manage to fix the private lobbies, you will have to use public ones, which of course everyone can join in. Kick explained. The Game uses a Method called ``KickThePlayer()`` which actually is just the method that handles the kick, when you get kicked. The kick seems to be client-sided. I thought Oxy would do that one at least server sided. So it just closes the Connection when you get kicked. If you remove a few lines, you get your Antikick Feature. Would look like that after the Patch:
```csharp
// Token: 0x060116FF RID: 71423 RVA: 0x000AA80A File Offset: 0x000A8A0A
[PunRPC]
private void KickThePlayer()
{
 Singleton<MessageBoxPanel>.Instance.DisplayMessage("Sie haben versucht dich zu kicken.\n\n#TEAM EHRENLOS", "OK", null, true, false, 0f);
}
```
