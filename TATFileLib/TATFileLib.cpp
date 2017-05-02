#pragma once
#include "stdafx.h"
//#include "TATFileLib.h"
#include "CTATLib.h"
#define SWAP2(x) (((x>>8) & 0x00ff) | ((x<<8) & 0xff00))
#define SWAP4(x) (((x>>24) & 0x000000ff) | ((x>>8)  & 0x0000ff00) | ((x<<8)  & 0x00ff0000) | ((x<<24) & 0xff000000))
#define LILEND2(a) (a)
#define LILEND4(a) (a)
#define BIGEND2(a) SWAP2((a))
#define BIGEND4(a) SWAP4((a))

// typedef int WORD;
// typedef unsigned int DWORD;
// typedef char BYTE;
typedef unsigned short USHORT;

const DWORD AVIF_HASINDEX = 0x00000010;
const DWORD AVIF_MUSTUSEINDEX = 0x00000020;
const DWORD AVIF_ISINTERLEAVED = 0x00000100;
const DWORD AVIF_TRUSTCKTYPE = 0x00000800;
const DWORD AVIF_WASCAPTUREFILE = 0x00010000;
const DWORD AVIF_COPYRIGHTED = 0x00020000;
char	m_rdata[1024 * 1024];
struct AVI_avih
{
	DWORD us_per_frame;
	DWORD max_bytes_per_sec;
	DWORD padding;
	DWORD flags;
	DWORD tot_frames;
	DWORD init_frames;
	DWORD streams;
	DWORD buff_sz;
	DWORD width;
	DWORD height;
	DWORD reserved[4];
};

struct rcFrame
{
	short int left;
	short int top;
	short int right;
	short int bottom;
};

struct AVI_strh
{
	BYTE type[4];
	BYTE handler[4];
	DWORD flags;
	DWORD priority;
	DWORD init_frames;
	DWORD scale;
	DWORD rate;
	DWORD start;
	DWORD length;
	DWORD buff_sz;
	DWORD quality;
	DWORD sample_sz;
	rcFrame rc;
};

struct VID_strf
{
	DWORD sz;
	DWORD width;
	DWORD height;
	DWORD planes_bit_cnt;
	BYTE  compression[4];
	DWORD image_sz;
	DWORD xpels_meter;
	DWORD ypels_meter;
	DWORD num_colors;
	DWORD imp_colors;
};

struct AUD_strf
{
	USHORT format;
	USHORT chanels;
	DWORD  sample_rate;
	DWORD  bytes_per_sec;
	USHORT block_align;
	USHORT bit_per_sample;
};

struct AVI_list_hdr
{
	BYTE id[4];
	DWORD sz;
	BYTE type[4];
};

struct AVI_list_odml
{
	AVI_list_hdr list_hdr;

	BYTE  id[4];
	DWORD sz;
	DWORD frames;
};

struct AVI_list_strl_v // Video List
{
	AVI_list_hdr list_hdr;

	BYTE     v_strh_id[4];
	DWORD    v_strh_sz;
	AVI_strh v_strh;

	BYTE     v_strf_id[4];
	DWORD    v_strf_sz;
	VID_strf v_strf;

	//	AVI_list_odml list_odml;
};

struct AVI_list_strl_a // Audio List
{
	AVI_list_hdr list_hdr;

	BYTE     a_strh_id[4];
	DWORD    a_strh_sz;
	AVI_strh a_strh;

	BYTE     a_strf_id[4];
	DWORD    a_strf_sz;
	AUD_strf a_strf;
};

struct AVI_list_hdrl
{
	AVI_list_hdr list_hdr;

	BYTE     avih_id[4]; // "avih"
	DWORD    avih_sz;    // sizeof(AVI_avih)
	AVI_avih avih;       // data
};

class CFSNormal : public VFileSystem
{
public:
	CFSNormal()
	{
		m_fp = NULL;
	}
	// 	virtual ~CFSNormal()
	// 	{
	// 	}

public:
	virtual bool fOpen(const char *filename, const char *opt)
	{
		if (m_fp)
		{
			printf("[CFSNormal] FP is Already Opened\n");
			return false;
		}

		m_fp = fopen(filename, opt);

		return m_fp ? true : false;
	}

	virtual int  fWrite(const void *buf, int size)
	{
		return fwrite(buf, 1, size, m_fp);
	}

	virtual void fClose()
	{
		if (m_fp)
		{
			fclose(m_fp);
			m_fp = NULL;
		}
	}

	virtual int fSeek(long off_set, int mode)
	{
		return fseek(m_fp, off_set, mode);
	}

	virtual bool IsOpened() { return m_fp ? true : false; }

protected:
	FILE *m_fp;
};

///////////////////////////////////////////////////////////////////////////////////


void print_quartet(unsigned int i, VFileSystem *out)
{
	out->fWrite(&i, 4);
}

void print_quartet(unsigned int i, BYTE *pBuf)
{
	memcpy(pBuf, &i, sizeof(int));
}

void WriteHeaderAVI(VFileSystem *fp, int dataFrames, int width, int height, int header_size)
{
	struct AVI_list_hdrl hdrl =
	{
		// struct AVI_list_hdr list_hdr;
		{
			{ 'L', 'I', 'S', 'T' },
			LILEND4(header_size - 4), // /2013/08/07 수정
			{ 'h', 'd', 'r', 'l' }
		},
		{ 'a', 'v', 'i', 'h' }            , // header 
		LILEND4(sizeof(AVI_avih)), // size
		{
			0, //LILEND4(per_usec),                             // time delay between frames in microseconds
			0, //int(8*1000000 * ((float)imgSize/imgFrames) / per_usec), // data rate of AVI data
			LILEND4(0),                                    // padding multiple size, typically 2048
			LILEND4(AVIF_HASINDEX | AVIF_ISINTERLEAVED),     // parameter flags
			LILEND4(dataFrames),                           // number of video frames // 0x0649(1609), 0x109D(4253)
			LILEND4(0),                                    // number of preview frames
			LILEND4(4),                                    // number of data streams (1 or 2)
			LILEND4(0),                                    // suggested playback buffer size in bytes
			LILEND4(width),                               // width  of video image in pixels
			LILEND4(height),                               // height of video image in pixels
			{
				LILEND4(0),                                // time scale, typically 30
				LILEND4(0),                                // data rate (frame rate = data rate / time scale)
				LILEND4(0),                                // starting time, typically 0
				LILEND4(0)                                 // size of AVI data chunk in time scale units
			}
		},
	};
	fp->fWrite(&hdrl, sizeof(hdrl));
}

void WriteHeaderVideo(VFileSystem *fp, int imgSize, int imgFrames, int width, int height, int fps, bool bMJpeg = false)
{
	if (!imgFrames) imgFrames = 1;

	AVI_list_strl_v   strl_vid =
	{
		// 	struct AVI_list_hdr list_hdr;
		{
			{ 'L', 'I', 'S', 'T' },                      // id
			LILEND4(sizeof(struct AVI_list_strl_v) - 8), // size
			{ 's', 't', 'r', 'l' }                       // type
		},

		// Video Info
		{ 's', 't', 'r', 'h' }            , // header : Video Stream Header
		LILEND4(sizeof(struct AVI_strh)), // size
		{
			{ 'v', 'i', 'd', 's' }, // type
			{ 'A', 'V', 'C', '1' }, // handler
			LILEND4(0),           // flag
			LILEND4(0),           // priority
			LILEND4(0),           // init_frames
			LILEND4(1000),    // scale
			LILEND4(fps * 1000),     // rate. 15142 20000
			LILEND4(0),           // start
			LILEND4(imgFrames),  // length 13
			LILEND4(imgSize / imgFrames), //LILEND4(300*1024), //imgSize/imgFrames),   0xBC5B, 0xB000        // buff_sz
			LILEND4(0),           // quality
			LILEND4(0),           // sample_sz
			{
				LILEND2(0),           // left
				LILEND2(0),           // top
				LILEND2(width),         // right
				LILEND2(height)          // bottom
			}
		},
		{ 's', 't', 'r', 'f' }   ,          // header : Video Stream Format
		sizeof(struct VID_strf),          // size
		{
			LILEND4(sizeof(struct VID_strf)), // size (Bitmap Info 구조체 크기)
			LILEND4(width),                  // w
			LILEND4(height),                  // h
											  //bwpark error fix video input bit (0 bit -> 24bit)
#if 1
											  LILEND4(1 + (24 << 16)),            // planes_bit_cnt
#else
											  LILEND4(0), //LILEND4(1 + (24<<16)),            // planes_bit_cnt
#endif
											  { 'H', '2', '6', '4' },             // comression
											  LILEND4(0), //LILEND4(width * height * 3),      // image_sz
											  LILEND4(0),                       // x / meter
											  LILEND4(0),                       // y / meter
											  LILEND4(0),                       // num_colors
											  LILEND4(0)                        // imp_colors
		},
	};

	if (bMJpeg)
	{
		memcpy(strl_vid.v_strh.handler, "MJPG", 4);
		memcpy(strl_vid.v_strf.compression, "MJPG", 4);
	}

	fp->fWrite(&strl_vid, sizeof(strl_vid));
}

void WriteHeaderAudio(VFileSystem *fp, int audSize, int audFrames, const int sample_rate)
{
	const int audio_bit_per_sample = 16;
	const int bytes_per_sec = sample_rate*audio_bit_per_sample / 8;
	const int audio_buf_sz = 2000;//1000;//audSize ? audSize/audFrames : 0;//1760;
	const int audio_length = audio_buf_sz*audFrames;
	const int audio_align = audio_bit_per_sample / 8;
	// Audio Info
	AVI_list_strl_a strl_aud =
	{
		// 	struct AVI_list_hdr list_hdr;
		{
			{ 'L', 'I', 'S', 'T' },                 // id
			LILEND4(sizeof(AVI_list_strl_a) - 8), // size
			{ 's', 't', 'r', 'l' }                  // type
		},
		// Audio
		//bwpark : audio sample error fix
#if 1		
		{ 's', 't', 'r', 'h' }            , // header : Audio Stream Header
		LILEND4(sizeof(struct AVI_strh)), // size
		{
			{ 'a', 'u', 'd', 's' }, // type
			{ 0,   0,   0,   0 }, // handler
			LILEND4(0),           // flag
			LILEND4(0),           // priority
			LILEND4(0),           // init_frames
			LILEND4(1),           // scale
			LILEND4(44100), // rate
			LILEND4(0),           // start
			LILEND4(audio_length),// length // 변경
			LILEND4(audio_buf_sz),// buff_sz
			LILEND4(0),           // quality
			LILEND4(4), // sample_sz
			{
				LILEND2(0),       // left
				LILEND2(0),       // top
				LILEND2(0),  // right
				LILEND2(0)   // bottom
			}
		},

		{ 's', 't', 'r', 'f' }   ,          // header : Audio Stream Format
		sizeof(struct AUD_strf),          // size
		{
			LILEND2(1), // 2:Format Tag  오디오 압축 코덱(0x40 : G.721, 0x64 : G.726, 0x1:pcm(?))(2bytes)
			LILEND2(2), // 2:Channels  오디오 채널 수 (2bytes)
			LILEND4(44100), // 4:Sample Rate  오디오 샘플 레이트(4bytes), 22050, 8000,
			LILEND4(176400), // 4:Average per Ser  1초동안 처리되어지는 오디오 크기(byte단위)(4bytes), 44100, 16000
			LILEND2(4), // 2:block Alignent  데이터 처리의 기본이 되는 크기(2bytes)
			LILEND2(16)  // 2:Bit Per Sample  하나를 표현하는데 필요한 비트수(2bytes)
		}
#else
	{'s', 't', 'r', 'h'}            , // header : Audio Stream Header
		LILEND4(sizeof(struct AVI_strh)), // size
		{
			{ 'a', 'u', 'd', 's' }, // type
			{ 0,   0,   0,   0 }, // handler
			LILEND4(0),           // flag
			LILEND4(0),           // priority
			LILEND4(0),           // init_frames
			LILEND4(audio_bit_per_sample / 8),           // scale
			LILEND4(bytes_per_sec), // rate
			LILEND4(0),           // start
			LILEND4(audio_length),// length // 변경
			LILEND4(audio_buf_sz),// buff_sz
			LILEND4(0),           // quality
			LILEND4(audio_align), // sample_sz
			{
				LILEND2(0),       // left
				LILEND2(0),       // top
				LILEND2(0),  // right
				LILEND2(0)   // bottom
			}
		},
		{ 's', 't', 'r', 'f' }   ,          // header : Audio Stream Format
		sizeof(struct AUD_strf),          // size
		{
			LILEND2(1), // 2:Format Tag  오디오 압축 코덱(0x40 : G.721, 0x64 : G.726, 0x1:pcm(?))(2bytes)
			LILEND2(1), // 2:Channels  오디오 채널 수 (2bytes)
			LILEND4(sample_rate), // 4:Sample Rate  오디오 샘플 레이트(4bytes), 22050, 8000,
			LILEND4(bytes_per_sec), // 4:Average per Ser  1초동안 처리되어지는 오디오 크기(byte단위)(4bytes), 44100, 16000
			LILEND2(audio_align), // 2:block Alignent  데이터 처리의 기본이 되는 크기(2bytes)
			LILEND2(audio_bit_per_sample)  // 2:Bit Per Sample  하나를 표현하는데 필요한 비트수(2bytes)
		}
#endif
	};
	fp->fWrite(&strl_aud, sizeof(strl_aud));
}

void WriteHeaderTXTS(VFileSystem *fp, int txSize, int txFrames)
{
	if (!txFrames) txFrames = 1;

	fp->fWrite("LIST", 4);
	print_quartet(76, fp);
	fp->fWrite("strl", 4);
	fp->fWrite("strh", 4);
	print_quartet(4 * 14, fp);
	fp->fWrite("txts", 4); // type
	fp->fWrite("XBLB", 4); // handler
	print_quartet(0, fp); // flag
	print_quartet(0, fp); // priority
	print_quartet(0, fp); // initframe
	print_quartet(1000, fp); // scale
	print_quartet(100 * 1000, fp); // rate
	print_quartet(0, fp); // start
	print_quartet(txFrames, fp); // length
	print_quartet(txSize / txFrames, fp); // buf size
	print_quartet(0, fp);
	print_quartet(0, fp);
	print_quartet(0, fp);
	print_quartet(0, fp);

	fp->fWrite("strf", 4);
	print_quartet(0, fp);
}

// int mjpegWriteImg(FILE *out, const char *bufTemp, int bufSize)
// {
// 	putc('0', out);
// 	putc('0', out);
// 	putc('d', out);
// 	putc('c', out);
// 	print_quartet(bufSize, out);
// 	fwrite(bufTemp, 1, bufSize, out);
// 
// 	/*
// 	long nbw = 0;
// 	fwrite(bufTemp, 6, 1, out); bufTemp += 6; bufSize-=6;
// 	bufTemp += 4; bufSize-=4;
// 	fwrite("AVI1", 4, 1, out);
// 	nbw = 10;
// 	nbw += bufSize;
// 	fwrite(bufTemp, bufSize, 1, out); bufTemp += bufSize; bufSize-=bufSize;
// 	*/
// 
// 	return 0;
// }




//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CAVIWriter::CAVIWriter(VFileSystem *pFS)
{
	if (pFS == NULL)
		m_pFS = new CFSNormal;
	else
		m_pFS = pFS;

	UseVideo2(false);
	m_bUseAudio = true;

	m_info.fps[1] = 15;
	SetDim(1, 720, 480);
	m_bMJpeg = false;
	m_nSampleRatePCM = 8000;
	m_bUseCheckSum = false;

	ichannel[0] = 0;
	ichannel[1] = 0;
}

void CAVIWriter::Reset()
{
	m_sizeData = 0;
	m_cntFrame = 0;
	m_offset = 4;

	m_header[0].m_cnt = 0;
	m_header[1].m_cnt = 0;
	m_header[2].m_cnt = 0;
	m_header[3].m_cnt = 0;
	m_header[4].m_cnt = 0;

	m_header[0].m_size = 0;
	m_header[1].m_size = 0;
	m_header[2].m_size = 0;
	m_header[3].m_size = 0;
	m_header[4].m_size = 0;
}


CAVIWriter::~CAVIWriter()
{
	if (m_pFS)
	{
		delete m_pFS;
		m_pFS = NULL;
	}
}

void CAVIWriter::SetFPS(int idx, int fps)
{
	if (idx < 0 || idx > 2)
		return;
	
	m_info.fps[idx] = fps;
}

void CAVIWriter::SetDim(int idx, int width, int height)
{
	if (idx < 0 || idx > 2)
		return;

	m_info.width[idx] = width;
	m_info.height[idx] = height;
}

bool CAVIWriter::Create(const char *filename)
{
	if (!m_pFS->fOpen(filename, "wb"))
		return false;

	header_size = sizeof(AVI_list_hdrl) + sizeof(AVI_list_strl_v) + 80;

	if (m_bUseVideo2) header_size += sizeof(AVI_list_strl_v);
	if (m_bUseAudio) header_size += sizeof(AVI_list_strl_a);

	m_checksum = 0;


	m_pFS->fWrite("RIFF", 4);
	m_pFS->fWrite("0000", 4);
	m_pFS->fWrite("AVI ", 4);

	WriteHeaderAVI(m_pFS, 0, m_info.width[0], m_info.height[0], header_size);
	WriteHeaderVideo(m_pFS, 0, 0, m_info.width[0], m_info.height[0], m_fpsFBuf = m_info.fps[0], m_bMJpeg);
	if (m_bUseVideo2) WriteHeaderVideo(m_pFS, 0, 0, m_info.width[1], m_info.height[1], m_fpsRBuf = m_info.fps[1], m_bMJpeg);
	if (m_bUseAudio) WriteHeaderAudio(m_pFS, 0, 0, m_nSampleRatePCM);
	WriteHeaderTXTS(m_pFS, 0, 0);

	m_pFS->fWrite("LIST", 4);
	m_pFS->fWrite("0000", 4);
	m_pFS->fWrite("movi", 4);

	//	arrTag.SetSize(0);
	arrTag_index = 0;

	Reset();

	//	printf("[CAVIWriter  ] Create : %d, %d\n", m_info.fps[0], m_info.fps[1]);
	return true;
}

bool CAVIWriter::AddUserHead(int size, const char *head)
{
	char buf[8];
	memcpy(buf + 0, head, 4);
	memcpy(buf + 4, &size, 4);

	if (m_pFS->fWrite(buf, 8) != 1)
		return false;
	return true;
}

bool CAVIWriter::AddDataHead(int size)
{
	char buf[8] = { '0', '0', 'd', 'c', 0, 0, 0, 0 };
	memcpy(buf + 4, &size, 4);
	if (m_pFS->fWrite(buf, 8) != 1)
		return false;
	return true;
}

bool CAVIWriter::AddDataBody(const BYTE *jpeg, int size)
{
	if (m_bUseCheckSum)
	{
		const unsigned int *pArrData = (const unsigned int *)jpeg;
		const int  s = size / 4;

		for (int i = 0; i < s; i++)
			m_checksum += pArrData[i];
	}

	int ret = m_pFS->fWrite(jpeg, size);
	if (ret != size)
	{
		printf("CAVIWriter::AddDataBody error %d != %d\n", ret, size);
		return false;
	}
	return true;
}

void CAVIWriter::AddDataTail(int size, int type, DWORD flag)
{
	//	_tagData *pTag = arrTag.AddElementBuf();
	_tagData *pTag = &arrTag[arrTag_index++];

	pTag->type = type;
	pTag->dwflag = flag;
	pTag->size = size;
	pTag->offset = m_offset;
	m_offset += size + 8;
	m_sizeData += size;
	m_cntFrame++;
}

inline int vipAlign(int size, int align) { return (size + align - 1) & -align; }

bool CAVIWriter::AddData(const BYTE *data, int size,mType type)
{
	DWORD flag = 0;
	// 	printf("%p, size = %d, type = %d m_pFS = %p\n", data, size, type, m_pFS);
	if (!m_pFS->IsOpened())
	{
		printf("[CAVIWriter] AddData : File is already closed\n");
		return false;
	}
	AddUserHead(size, m_header[type].header);

	if (data[4] == 0x67 && (type == 0 || type == 1))
	{
		if (ichannel[type] % 2 == 0)
		{
			flag = AVIIF_KEYFRAME;
		}
		ichannel[type] ++;
	}

	size = vipAlign(size, 2);

	m_header[type].m_size += size; //kks-2ch
	m_header[type].m_cnt++;

	//	printf("[%d] %s, %d\n", type, m_header[type].header, size);


	if (!AddDataBody(data, size)) return false;
	AddDataTail(size, type, flag);
	return true;
}


class CMFile : public VFileSystem
{
public:
	CMFile(BYTE *pBuf, int size)
	{
		m_pBuf = pBuf;
		m_size = 0;
		m_max = size;
	}

public:
	virtual bool fOpen(const char *filename, const char *opt) { return false; };
	virtual void fClose() {}
	virtual int  fSeek(long off_set, int mode) { return 0; }
	virtual bool IsOpened() { return false; }


	virtual int  fWrite(const void *buf, int size)
	{
		if (m_max < m_size + size)
			return 0;

		memcpy(m_pBuf + m_size, buf, size);
		m_size += size;
		return size;
	}

public:

	BYTE *m_pBuf;
	int   m_size;
	int   m_max;
};

int CAVIWriter::Close(const void *extBuf, int extSize)
{
	if (!m_pFS->IsOpened())
		return 0;

	_WriteTail(m_pFS);

	if (m_bUseCheckSum)
	{
		m_pFS->fWrite("chk1", 4);
		print_quartet(4, m_pFS); // 4
		m_pFS->fWrite(&m_checksum, sizeof(int));
	}

	// rewind 
	m_pFS->fSeek(0, SEEK_SET);

	int riff_sz = _WriteHeader(m_pFS);

	if (extSize)
	{
		printf("ext write\n");
		m_pFS->fSeek(0, SEEK_END);
		m_pFS->fWrite(extBuf, extSize);
	}

	CloseForced();

	return riff_sz;
}

void CAVIWriter::CloseForced()
{
	m_pFS->fClose();
}

int CAVIWriter::_WriteHeader(VFileSystem *pFS)
{
	unsigned int riff_sz =
		header_size +
		8 +
		8 +
		m_sizeData +  // avi body   size
		8 * m_cntFrame +  // avi header size
		4 +
		4 +
		16 * m_cntFrame; // index body

	pFS->fWrite("RIFF", 4);
	print_quartet(riff_sz, pFS);
	pFS->fWrite("AVI ", 4);

	WriteHeaderAVI(pFS, m_cntFrame, m_info.width[0], m_info.height[0], header_size);
	WriteHeaderVideo(pFS, m_header[0].m_size, m_header[0].m_cnt, m_info.width[0], m_info.height[0], m_fpsFBuf, m_bMJpeg);

	if (m_bUseVideo2)
		WriteHeaderVideo(pFS, m_header[1].m_size, m_header[1].m_cnt, m_info.width[1], m_info.height[1], m_fpsRBuf, m_bMJpeg);
	if (m_bUseAudio)
	{
		if (m_bUseVideo2)
			WriteHeaderAudio(pFS, m_header[2].m_size, m_header[2].m_cnt, m_nSampleRatePCM);
		else
			WriteHeaderAudio(pFS, m_header[1].m_size, m_header[1].m_cnt, m_nSampleRatePCM);
	}

	if (m_bUseVideo2)
		WriteHeaderTXTS(pFS, m_header[3].m_size, m_header[3].m_cnt);
	else
		WriteHeaderTXTS(pFS, m_header[2].m_size, m_header[2].m_cnt);

	pFS->fWrite("LIST", 4);
	print_quartet((m_sizeData + 8 * m_cntFrame) + 4, pFS);
	pFS->fWrite("movi", 4);

	return riff_sz;
}

void CAVIWriter::_WriteTail(VFileSystem *pFS)
{
	pFS->fWrite("idx1", 4);
	//	print_quartet(16 * arrTag.GetSize(), pFS); // 4
	print_quartet(16 * arrTag_index, pFS); // 4

										   //	for (int i = 0 ; i < arrTag.GetSize() ; i++)
	for (int i = 0; i < arrTag_index; i++)
	{
		if (arrTag[i].type < 0 || 4 < arrTag[i].type)
			printf("Critical Error !!!!!!!!!!!!!!!!!!!!!!!!!!!!\n");
		else
		{
			pFS->fWrite(m_header[arrTag[i].type].header, 4);
			print_quartet(arrTag[i].dwflag, pFS); // print_quartet(18); // 4
			print_quartet(arrTag[i].offset, pFS); // 4
			print_quartet(arrTag[i].size, pFS); // 4  = 16 * m_cntFrame
		}
	}
}

void CAVIWriter::UseVideo2(bool bTrue)
{
	if ((m_bUseVideo2 = bTrue))
	{
		strcpy(m_header[0].header, "00dc");
		strcpy(m_header[1].header, "01dc");
		strcpy(m_header[2].header, "02wb");
		strcpy(m_header[3].header, "03tx");
		m_info.cntMedia = 2;
	}
	else
	{
		strcpy(m_header[0].header, "00dc");
		strcpy(m_header[1].header, "00dc");
		strcpy(m_header[2].header, "01wb");
		strcpy(m_header[3].header, "02tx");
		m_info.cntMedia = 1;
	}
}
typedef char CHAR;
typedef CHAR *PCHAR, *LPCH, *PCH;
typedef _Null_terminated_ CHAR *NPSTR, *LPSTR, *PSTR;
#define CONST               const
typedef _Null_terminated_ CONST CHAR *LPCSTR, *PCSTR;
typedef LPCSTR PCTSTR, LPCTSTR, PCUTSTR, LPCUTSTR;
CAVIWriter m_writer[3];


bool CAVIWriter::aviCreate(char ch, const char *filename)
{
	return m_writer[ch].Create(filename);
}

void CAVIWriter::aviClose(char ch)
{
	m_writer[ch].Close(NULL, 0);
}

void CAVIWriter::aviSetDim(char ch, int idx, int width, int height)
{
	m_writer[ch].SetDim(idx, width, height);
}

void CAVIWriter::aviSetFPS(char ch, int idx, int fps)
{
	m_writer[ch].SetFPS(idx, fps);
}

void CAVIWriter::aviSetAudioSampleRate(char ch, int rate)
{
	m_writer[ch].SetAudioSampleRate(rate);
}

void CAVIWriter::aviUseVideo2(char ch, bool bTrue)
{
	m_writer[ch].UseVideo2(bTrue);
}

bool CAVIWriter::aviAddData(char ch, const BYTE *data, int size, int type)
{
	return m_writer[ch].AddData(data, size, mType(type));
}




void CAVIWriter::vDownLoadFile(char* sFileName)
{
	if (sFileName)
	{
		char* f_name = (LPSTR)(LPCTSTR)sFileName;

		FILE_INFO f_info;
		char	VSet[3], ii = 0, V2Ch = 0;
		UNS32 rtn;
		UNS8 ch = 0, f_type, p_type;
		UNS32 size, timestamp, pb_pos = 0;
		char name[3][100];
		char t_name[100];
		char mode;
		int  gps_tt = 0, frame_index = 0;;

		if (f_name[MODE_POSITION] == CHAR_EVENT) 		mode = 0;
		else if (f_name[MODE_POSITION] == CHAR_NORMAL)	mode = 1;
		else if (f_name[MODE_POSITION] == CHAR_PARKE)	mode = 2;
		else if (f_name[MODE_POSITION] == CHAR_PICTURE)	mode = 3;
		else if (f_name[MODE_POSITION] == CHAR_MANUAL)	mode = 4;
		else
		{
			return;
		}
		
		m_tat->GetFileIndexInfo(mode, f_name, &f_info);
		
		m_tat->PBInit();
		pb_pos = m_tat->GetPBPos(mode, f_name);
		m_tat->PBStart(mode, 0, pb_pos);


		memset(t_name, 0, sizeof(t_name));
		memcpy(t_name, f_name, strlen(f_name));
		sprintf_s(name[0], "%s%s_1.avi", "C:\\BlackBox\\", t_name);
		sprintf_s(name[1], "%s%s_2.avi", "C:\\BlackBox\\", t_name);
		sprintf_s(name[2], "%s%s_3.avi", "C:\\BlackBox\\", t_name);

		VSet[0] = 0;
		VSet[1] = 0;
		VSet[2] = 0;

		while (1)
		{
			rtn = m_tat->ReadFrame(&ch, &f_type, &p_type, &size, m_rdata, &timestamp);

			if ((rtn == FREAD_START) || (rtn == FREAD_EOF) || (rtn == FREAD_ERROR))
			{
				break;
			}
			//			if(!ch)  _cprintf("frame index = %d \n", frame_index);
			if (!VSet[ch])
			{
				if ((m_rdata[0] == 0) && (m_rdata[1] == 0) && (m_rdata[2] == 0) && (m_rdata[3] == 1) && (p_type == I_FRAME) && (f_type == F_VIDEO))
				{
					//CAVIWriter temp = new CAVIWriter();
					aviSetDim(ch, 0, f_info.width[ch], f_info.height[ch]); // 전방 해상도 HD 설정  
					
					VSet[ch] = 1;
					aviSetAudioSampleRate(ch, AUDIO_SAMPLEING); // Audio Sample Rate 16Khz
					aviSetFPS(ch, 0, f_info.fps[ch]);
					aviUseVideo2(ch, false);
					aviCreate(ch, name[ch]);
				}
			}

			if (VSet[ch] || (ch == CH_GSEN) || (ch == CH_GPS))
			{
				switch (f_type)
				{
				case F_VIDEO:
				{
					if (VSet[ch])
					{
						if (!ch)
							aviAddData(0, (BYTE*)m_rdata, size, aviMedia0); // 전방 H264 add  
						else if (ch == 1)
							aviAddData(1, (BYTE*)m_rdata, size, aviMedia0); // 전방 H264 add   
						else if (ch == 2)
							aviAddData(2, (BYTE*)m_rdata, size, aviMedia0); // 전방 H264 add    
					}
				}
				break;
				case F_AUDIO:
					if (VSet[0])aviAddData(0, (BYTE*)m_rdata, size, aviPCM);
					if (VSet[1])aviAddData(1, (BYTE*)m_rdata, size, aviPCM);
					if (VSet[2])aviAddData(2, (BYTE*)m_rdata, size, aviPCM);

					break;
				case F_GSEN:
				case F_GPS:
					break;
				}
			}
		}

		if (VSet[0])
			aviClose(0);
		if (VSet[1])
			aviClose(1);
		if (VSet[2])
			aviClose(2);

		//		_cprintf("aviClose\n");  
		return;

		//		m_tat->MakeAviFile(file);   

	}
}