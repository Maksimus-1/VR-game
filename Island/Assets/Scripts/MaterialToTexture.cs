using UnityEngine;

public class MaterialToTexture : MonoBehaviour
{
    public Material materialToConvert; // ��������, ������� ����� ��������������
    public bool saveToFile; // ���� ��� ���������� �������� � ����

    private void Start()
    {
        Texture2D texture = ConvertMaterialToTexture(materialToConvert); // ������������ �������� � ��������
        if (saveToFile)
        {
            SaveTextureToFile(texture); // ��������� �������� � ����
        }
    }

    private Texture2D ConvertMaterialToTexture(Material material)
    {
        Texture2D texture = new Texture2D(1024, 1024, TextureFormat.RGB24, false); // ������� ����� ��������
        RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear); // ������� ��������� ������-�������
        Graphics.Blit(null, renderTexture, material); // ������������ �������� �� ������-��������
        RenderTexture.active = renderTexture; // ������������� ������� ������-��������
        texture.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0); // ��������� ������� �� ������-�������� � ��������
        texture.Apply(); // ��������� ���������
        RenderTexture.ReleaseTemporary(renderTexture); // ����������� ��������� ������-�������
        return texture;
    }

    private void SaveTextureToFile(Texture2D texture)
    {
        byte[] bytes = texture.EncodeToPNG(); // �������� �������� � PNG-������
        string fileName = "Sand.png"; // ��� ����� ��� ����������
        System.IO.File.WriteAllBytes(Application.dataPath + "/" + fileName, bytes); // ��������� ���� � ���������� "Assets"
    }
}