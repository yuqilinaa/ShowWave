using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShowWave
{
    class Wav
    {
        private byte[] briff = new byte[4];                 //RIFF，资源交换文件标志。
        private byte[] briffSize = new byte[4];             //从下一个字段首地址开始到文件末尾的总字节数。该字段的数值加 8 为当前文件的实际长度
        private byte[] bwaveID = new byte[4];               // 'WAVE'文件标志
        private byte[] bfmtID = new byte[4];                //'fmt'标志
        private byte[] bnotDefinition = new byte[4];        //块长度
        private byte[] bwaveType = new byte[2];             //PCM格式类别 
        private byte[] bchannel = new byte[2];              //声道数目 
        private byte[] bsample = new byte[4];               //采样率 
        private byte[] bsend = new byte[4];                 //传输速率 
        private byte[] bblockAjust = new byte[2];           //数据块对齐 
        private byte[] bbitNum = new byte[2];               //每样本bit数 
        private byte[] bunknown ;                           //可选
        private byte[] bfactID = new byte[4];               //factID
        private byte[] bfactLength = new byte[4];           //fact长度
        private byte[] bfactData;                           //fact数据
        private byte[] blistID = new byte[4];               //listID
        private byte[] blistLength = new byte[4];           //list长度
        private byte[] blistData;                           //list数据
        private byte[] bdataID = new byte[4];               //'data'标志
        private byte[] bdataLength = new byte[4];           //块长度

        private string riff;                                //RIFF，资源交换文件标志。
        private int riffSize;                              //文件总长
        private string waveID;                              // 'WAVE'文件标志
        private string fmtID;
        private int notDefinition;
        private short waveType;
        private short channel;
        private int sample;
        private int send;
        private short blockAjust;
        private short bitNum;
        private short unknown;
        private string factID;
        private int factLength;
        private string dataID;
        private int dataLength;
        private string listID;
        private int listLength;

        private int headLength;                             //文件头长
        private double soundLength;                         //声音长度
        private int sampleNum;                              //样本数量
        private int[] wavSamples;                           //单声道样本点
        private int[] wavLeftSamples;                       //立体声右声道样本点
        private int[] wavRightSamples;                      //立体声左声道样本点
        private int blockNum;
        private int maxSample;
        private int minSample;
        private bool loadFlag;
        
        
        
        public string Riff { get => riff; }
        public int RiffSize { get => riffSize; }
        public string WaveID { get => waveID; }
        public string FmtID { get => fmtID; }
        public int NotDefinition { get => notDefinition; }
        public short WaveType { get => waveType; }
        public short Channel { get => channel; }
        public int Sample { get => sample; }
        public int Send { get => send; }
        public short BlockAjust { get => blockAjust; }
        public short BitNum { get => bitNum; }
        public short Unknown { get => unknown; }
        public string FactID { get => factID; }
        public int FactLength { get => factLength; }
        public string DataID { get => dataID; }
        public int DataLength { get => dataLength; }
        public int HeadLength { get => headLength; }
        public double SoundLength { get => soundLength; }
        public int SampleNum { get => sampleNum; }
        public int[] WavSamples { get => wavSamples;  }
        public bool LoadFlag { get => loadFlag;  }
        public int[] WavLeftSamples { get => wavLeftSamples;  }
        public int[] WavRightSamples { get => wavRightSamples; }
        public int MaxSample { get => maxSample; }
        public int MinSample { get => minSample; }
        public byte[] BlistID { get => blistID; }
        public byte[] BlistLength { get => blistLength; }
        public byte[] BlistData { get => blistData; }
        public string ListID { get => listID; }
        public int ListLength { get => listLength; }
        public int BlockNum { get => blockNum; }

        public Wav(string fileName)
        {
            wavInfo(fileName);
        }

        private void wavInfo(string fileName)
        {
            loadFlag = false;
            headLength = 0;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                BinaryReader bread = new BinaryReader(fs);

                briff = bread.ReadBytes(4);
                headLength += 4;
                if (System.Text.Encoding.Default.GetString(briff) != "RIFF")
                    return;
                briffSize = bread.ReadBytes(4);
                headLength += 4;
                bwaveID = bread.ReadBytes(4);
                headLength += 4;
                bfmtID = bread.ReadBytes(4);
                headLength += 4;
                bnotDefinition = bread.ReadBytes(4);
                headLength += 4;
                notDefinition = System.BitConverter.ToInt32(bnotDefinition, 0);
                bwaveType = bread.ReadBytes(2);
                headLength += 2;
                bchannel = bread.ReadBytes(2);
                headLength += 2;
                bsample = bread.ReadBytes(4);
                headLength += 4;
                bsend = bread.ReadBytes(4);
                headLength += 4;
                bblockAjust = bread.ReadBytes(2);
                headLength += 2;
                bbitNum = bread.ReadBytes(2);
                headLength += 2;
                if (BitConverter.ToUInt32(bnotDefinition, 0) != 16)
                {
                    bunknown = new byte[this.notDefinition - 16];
                    bunknown = bread.ReadBytes(this.notDefinition-16);
                    headLength += (this.notDefinition - 16);
                }
                byte[] temp1 = bread.ReadBytes(4);
                headLength += 4;
                if (System.Text.Encoding.Default.GetString(temp1) == "data")
                {
                    bdataID = temp1;
                }
                else if (System.Text.Encoding.Default.GetString(temp1) == "fact")
                {
                    bfactID = temp1;
                    factLength = System.BitConverter.ToInt32(bread.ReadBytes(4), 0);
                    headLength += 4;
                    bfactData = bread.ReadBytes(FactLength);
                    headLength += FactLength;
                    bdataID = bread.ReadBytes(4);
                    headLength += 4;
                }
                else if (System.Text.Encoding.Default.GetString(temp1) == "LIST")
                {
                    blistID = temp1;
                    listLength= System.BitConverter.ToInt32(bread.ReadBytes(4), 0);
                    headLength += 4;
                    blistData = bread.ReadBytes(listLength);
                    headLength += listLength;
                    bdataID = bread.ReadBytes(4);
                    headLength += 4;
                }

                bdataLength = bread.ReadBytes(4);
                headLength += 4;

                riff = System.Text.Encoding.Default.GetString(briff);
                riffSize = System.BitConverter.ToInt32(briffSize, 0);
                waveID = System.Text.Encoding.Default.GetString(bwaveID);
                fmtID = System.Text.Encoding.Default.GetString(bfmtID);
                waveType = System.BitConverter.ToInt16(bwaveType, 0);
                channel = System.BitConverter.ToInt16(bchannel, 0);
                sample = System.BitConverter.ToInt32(bsample, 0);
                send = System.BitConverter.ToInt32(bsend, 0);
                blockAjust = System.BitConverter.ToInt16(bblockAjust, 0);
                bitNum = System.BitConverter.ToInt16(bbitNum, 0);
                dataID = System.Text.Encoding.Default.GetString(bdataID);
                dataLength = System.BitConverter.ToInt32(bdataLength, 0);

                soundLength = (Convert.ToDouble(dataLength) / Convert.ToDouble(bitNum / 8)) / Convert.ToDouble(sample)/channel;
                sampleNum = dataLength / (bitNum/8);
                blockNum = sampleNum / channel;
                wavSamples = new int[blockNum];
                for (int i = 0; i < blockNum; i++)
                {
                    wavSamples[i] = System.BitConverter.ToInt16(bread.ReadBytes(bitNum/8), 0);
                    bread.ReadBytes(bitNum/8*(channel-1));
                }
                loadFlag = true;
                fs.Close();
                bread.Close();
            }
            catch
            {
                return;
            }
        }
    }
}
