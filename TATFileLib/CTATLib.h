#pragma once

#include "afxmt.h"
//#include "TATLib.h"
#include "TATFileLib.h"
typedef HANDLE(__stdcall *TAT_CREATE)			();
typedef void(__stdcall *TAT_DELETE)			(HANDLE h);

typedef HANDLE(__stdcall *TAT_OPEN)				(HANDLE h, char device);
typedef void(__stdcall *TAT_CLOSE)			(HANDLE h, HANDLE fp);

typedef UNS32(__stdcall *TAT_READ)				(HANDLE h, HANDLE fp, UNS64 pos, char *data, UNS32 size);
typedef UNS32(__stdcall *TAT_WRITE)			(HANDLE h, HANDLE fp, UNS64 pos, UNS32 byte, char *data, UNS32 size);
typedef BOOL(__stdcall *TAT_FORMAT)			(HANDLE h);

typedef BOOL(__stdcall *TAT_CHECK_TAT_DEVICE)	(HANDLE h, char *D_id);
typedef BOOL(__stdcall *TAT_CHECK_VERSION)	(HANDLE h, TATVERSION_INFO *t_version);

typedef BOOL(__stdcall *TAT_GET_FILE_FRAME_CNT)	(HANDLE h, UNS8 mode, char *fname, UNS8 *front, UNS8 *rear); //
typedef BOOL(__stdcall *TAT_GET_FILE_INDEX_INFO)	(HANDLE h, UNS8 mode, char *fname, FILE_INFO *f_info); //
typedef int(__stdcall *TAT_GET_FILE_CNT)		(HANDLE h, char mode);
typedef int(__stdcall *TAT_GET_FILE_LIST)	(HANDLE h, char mode, int list_cnt, char *fname, UNS32 * findex, UNS32 *fsize);
typedef int(__stdcall *TAT_GET_FILE_LIST_TT)	(HANDLE h, char mode, int list_cnt, char *fname, UNS32 * findex, UNS32 *fsize, UNS32 *ftime);
typedef BOOL(__stdcall *TAT_GET_FILE_FLAG)	(HANDLE h, char *Eevent, char *Nnormal, char* Pparking, char* Rreserv);
typedef UNS8(__stdcall *TAT_FIND_START_STOP)	(HANDLE h, HANDLE fp, char mode, UNS32 *start, UNS32 *stop, UNS32 *last_pos);

typedef UNS32(__stdcall *TAT_GET_PB_POS)		(HANDLE h, UNS8 mode, char *file);
typedef BOOL(__stdcall *TAT_SET_SEEK_POS)		(HANDLE h, UNS8 seek, UNS8	total);
typedef void(__stdcall *TAT_PB_INIT)			(HANDLE h);
typedef void(__stdcall *TAT_PB_DEINIT)		(HANDLE h);
typedef void(__stdcall *TAT_PB_START)			(HANDLE h, UNS8 mode, UNS8 ch, UNS32 pb_pos);
typedef void(__stdcall *TAT_PB_STOP)			(HANDLE h);
typedef void(__stdcall *TAT_FAT_PB_START)		(HANDLE h, char* file, UNS32 *frame_cnt);
typedef void(__stdcall *TAT_FAT_PB_STOP)		(HANDLE h);

typedef UNS32(__stdcall *TAT_READ_FRAME)		(HANDLE h, UNS8 *ch, UNS8 *ftype, UNS8 *ptype, UNS32 *size, char *data, UNS32 *timestamp);
typedef UNS32(__stdcall *TAT_MAKE_AVI_FILE)	(HANDLE h, char *fname);
typedef UNS32(__stdcall *TAT_MAKE_PLAY_FILE)	(HANDLE h, char *fname, char * Gsensor, char *Gps);
typedef UNS32(__stdcall *TAT_MAKE_TAT_FILE)	(HANDLE h, char *fname);
typedef UNS32(__stdcall *TAT_MAKE_DATA_FILE)	(HANDLE h, char *fname, UNS32 *frame_cnt, char *m_gps, char tat, UNS8 *fps, UNS32 *width, UNS32 *heigth, char *bGsen, char *obd);
typedef BOOL(__stdcall *TAT_SET_PCFOLDER)		(HANDLE h, char *folder);

typedef BOOL(__stdcall *TAT_SET_CONFIG_DATA) 	(HANDLE h, char *data, UNS32 *size);
typedef BOOL(__stdcall *TAT_GET_CONFIG_DATA)	(HANDLE h, char *data, UNS32 *size);
typedef BOOL(__stdcall *TAT_GET_DEVICE_NAME)	(HANDLE h, char *dname);
typedef void(__stdcall *TAT_SET_DEVICE)		(HANDLE h, char *device);
typedef BOOL(__stdcall *TAT_MAKE_PICTURE_FILE)	(HANDLE h, char *fname, UNS32 *picture_size, char *picture_data);

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
};

