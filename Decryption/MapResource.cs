// THIS FILE HAS BEEN COPIED OVER OUT OF THR ASSEMBLY. I DIDN'T CODE THIS.

using System;

// Token: 0x0200043C RID: 1084
[Serializable]
public class MapResource
{
	// Token: 0x0600F790 RID: 63376 RVA: 0x000A22BF File Offset: 0x000A04BF
	public MapResource()
	{
	}

	// Token: 0x0600F791 RID: 63377 RVA: 0x000A22E8 File Offset: 0x000A04E8
	public MapResource(string EBEHBBDKDFJ, string HMGBJCGOLMI, string BNJFKKGOACF)
	{
		this.name = EBEHBBDKDFJ;
		this.type = HMGBJCGOLMI;
		this.path = BNJFKKGOACF;
	}

	// Token: 0x04001B73 RID: 7027
	public string name = string.Empty;

	// Token: 0x04001B74 RID: 7028
	public string type = string.Empty;

	// Token: 0x04001B75 RID: 7029
	public string path = string.Empty;
}
