// 기본 DLL 파일입니다.

#include "stdafx.h"

#include "managedTAT.h"

namespace managedTAT
{
	TATWrap::TATWrap()
		:m_aviwriter(new CAVIWriter)
	{

	}

	TATWrap::~TATWrap()
	{
		if (m_aviwriter)
		{
			delete m_aviwriter;
			m_aviwriter = 0;
		}
	}

	bool TATWrap::Create(const char* filename)
	{
		return (m_aviwriter->Create(filename));
	}

	int TATWrap::Close(const void *extBuf, int extSize)
	{
		return (m_aviwriter->Close(extBuf, extSize));
	}

	void TATWrap::CloseForced()
	{
		m_aviwriter->CloseForced();
	}

	int TATWrap::fWrite(const void* buf, int size)
	{
		return (m_aviwriter->fWrite(buf, size));
	}

	int TATWrap::fSeek(long off_set, int mode)
	{
		return (m_aviwriter->fSeek(off_set, mode));
	}

	bool TATWrap::AddData(char* data, int size, int type)
	{
		return (m_aviwriter->AddData(data, size, type));
	}

	void TATWrap::UseVideo2(bool bTrue)
	{
		m_aviwriter->UseVideo2(bTrue);
	}

	void TATWrap::UseAudio(bool bTrue)
	{
		m_aviwriter->UseAudio(bTrue);
	}

	void TATWrap::UseMJpeg(bool bTrue)
	{
		m_aviwriter->UseMJpeg(bTrue);
	}

	void TATWrap::UseChecksum(bool bTrue)
	{
		m_aviwriter->UseChecksum(bTrue);
	}

	void TATWrap::SetDim(int idx, int width, int height)
	{
		m_aviwriter->SetDim(idx, width, height);
	}

	void TATWrap::SetFPS(int idx, int fps)
	{
		m_aviwriter->SetFPS(idx, fps);
	}

	void TATWrap::SetAudioSampleRate(int rate)
	{
		m_aviwriter->SetAudioSampleRate(rate);
	}

	const char* TATWrap::GetHeader(mType type)
	{
		return (m_aviwriter->GetHeader(type));
	}
	
	

}

