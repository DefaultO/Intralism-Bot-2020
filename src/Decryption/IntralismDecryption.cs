// this file has been copied over out of the assembly (you can see the token comments, that's a significant mark that shows you
// it's taken from a Unitys Assembly-CSharp.dll (using dnSpy). i didn't code this. i did edit this one though (renames were done & summaries were added)
// and the hardcoded foldername was fixed. leave this watermark if you aknowledge the work put into this class.

// edit by: https://github.com/DefaultO

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

// Token: 0x0200040D RID: 1037
public static class IntralismDecryption
{
	// Token: 0x0600ED9F RID: 60831 RVA: 0x00510200 File Offset: 0x0050E400
	private static byte[] Read(Stream BDIMLMKEEKO)
	{
		byte[] array = new byte[4];
		if (BDIMLMKEEKO.Read(array, 0, array.Length) != array.Length)
		{
			throw new SystemException("Stream did not contain properly formatted byte array");
		}
		byte[] array2 = new byte[BitConverter.ToInt32(array, 0)];
		if (BDIMLMKEEKO.Read(array2, 0, array2.Length) != array2.Length)
		{
			throw new SystemException("Did not read byte array properly");
		}
		return array2;
	}

        #region Encryption
        // Token: 0x0600ED9B RID: 60827 RVA: 0x0050FE94 File Offset: 0x0050E094
    	public static string Encrypt(string KDGOMEPJIKK, string JBKAHNLOKCE = null)
	{
		if (string.IsNullOrEmpty(KDGOMEPJIKK))
		{
			throw new ArgumentNullException("plainText");
		}
		if (string.IsNullOrEmpty(JBKAHNLOKCE))
		{
			JBKAHNLOKCE = global::IntralismDecryption.hardcodedFolderName;
		}
		string result = null;
		RijndaelManaged rijndaelManaged = null;
		try
		{
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(JBKAHNLOKCE, global::IntralismDecryption.hardcodedCryptoPassword);
			rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(BitConverter.GetBytes(rijndaelManaged.IV.Length), 0, 4);
				memoryStream.Write(rijndaelManaged.IV, 0, rijndaelManaged.IV.Length);
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
					{
						streamWriter.Write(KDGOMEPJIKK);
					}
				}
				result = Convert.ToBase64String(memoryStream.ToArray());
			}
		}
		finally
		{
			if (rijndaelManaged != null)
			{
				rijndaelManaged.Clear();
			}
		}
		return result;
	}

	// Token: 0x0600ED9C RID: 60828 RVA: 0x0050FFE8 File Offset: 0x0050E1E8
	public static byte[] EncryptBytes(byte[] FMFLEPJIKAI, string JBKAHNLOKCE)
	{
		PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(JBKAHNLOKCE, global::IntralismDecryption.hardcodedCryptoPassword);
		MemoryStream memoryStream = new MemoryStream();
		Aes aes = new AesManaged();
		aes.Key = passwordDeriveBytes.GetBytes(aes.KeySize / 8);
		aes.IV = passwordDeriveBytes.GetBytes(aes.BlockSize / 8);
		CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(FMFLEPJIKAI, 0, FMFLEPJIKAI.Length);
		cryptoStream.Close();
		return memoryStream.ToArray();
	}
	#endregion

	#region Decryption
	// Token: 0x0600ED9E RID: 60830 RVA: 0x005100D0 File Offset: 0x0050E2D0
	/// <summary><see cref="Decrypt(string, string)"/> is the Method you call for decrypting the Config V3's edata
	/// <para><paramref name="mapDataE"/> is the encrypted text you will find in a V3 Config inside the e (events). <paramref name="folderName"/> gets used by the crypto. I hardcoded it for you in case you are too lazy to get it out of the memory (SaveSystem). You can leave the second parameter empty if it still is up-to-date! It didn't changed since the encryption was implemented for the first time (last year or so). It's unlikely, that it will change.</para>
	/// <para>Here's how you could make a second paragraph in a description. <see cref="System.Console.WriteLine(System.String)"/> for information about output statements.</para>
	/// See <seealso cref="Intralism_Bot_ReB_o_ot.Decryption.Example"/> for an overviewable Usage Example (v3 to v2 converter)! Feel free to paste it. But also do some exception handling, etc since the way I have done it, is very ghetto-like.
	/// </summary>
	public static string Decrypt(string mapDataE, string folderName = null)
	{
		if (string.IsNullOrEmpty(mapDataE))
		{
			throw new ArgumentNullException("cipherText");
		}
		if (string.IsNullOrEmpty(folderName))
		{
			folderName = global::IntralismDecryption.hardcodedFolderName;
		}
		RijndaelManaged rijndaelManaged = null;
		string result = null;
		try
		{
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(folderName, global::IntralismDecryption.hardcodedCryptoPassword);
			byte[] buffer = Convert.FromBase64String(mapDataE);
			using (MemoryStream memoryStream = new MemoryStream(buffer))
			{
				rijndaelManaged = new RijndaelManaged();
				rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
				rijndaelManaged.IV = global::IntralismDecryption.Read(memoryStream);
				ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
				{
					using (StreamReader streamReader = new StreamReader(cryptoStream))
					{
						result = streamReader.ReadToEnd();
					}
				}
			}
		}
		finally
		{
			if (rijndaelManaged != null)
			{
				rijndaelManaged.Clear();
			}
		}
		return result;
	}

	// Token: 0x0600ED9D RID: 60829 RVA: 0x0051005C File Offset: 0x0050E25C
	public static byte[] DecryptBytes(byte[] FMFLEPJIKAI, string JBKAHNLOKCE)
	{
		PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(JBKAHNLOKCE, global::IntralismDecryption.hardcodedCryptoPassword);
		MemoryStream memoryStream = new MemoryStream();
		Aes aes = new AesManaged();
		aes.Key = passwordDeriveBytes.GetBytes(aes.KeySize / 8);
		aes.IV = passwordDeriveBytes.GetBytes(aes.BlockSize / 8);
		CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(FMFLEPJIKAI, 0, FMFLEPJIKAI.Length);
		cryptoStream.Close();
		return memoryStream.ToArray();
	}
    	#endregion

    	// Token: 0x04001A9C RID: 6812
    	// Actual One: xJutAalS5sedTosjHpZ0
	// Original: 88f00bdf0ad61b16b803971ebe071962
        private static string hardcodedFolderName = "xJutAalS5sedTosjHpZ0";

	// Token: 0x04001A9D RID: 6813
	private static byte[] hardcodedCryptoPassword = Encoding.ASCII.GetBytes("d264dbba9c2410771b4ad918903b3f4cd9e276a9");
}
