// THIS FILE HAS BEEN COPIED OVER OUT OF THR ASSEMBLY. I DIDN'T CODE THIS.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200043D RID: 1085
[Serializable]
public class MapData
{
	// Token: 0x0600F792 RID: 63378 RVA: 0x000A2326 File Offset: 0x000A0526
	private void JDOHGHPOMNB(float DBIMJHMKHNK)
	{
		this.checkpoints.Add(DBIMJHMKHNK);
	}

	// Token: 0x0600F793 RID: 63379 RVA: 0x000A2334 File Offset: 0x000A0534
	public static int GetLastConfigVersion()
	{
		return 3;
	}

	// Token: 0x0600F794 RID: 63380 RVA: 0x000A2337 File Offset: 0x000A0537
	private void ONBJIBMMIBJ(MapEvent DBIMJHMKHNK)
	{
		this.events.Add(new MapEvent(DBIMJHMKHNK));
	}

	// Token: 0x0600F795 RID: 63381 RVA: 0x000A234A File Offset: 0x000A054A
	public static int LADNNJPOJFG()
	{
		return 5;
	}

	// Token: 0x0600F796 RID: 63382 RVA: 0x00526350 File Offset: 0x00524550
	public MapData(MapData CLCBMMEKBBC)
	{
		this.configVersion = CLCBMMEKBBC.configVersion;
		this.name = CLCBMMEKBBC.name;
		this.info = CLCBMMEKBBC.info;
		this.levelResources = CLCBMMEKBBC.levelResources;
		this.moreInfoURL = CLCBMMEKBBC.moreInfoURL;
		this.speed = CLCBMMEKBBC.speed;
		this.lives = CLCBMMEKBBC.lives;
		this.maxLives = CLCBMMEKBBC.maxLives;
		this.handCount = CLCBMMEKBBC.handCount;
		this.musicFile = CLCBMMEKBBC.musicFile;
		this.musicTime = CLCBMMEKBBC.musicTime;
		this.iconFile = CLCBMMEKBBC.iconFile;
		this.environmentType = CLCBMMEKBBC.environmentType;
		this.e = CLCBMMEKBBC.e;
		this.unlockConditions = new List<string>(CLCBMMEKBBC.unlockConditions.Count);
		CLCBMMEKBBC.unlockConditions.ForEach(new Action<string>(this.BOJHOBEALCC));
		this.tags = new List<string>(CLCBMMEKBBC.tags.Count);
		CLCBMMEKBBC.tags.ForEach(new Action<string>(this.OPBCIJIADAH));
		this.hidden = CLCBMMEKBBC.hidden;
		this.checkpoints = new List<float>(CLCBMMEKBBC.checkpoints.Count);
		CLCBMMEKBBC.checkpoints.ForEach(new Action<float>(this.EHJOEOCEKOA));
		this.events = new List<MapEvent>(CLCBMMEKBBC.events.Count);
		CLCBMMEKBBC.events.ForEach(new Action<MapEvent>(this.DHNKCBGELNF));
	}

	// Token: 0x0600F797 RID: 63383 RVA: 0x0007262D File Offset: 0x0007082D
	public static int GAEEAAPAIAI()
	{
		return 1;
	}

	// Token: 0x0600F798 RID: 63384 RVA: 0x000A2326 File Offset: 0x000A0526
	private void LEGENHENDCN(float DBIMJHMKHNK)
	{
		this.checkpoints.Add(DBIMJHMKHNK);
	}

	// Token: 0x0600F799 RID: 63385 RVA: 0x000A234D File Offset: 0x000A054D
	[CompilerGenerated]
	private void OPBCIJIADAH(string DBIMJHMKHNK)
	{
		if (!string.IsNullOrEmpty(DBIMJHMKHNK))
		{
			this.tags.Add(DBIMJHMKHNK);
		}
	}

	// Token: 0x0600F79A RID: 63386 RVA: 0x000A2326 File Offset: 0x000A0526
	private void AIJKGBMMPHK(float DBIMJHMKHNK)
	{
		this.checkpoints.Add(DBIMJHMKHNK);
	}

	// Token: 0x0600F79B RID: 63387 RVA: 0x000A234D File Offset: 0x000A054D
	private void PNGPIMCLCLF(string DBIMJHMKHNK)
	{
		if (!string.IsNullOrEmpty(DBIMJHMKHNK))
		{
			this.tags.Add(DBIMJHMKHNK);
		}
	}

	// Token: 0x0600F79C RID: 63388 RVA: 0x000A234D File Offset: 0x000A054D
	private void PMCBNJJNCFM(string DBIMJHMKHNK)
	{
		if (!string.IsNullOrEmpty(DBIMJHMKHNK))
		{
			this.tags.Add(DBIMJHMKHNK);
		}
	}

	// Token: 0x0600F79D RID: 63389 RVA: 0x000A2337 File Offset: 0x000A0537
	private void AFGCPMFKJHO(MapEvent DBIMJHMKHNK)
	{
		this.events.Add(new MapEvent(DBIMJHMKHNK));
	}

	// Token: 0x0600F79E RID: 63390 RVA: 0x000A2326 File Offset: 0x000A0526
	[CompilerGenerated]
	private void EHJOEOCEKOA(float DBIMJHMKHNK)
	{
		this.checkpoints.Add(DBIMJHMKHNK);
	}

	// Token: 0x0600F79F RID: 63391 RVA: 0x000A2366 File Offset: 0x000A0566
	public static int JDMEGDFFPFG()
	{
		return 2;
	}

	// Token: 0x0600F7A0 RID: 63392 RVA: 0x0052656C File Offset: 0x0052476C
	public MapData()
	{
	}

	// Token: 0x0600F7A1 RID: 63393 RVA: 0x000A2334 File Offset: 0x000A0534
	public static int GODJBCPCIME()
	{
		return 3;
	}

	// Token: 0x0600F7A2 RID: 63394 RVA: 0x000A2337 File Offset: 0x000A0537
	[CompilerGenerated]
	private void DHNKCBGELNF(MapEvent DBIMJHMKHNK)
	{
		this.events.Add(new MapEvent(DBIMJHMKHNK));
	}

	// Token: 0x0600F7A3 RID: 63395 RVA: 0x000A2369 File Offset: 0x000A0569
	private void OJDPPFLMKKN(string DBIMJHMKHNK)
	{
		if (!string.IsNullOrEmpty(DBIMJHMKHNK))
		{
			this.unlockConditions.Add(DBIMJHMKHNK);
		}
	}

	// Token: 0x0600F7A4 RID: 63396 RVA: 0x000A2369 File Offset: 0x000A0569
	[CompilerGenerated]
	private void BOJHOBEALCC(string DBIMJHMKHNK)
	{
		if (!string.IsNullOrEmpty(DBIMJHMKHNK))
		{
			this.unlockConditions.Add(DBIMJHMKHNK);
		}
	}

	// Token: 0x0600F7A5 RID: 63397 RVA: 0x000A234D File Offset: 0x000A054D
	private void FPCLPFKFLJJ(string DBIMJHMKHNK)
	{
		if (!string.IsNullOrEmpty(DBIMJHMKHNK))
		{
			this.tags.Add(DBIMJHMKHNK);
		}
	}

	// Token: 0x04001B76 RID: 7030
	public int configVersion = 1;

	// Token: 0x04001B77 RID: 7031
	public string name = "No Name";

	// Token: 0x04001B78 RID: 7032
	public string info = "No info";

	// Token: 0x04001B79 RID: 7033
	public List<MapResource> levelResources = new List<MapResource>();

	// Token: 0x04001B7A RID: 7034
	public List<string> tags = new List<string>();

	// Token: 0x04001B7B RID: 7035
	public int handCount = 1;

	// Token: 0x04001B7C RID: 7036
	public string moreInfoURL = string.Empty;

	// Token: 0x04001B7D RID: 7037
	public float speed = 15f;

	// Token: 0x04001B7E RID: 7038
	public int lives = 5;

	// Token: 0x04001B7F RID: 7039
	public int maxLives = 6;

	// Token: 0x04001B80 RID: 7040
	public string musicFile = "music.ogg";

	// Token: 0x04001B81 RID: 7041
	public float musicTime;

	// Token: 0x04001B82 RID: 7042
	public string iconFile = "icon.png";

	// Token: 0x04001B83 RID: 7043
	public int environmentType;

	// Token: 0x04001B84 RID: 7044
	public List<string> unlockConditions = new List<string>();

	// Token: 0x04001B85 RID: 7045
	public bool hidden;

	// Token: 0x04001B86 RID: 7046
	public List<float> checkpoints = new List<float>();

	// Token: 0x04001B87 RID: 7047
	public List<MapEvent> events = new List<MapEvent>();

	// Token: 0x04001B88 RID: 7048
	public string e = string.Empty;

	// Token: 0x0200043E RID: 1086
	public class EData
	{
		// Token: 0x04001B89 RID: 7049
		public int version = 1;

		// Token: 0x04001B8A RID: 7050
		public List<MapEvent> events = new List<MapEvent>();
	}
}
