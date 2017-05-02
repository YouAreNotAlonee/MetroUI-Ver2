#include "StdAfx.h"
//#include "CLoadModule.h"
#include "CTATLib.h"

const CString			CTATLib::s_strDLL = "TATLib.dll";

CTATLib::CTATLib()
{
	s_hLibrary = NULL;
	m_dwHandle = 0;
	Init();
}

CTATLib::~CTATLib()
{
	Delete();
}



#define LoadLibrary  LoadLibraryA


void CTATLib::Delete()
{
	if (s_hLibrary && m_dwHandle && s_fnDelete)
	{
		s_fnDelete(m_dwHandle);
		if (m_dwHandle)
			m_dwHandle = 0;
	}
	if (s_hLibrary)
		Init();
}
#if 1
HANDLE CTATLib::Open(char device)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnOpen)
		return 0;
	return s_fnOpen(m_dwHandle, device);
}

void CTATLib::Close(HANDLE fp)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnClose)
		return;
	s_fnClose(m_dwHandle, fp);
}

UNS32 CTATLib::Read(HANDLE fp, UNS64 pos, char *data, UNS32 size)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnRead)
		return 0;
	return s_fnRead(m_dwHandle, fp, pos, data, size);
}

UNS32 CTATLib::Write(HANDLE fp, UNS64 pos, UNS32 byte, char *data, UNS32 size)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnWrite)
		return 0;
	return s_fnWrite(m_dwHandle, fp, pos, byte, data, size);
}


BOOL CTATLib::Tat_Format()
{
	if (!s_hLibrary || !m_dwHandle || !s_fnFormat)
		return FALSE;
	return s_fnFormat(m_dwHandle);
	return 0;
}


BOOL CTATLib::CheckTATDevice(char *D_id)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnCheckTATDevice)
		return FALSE;
	return s_fnCheckTATDevice(m_dwHandle, D_id);
}


BOOL CTATLib::CheckTATVersion(TATVERSION_INFO *t_version)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnCheckVersion)
		return FALSE;
	return s_fnCheckVersion(m_dwHandle, t_version);
}


BOOL CTATLib::GetDeviceName(char *dname)// 	
{
	if (!s_hLibrary || !m_dwHandle || !s_fnGetDeviceName)
		return 0;
	return s_fnGetDeviceName(m_dwHandle, dname);
}


void CTATLib::CheckTATDeviceID(char* device)// 	
{
	if (!s_hLibrary || !m_dwHandle || !s_fnSetDevice)
		return;
	return s_fnSetDevice(m_dwHandle, device);
}

BOOL CTATLib::GetFileFrameCnt(UNS8 mode, char *fname, UNS8 *front, UNS8 *rear)// 	
{
	if (!s_hLibrary || !m_dwHandle || !s_fnGetFileFrameCnt)
		return 0;
	return s_fnGetFileFrameCnt(m_dwHandle, mode, fname, front, rear);
}


BOOL CTATLib::GetFileIndexInfo(UNS8 mode, char *fname, FILE_INFO *f_info)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnGetFileIndexInfo)
		return 0;
	return s_fnGetFileIndexInfo(m_dwHandle, mode, fname, f_info);
}



#endif

int CTATLib::GetFileCnt(char mode)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnGetFileCnt)
		return 0;
	return s_fnGetFileCnt(m_dwHandle, mode);
}

int CTATLib::GetFileList(char mode, int list_cnt, char *fname, UNS32 * findex, UNS32 *fsize)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnGetFileList)
		return 0;
	return s_fnGetFileList(m_dwHandle, mode, list_cnt, fname, findex, fsize);
}


int CTATLib::GetFileList_tt(char mode, int list_cnt, char *fname, UNS32 * findex, UNS32 *fsize, UNS32 *ftime)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnGetFileList_tt)
		return 0;
	return s_fnGetFileList_tt(m_dwHandle, mode, list_cnt, fname, findex, fsize, ftime);
}


BOOL CTATLib::GetFileFlag(char *Eevent, char*Nnormal, char *Pparking, char* Rreserv)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnGetFileFlag)
		return 0;
	return s_fnGetFileFlag(m_dwHandle, Eevent, Nnormal, Pparking, Rreserv);
}


UNS8 CTATLib::FindStartStop(HANDLE fp, char mode, UNS32 *start, UNS32 *stop, UNS32 *last_pos)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnFindStartStop)
		return 0;
	return s_fnFindStartStop(m_dwHandle, fp, mode, start, stop, last_pos);
}


UNS32 CTATLib::SetSeekPos(UNS8 seek, UNS8 total)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnSetSeekPos)
		return 0;
	return s_fnSetSeekPos(m_dwHandle, seek, total);
}



BOOL CTATLib::SetPcfolder(char *folder)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnSetPcfolder)
		return 0;
	return s_fnSetPcfolder(m_dwHandle, folder);
}

UNS32 CTATLib::GetPBPos(UNS8 mode, char *file)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnGetPBPos)
		return 0;
	return s_fnGetPBPos(m_dwHandle, mode, file);
}

void CTATLib::PBInit()
{
	if (!s_hLibrary || !m_dwHandle || !s_fnPBInit)
		return;
	s_fnPBInit(m_dwHandle);
}

void CTATLib::PBDeInit()
{
	if (!s_hLibrary || !m_dwHandle || !s_fnPBDeInit)
		return;
	s_fnPBDeInit(m_dwHandle);
}



void CTATLib::FatPBStart(char *file, UNS32 *frame_cnt)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnFatPBStart)
		return;
	s_fnFatPBStart(m_dwHandle, file, frame_cnt);
}


void CTATLib::FatPBStop()
{
	if (!s_hLibrary || !m_dwHandle || !s_fnFatPBStop)
		return;
	s_fnFatPBStop(m_dwHandle);
}


void CTATLib::PBStart(UNS8 mode, UNS8 ch, UNS32 pb_pos)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnPBStart)
		return;
	s_fnPBStart(m_dwHandle, mode, ch, pb_pos);
}


void CTATLib::PBStop()
{
	if (!s_hLibrary || !m_dwHandle || !s_fnPBStop)
		return;
	s_fnPBStop(m_dwHandle);
}

BOOL CTATLib::MakePictureFile(char *fname, UNS32 *picture_size, char *picture_data)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnMakePictureFile)
		return 0;
	return s_fnMakePictureFile(m_dwHandle, fname, picture_size, picture_data); // sole@20140904 // sole@20140727
}

UNS32 CTATLib::ReadFrame(UNS8 *ch, UNS8 *ftype, UNS8 *ptype, UNS32 *size, char *data, UNS32 *timestamp)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnReadFrame)
		return 0;
	return s_fnReadFrame(m_dwHandle, ch, ftype, ptype, size, data, timestamp);
}


UNS32 CTATLib::MakeDataFile(char *fname, UNS32 *frame_cnt, char *m_gps, char tat, UNS8 *fps, UNS32 *width, UNS32 *height, char *bGsen, char *obd) // sole@20140904 // sole@20140727
{
	if (!s_hLibrary || !m_dwHandle || !s_fnMakeDataFile)
		return 0;
	return s_fnMakeDataFile(m_dwHandle, fname, frame_cnt, m_gps, tat, fps, width, height, bGsen, obd); // sole@20140904 // sole@20140727
}


UNS32 CTATLib::MakeAviFile(char *fname)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnMakeAviFile)
		return 0;
	return s_fnMakeAviFile(m_dwHandle, fname);
}

UNS32 CTATLib::MakePlayFile(char *fname, char * Gsensor, char *Gps)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnMakePlayFile)
		return 0;
	return s_fnMakePlayFile(m_dwHandle, fname, Gsensor, Gps);
}

UNS32 CTATLib::MakeTatFile(char *fname)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnMakeTatFile)
		return 0;
	return s_fnMakeTatFile(m_dwHandle, fname);
}

BOOL CTATLib::SetConfigData(char *data, UNS32 *size)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnSetConfigData)
		return 0;
	return s_fnSetConfigData(m_dwHandle, data, size);
}

BOOL CTATLib::GetConfigData(char *data, UNS32 *size)
{
	if (!s_hLibrary || !m_dwHandle || !s_fnGetConfigData)
		return 0;
	return s_fnGetConfigData(m_dwHandle, data, size);
}


void CTATLib::Init()
{
	//CLoadModule::FreeLibrary(s_hLibrary);
	s_hLibrary = 0;
	s_fnCreate = 0;
	s_fnDelete = 0;
	s_fnOpen = 0;
	s_fnClose = 0;
	s_fnRead = 0;
	s_fnWrite = 0;
	s_fnFormat = 0;
	s_fnCheckTATDevice = 0;
	s_fnGetFileFrameCnt = 0;
	s_fnGetFileIndexInfo = 0; 	 //s_fnGetFileIndexInfo 
	s_fnGetFileCnt = 0;
	s_fnGetFileList = 0;
	s_fnGetFileList_tt = 0;
	s_fnGetFileFlag = 0;
	s_fnFindStartStop = 0;
	s_fnGetPBPos = 0;
	s_fnSetSeekPos = 0;
	s_fnSetPcfolder = 0;
	s_fnPBInit = 0;
	s_fnPBStart = 0;
	s_fnFatPBStart = 0;
	s_fnReadFrame = 0;
	s_fnMakePictureFile = 0;
	s_fnMakeAviFile = 0;
	s_fnMakePlayFile = 0;
	s_fnMakeTatFile = 0;
	s_fnMakeDataFile = 0;
	s_fnSetConfigData = 0;  // sole@20140727
	s_fnGetConfigData = 0;  // sole@20140727
	s_fnGetDeviceName = 0;
	s_fnSetDevice = 0; //20160414

}

