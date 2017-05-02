// managedTAT.h

#pragma once

#include "..\TATFileLib\TATFileLib.h"
using namespace System;

namespace managedTAT {

	public ref class TATWrap
	{
	protected:
		CAVIWriter *m_aviwriter;

	public:
		TATWrap();
		virtual ~TATWrap();

		bool Create(const char* filename);
		int Close(const void* extBuf, int extSize);

		void CloseForced();

		int  fWrite(const void *buf, int size);
		int  fSeek(long off_set, int mode);

		bool AddData(char *data, int size, int type);

		void UseVideo2(bool bTrue);
		void UseAudio(bool bTrue);
		void UseMJpeg(bool bTrue);
		void UseChecksum(bool bTrue);
		void SetDim(int idx, int width, int height);
		void SetFPS(int idx, int fps);
		void SetAudioSampleRate(int rate);

		const char *GetHeader(mType type);

	};
}
