#pragma once
#include <stdio.h>
#include <string.h>
//#include <CTATLib.h>

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

typedef unsigned long       DWORD;
typedef unsigned char       BYTE;

#define S8			signed char
#define S16			signed short
#define S32			signed int
#define S64			signed long long

#define UNS8		unsigned char
#define UNS16		unsigned short
#define UNS32		unsigned int
#define UNS64		unsigned long long
#define MAX_FILENAME  			40
#define MAX_CH					2   
#define SECTOR  				512    
#define MAX_GPS_SIZE			128
#define MAX_GSEN_SIZE			15

#define MAX_SUPPORT_CH			16 
#define MODE_POSITION			16
#define CHANNEL_POSITION		17
#define MAX_USE_MODE			4
#define MAX_USR_SIZE			1024*512
#define AUDIO_SAMPLEING			8000

#define BAR_1					8
#define BAR_2					15
#define CHAR_BAR_1				'_'
#define CHAR_BAR_2				'_'

#define CHAR_EVENT				'E'
#define CHAR_NORMAL				'I'
#define CHAR_PARKE				'P'
#define CHAR_MOTION				'M'
#define CHAR_MANUAL				'C'
#define CHAR_PICTURE			'J'
enum
{
	aviMedia0 = 0,
	aviMedia1 = 1,
	aviPCM = 2,
};


typedef enum { 		// 비디오 패킷일 경우 IBP,  AVI heaer일 경우 START MIDDLE END  사용	
	U_FRAME,
	I_FRAME,
	P_FRAME,
	B_FRAME,
	C_FRAME,
}V_TYPE;

typedef enum {			// 패킷 단위  데이타를 구분하기 위하여
	F_USER,
	F_AUDIO,
	F_VIDEO,
	F_GSEN,
	F_GPS,
	F_RESERV,
}F_TYPE;

typedef enum {  // 비디오 및 각각의 센서를 채널로 분리함
	CH_FRONT,
	CH_REAR,
	CH_GPS,
	CH_GSEN,
	CH_OBD,
	CH_RESEV
}BB_CHANNEL;

enum mType
{
	dataMedia0 = 0,
	dataMedia1 = 1,
	dataPCM = 2,
	dataTX = 3
};

typedef enum { 		// 비디오 패킷일 경우 IBP,  AVI heaer일 경우 START MIDDLE END  사용		
	FREAD_OK,
	FREAD_START,
	FREAD_EOF,
	FREAD_ERROR,
	FREAD_OUT,
}DEC_TYPE;


typedef struct {
	char	pc_date[12];
	char 	pc_version[10];
	char	sd_date[12];
	char 	sd_version[10];
}TATVERSION_INFO;

typedef struct
{
	DWORD ckid;
	DWORD dwFlags;
	DWORD dwChunkOffset;
	DWORD dwChunkLength;
} AVIINDEXENTRY;

#define AVIIF_LIST 0x00000001 
#define AVIIF_KEYFRAME 0x00000010 
#define AVIIF_FIRSTPART 0x00000020 
#define AVIIF_LASTPART 0x00000040 
#define AVIIF_NOTIME 0x00000100
typedef void* HANDLE;
typedef int BOOL;

class CTATLib
{
public:
	CTATLib();
	~CTATLib();

	
	BOOL	Create(LPCSTR dll_dir);
	void	Delete();

	HANDLE	Open(char device);
	void	Close(HANDLE fp);

	UNS32	Read(HANDLE fp, UNS64 pos, char *data, UNS32 size);
	UNS32	Write(HANDLE fp, UNS64 pos, UNS32 byte, char *data, UNS32 size);
	BOOL	Tat_Format();
	BOOL	CheckTATDevice(char *D_id);
	BOOL	CheckTATVersion(TATVERSION_INFO *t_version);

	BOOL	GetFileFrameCnt(UNS8 mode, char *fname, UNS8 *front, UNS8 *rear);//
	BOOL	GetFileIndexInfo(UNS8 mode, char *fname, FILE_INFO *f_info);//
	int		GetFileCnt(char mode);
	int		GetFileList(char mode, int list_cnt, char *fname, UNS32 * findex, UNS32 *fsize);
	int		GetFileList_tt(char mode, int list_cnt, char *fname, UNS32 * findex, UNS32 *fsize, UNS32 *ftime);
	int		GetFileFlag(char *Eevent, char*Nnormal, char *Pparking, char *Rreserv);
	UNS8	FindStartStop(HANDLE fp, char mode, UNS32 *start, UNS32 *stop, UNS32 *last_pos);

	UNS32	GetPBPos(UNS8 mode, char *file);
	UNS32	SetSeekPos(UNS8 seek, UNS8 total);
	BOOL	SetPcfolder(char *folder);

	void	PBInit();
	void	PBDeInit();
	void	PBStart(UNS8 mode, UNS8 ch, UNS32 pb_pos);
	void	PBStop();
	void	FatPBStart(char *file, UNS32 *frame_cnt);
	void	FatPBStop();

	BOOL	MakePictureFile(char *fname, UNS32 *picture_size, char *picture_data);
	UNS32	ReadFrame(UNS8 *ch, UNS8 *ftype, UNS8 *ptype, UNS32 *size, char *data, UNS32 *timestamp);
	UNS32	MakeAviFile(char *fname);
	UNS32	MakePlayFile(char *fname, char * Gsensor, char *Gps);
	UNS32	MakeTatFile(char *fname);
	UNS32	MakeDataFile(char *fname, UNS32 *frame_cnt, char *m_gps, char tat, UNS8 *fps, UNS32 *width, UNS32 *height, char *bGsen, char *obd);
	UNS32	Get_Tail_Data(UNS8 mode, UNS8 ch, char *fName, char *dtail, UNS32 *t_size);

	BOOL	SetConfigData(char *data, UNS32 *size);
	BOOL	GetConfigData(char *data, UNS32 *size);

	BOOL	GetDeviceName(char *dname);
	void	CheckTATDeviceID(char* device);



protected:
	void	Init();
	/*
protected:
	static	const CString			s_strDLL;

	HANDLE							m_dwHandle;
	HMODULE							s_hLibrary;
	TAT_CREATE						s_fnCreate;
	TAT_DELETE						s_fnDelete;
	TAT_OPEN						s_fnOpen;
	TAT_CLOSE						s_fnClose;
	TAT_READ						s_fnRead;
	TAT_WRITE						s_fnWrite;
	TAT_FORMAT						s_fnFormat;
	TAT_CHECK_TAT_DEVICE			s_fnCheckTATDevice;
	TAT_CHECK_VERSION				s_fnCheckVersion;

	TAT_GET_FILE_FRAME_CNT			s_fnGetFileFrameCnt; //
	TAT_GET_FILE_INDEX_INFO			s_fnGetFileIndexInfo; //
	TAT_GET_FILE_CNT				s_fnGetFileCnt;
	TAT_GET_FILE_LIST				s_fnGetFileList;
	TAT_GET_FILE_LIST_TT			s_fnGetFileList_tt;
	TAT_GET_FILE_FLAG				s_fnGetFileFlag;
	TAT_FIND_START_STOP				s_fnFindStartStop;

	TAT_GET_PB_POS					s_fnGetPBPos;
	TAT_SET_SEEK_POS				s_fnSetSeekPos;
	TAT_PB_INIT						s_fnPBInit;
	TAT_PB_DEINIT					s_fnPBDeInit;
	TAT_PB_START					s_fnPBStart;
	TAT_PB_STOP						s_fnPBStop;
	TAT_FAT_PB_START				s_fnFatPBStart;
	TAT_FAT_PB_STOP					s_fnFatPBStop;

	TAT_READ_FRAME					s_fnReadFrame;
	TAT_MAKE_AVI_FILE				s_fnMakeAviFile;
	TAT_MAKE_PLAY_FILE				s_fnMakePlayFile;
	TAT_MAKE_TAT_FILE				s_fnMakeTatFile;
	TAT_MAKE_DATA_FILE				s_fnMakeDataFile;
	TAT_SET_PCFOLDER				s_fnSetPcfolder;
	TAT_SET_CONFIG_DATA				s_fnSetConfigData;
	TAT_GET_CONFIG_DATA				s_fnGetConfigData;
	TAT_GET_DEVICE_NAME				s_fnGetDeviceName;
	TAT_SET_DEVICE					s_fnSetDevice;
	TAT_MAKE_PICTURE_FILE			s_fnMakePictureFile;
	*/
};

class VFileSystem
{
public:
	virtual bool fOpen(const char *filename, const char *opt) = 0;
	virtual int  fWrite(const void *buf, int size) = 0;
	virtual void fClose() = 0;
	virtual int  fSeek(long off_set, int mode) = 0;
	virtual bool IsOpened() = 0;
};

class CAVIWriter
{
public:
	CAVIWriter(VFileSystem *pFS = NULL);
	virtual ~CAVIWriter();

public:
	CTATLib *m_tat;
	bool Create(const char *filename);
	int  Close(const void *extBuf = NULL, int extSize = 0);
	void CloseForced();

	int  fWrite(const void *buf, int size) { return m_pFS->fWrite(buf, size); }
	int  fSeek(long off_set, int mode) { return m_pFS->fSeek(off_set, mode); }

	bool AddData(char *data, int size, int type);

	void UseVideo2(bool bTrue);
	bool aviCreate(char ch, const char * filename);
	void aviClose(char ch);
	void aviSetDim(char ch, int idx, int width, int height);
	void aviSetFPS(char ch, int idx, int fps);
	void aviSetAudioSampleRate(char ch, int rate);
	void aviUseVideo2(char ch, bool bTrue);
	bool aviAddData(char ch, const BYTE * data, int size, int type);
	void vDownLoadFile(char* sFileName);
	void UseAudio(bool bTrue) { m_bUseAudio = bTrue; }
	void UseMJpeg(bool bTrue) { m_bMJpeg = bTrue; }
	void UseChecksum(bool bTrue) { m_bUseCheckSum = bTrue; }

	void SetDim(int idx, int width, int height);
	void SetFPS(int idx, int fps);
	void SetAudioSampleRate(int rate) { m_nSampleRatePCM = rate; }

	const char *GetHeader(mType type) { return m_header[type].header; }

protected:
	void Reset();


protected:
	bool AddUserHead(int size, const char *head);
	bool AddDataHead(int size);
	bool AddDataBody(const BYTE * jpeg, int size);
	bool AddDataBody(char *jpeg, int size);
	void AddDataTail(int size, int type, DWORD flag);

	bool AddData(const BYTE * data, int size, mType type);

protected:

	void _WriteTail(VFileSystem *pFS);
	int  _WriteHeader(VFileSystem *pFS);


protected:
	struct _tagData
	{
		int type;
		DWORD dwflag;
		int offset;
		int size;
	}arrTag[10000];

	//CVipArrBase <_tagData> arrTag; // 요거 다른 CArray이 Vector로 대치하세요...
	//	<_tagData> arrTag[10000]; // 요거 다른 CArray이 Vector로 대치하세요...

	int m_sizeData;
	int m_offset;
	int m_cntFrame;

	struct _tagHeader
	{
		char header[8];
		int  m_size;
		int  m_cnt;
	} m_header[5];

	bool m_bUseAudio;
	bool m_bUseVideo2;
	int  arrTag_index;
	int header_size;

	int ichannel[2];

protected:
	struct _avi_info
	{
		int width[3];
		int height[3];
		int fps[3];
		int cntMedia;
	} m_info;

	int m_fpsFBuf;
	int m_fpsRBuf;
	bool m_bMJpeg;
	int m_nSampleRatePCM;

	unsigned int m_checksum;
	bool         m_bUseCheckSum;

	VFileSystem *m_pFS;
};

typedef struct {
	char  	name[MAX_FILENAME];
	UNS32	pos;
	UNS32	fcode;
	UNS8	video;
	UNS8	audio;
	UNS8	header_size;
	UNS8	etc1;
	UNS8	fps[MAX_SUPPORT_CH];
	UNS16	frame[MAX_SUPPORT_CH];				//한파일의 비디오 프래임의 합. 
	UNS32	size[MAX_SUPPORT_CH];				//한파일의 비디오+ audio size 합. audio 는 Ch0에만 함산됨. 
	UNS16	height[MAX_SUPPORT_CH];				//녹화 해상도 1280*702   1280 	
	UNS16	width[MAX_SUPPORT_CH];
	UNS32	start_tt;					// 녹화 시작 시간 
	UNS32	stop_tt;					// 녹화 종료 시간 
	UNS32	gsen_pos;
	UNS32	gsen_size;
	char	gps;		//해당 파일의  시작 GPS점 및 종료 GPS 데이타 
	UNS32	user_pos;					//Tail Data pos  for ESV	
	UNS32	user_size;					//Tail Data size for ESV	
	UNS32	audio_sample;
	UNS8	audio_bit;
	UNS8	audio_ch;
	UNS8	obd;
	UNS8	reserv;
	char 	header[120];
	UNS32	findex;
}FILE_INFO;