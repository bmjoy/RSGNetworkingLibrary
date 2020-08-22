using System.IO;

[System.Serializable]
public class ReceiveState
{
    public byte[] Buffer = new byte[4096]; //buffer for network i/o
    public int DataSize = 0; //data size to be received by the server
    public bool DataSizeReceived = false; //whether prefix was received
    public MemoryStream Data = new MemoryStream(); //place where data is stored
}