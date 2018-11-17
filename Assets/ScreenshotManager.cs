using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenshotManager : MonoBehaviour {

	public int _w;
	public int _h;
	float offset_Y;
	bool saveItToDisk;
	Texture2D texture;

	void Start()
	{
		
		//el top de la image: rawimagekinect
		offset_Y = 289;

		Events.TakeSnapshot += TakeSnapshot;
		Events.SaveImage += SaveImage;
	}
	public void TakeSnapshot()
	{
		StopAllCoroutines ();
		this.saveItToDisk = true;
		StartCoroutine (TakeSnapshot (_w, _h));
	}
	WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();
	public IEnumerator TakeSnapshot(int w, int h)
	{
		yield return frameEnd;

		texture = new Texture2D(w,h, TextureFormat.RGB24, true);
		texture.ReadPixels(new Rect(0, offset_Y, _w, _h), 0, 0);
		texture.LoadRawTextureData(texture.GetRawTextureData());
		texture.Apply();

		Events.SetTexture (texture);

	}
	string imageName;
	void SaveImage(string _imageName)
	{
		this.imageName = _imageName;
		StartCoroutine (UploadPNG());
	}
	IEnumerator UploadPNG()
	{
		yield return new WaitForEndOfFrame();
		byte[] bytes = texture.EncodeToPNG();
		File.WriteAllBytes(Application.streamingAssetsPath + "/unsend/" + imageName + ".png", bytes);

	}

}
