#pragma once
#include "stdafx.h"
#ifdef READER_EXPORTS
#define DLLDIR __declspec(dllexport)   // export DLL information
#else
   #define DLLDIR __declspec(dllimport)   // import DLL information
#endif

// DESFire and SAM definitions
#define DESFIRE_SAM_ON_OFF                0x00
#define DESFIRE_AUTHENICATE               0x01
#define DESFIRE_CHANGE_KEY_SETTINGS       0x02
#define DESFIRE_GET_KEY_SETTINGS          0x03
#define DESFIRE_CHANGE_KEY                0x04
#define DESFIRE_GET_KEY_VERSION           0x05
#define DESFIRE_CREATE_APPLICATION        0x06
#define DESFIRE_DELETE_APPLICATION        0x07
#define DESFIRE_GET_APPLICATION_IDS       0x08
#define DESFIRE_SELECT_APPLICATION        0x09
#define DESFIRE_FORMAT_PICC               0x0A
#define DESFIRE_GET_VERSION               0x0B
#define DESFIRE_GET_FILE_IDS              0x0C
#define DESFIRE_GET_FILE_SETTINGS         0x0D
#define DESFIRE_CHANGE_FILE_SETTINGS      0x0E
#define DESFIRE_CREATE_STANDARD_DATA_FILE 0x0F
#define DESFIRE_CREATE_BACKUP_DATA_FILE   0x10
#define DESFIRE_CREATE_VALUE_FILE         0x11
#define DESFIRE_CREATE_LINEAR_RECORD_FILE 0x12
#define DESFIRE_CREATE_CYCLIC_RECORD_FILE 0x13
#define DESFIRE_DELETE_FILE               0x14
#define DESFIRE_READ_DATA                 0x15
#define DESFIRE_READ_RECORDS              0x16
#define DESFIRE_WRITE_DATA                0x17
#define DESFIRE_WRITE_RECORDS             0x18
#define DESFIRE_GET_VALUE                 0x19
#define DESFIRE_CREDIT                    0x1A
#define DESFIRE_DEBIT                     0x1B
#define DESFIRE_LIMITED_CREDIT            0x1C
#define DESFIRE_CLEAR_RECORD_FILE         0x1D
#define DESFIRE_COMMIT_TRANSACTION        0x1E
#define DESFIRE_ABORT_TRANSACTION         0x1F
#define DESFIRE_SET_FILE_SETTINGS         0x20

#define DESFIRE_INIT_PCB_BLOCKNUMBER      0x2F

#define SAM_DISABLE_CRYPTO                0x30
#define SAM_CHANGE_KEY_ENTRY              0x31
#define SAM_GET_KEY_ENTRY                 0x32
#define SAM_CHANGE_KUC_ENTRY              0x33
#define SAM_GET_KUC_ENTRY                 0x34
#define SAM_CHANGE_KEY_PICC               0x35
#define SAM_GET_VERSION                   0x36
#define SAM_AUTHENTICATE_HOST             0x37
#define SAM_SELECT_APPLICATION            0x38
#define SAM_DUMP_SESSION_KEY              0x39
#define SAM_LOAD_INIT_VECTOR              0x3A
#define SAM_AUTHENTICATE_PICC1            0x3B
#define SAM_AUTHENTICATE_PICC2            0x3C
#define SAM_VERIFY_MAC                    0x3D
#define SAM_GENERATE_MAC                  0x3E
#define SAM_DECIPHER_DATA                 0x3F
#define SAM_ENCIPHER_DATA                 0x40
#define SAM_SET_LOGICAL_CHANNEL           0x42
#define SAM_SET_TRANSMISSION_FACTOR       0x43

// Paypass error definitions
#define PAYPASS_ERROR_OK                0x00
#define PAYPASS_ERROR_NOTAG             0x01 // no tag found
#define PAYPASS_ERROR_COLLISION         0x02 // more than one tag found
#define PAYPASS_ERROR_TAGFOUND          0x03 // deactivation not complete, tag found
#define PAYPASS_ERROR                   0x04 // Polling/Activation/Transaction Error

#define PAYPASS_ERROR_READERPOINTER     0x41 // pointer is zero
#define PAYPASS_ERROR_PROTOCOL          0x42 // ascii protocol found
#define PAYPASS_ERROR_READER            0x43 // no MultiISO/Dual found
#define PAYPASS_ERROR_BUFFEROVERFLOW    0x45 // Transaction Receiver Buffer Overflow


/*Command define Directives.*/
#define PROTOCOL_ASCII 0
#define PROTOCOL_BIN   1

#define READER_UNKNOWN     0x01
#define READER_MIFARE14E   0x02
#define READER_MIFARE15D   0x03
#define READER_MIFARE1X    0x04
//#define READER_ISO09U      0x05
#define READER_ISO09V      0x06
//#define READER_BUSNODE     0x07
#define READER_MULTITAG10B 0x08
//#define READER_ISO09X      0x09
#define READER_MULTITAG12A 0x0A
#define READER_MULTITAG12B 0x0B
#define READER_MIFARE15E   0x0C
//#define READER_DUAL1X      0x0D
//#define READER_USBMIFARE   0x0E
#define READER_BOOTLOADER  0x0F
#define READER_DUAL2X      0x10
//#define READER_ISO1X       0x11
#define READER_MULTITAG1X  0x12
#define READER_LFX1X       0x13
#define READER_MULTIISO1X  0x14
//#define READER_DUAL3X      0x15

 struct presetSettings
{
  long baudRate;  
  char protocol;  
};

 struct readerConfig
{
  long baudRate;  
  char protocol;  
  unsigned char stationID;
};

#ifndef _WIN32_WCE
extern "C"{  
  _CRT_INSECURE_DEPRECATE(RDR_GetDLLVersionStr) DLLDIR long RDR_GetDLLVersion(void);                          // get version of reader DLL (obsolete, use GetDLLVersionStr)
   DLLDIR char* RDR_GetDLLVersionStr(char* buffer);               // get version of reader DLL as string
  // Decive communication
    DLLDIR char RDR_OpenSingle(void** hComm, void** hReader, char* commDevice, char autodetect, short knownReader, struct presetSettings* settings);
    DLLDIR void* RDR_OpenComm(char* commDevice, char autodetect, struct presetSettings* settings); // initialize communication
	DLLDIR void* RDR_OpenComm_OxfordBoard(char* commDevice, char autodetect, struct presetSettings* settings);
    DLLDIR void  RDR_SetCommBaudRate_OxfordBoard(long bdRate);       // set Baud Rate for serial communication
  	DLLDIR void RDR_CloseComm(void* hComm);                 // close communication
    DLLDIR void RDR_SleepComm(void* hComm);                 // closes the communication handle
    DLLDIR char RDR_WakeupComm(void* hComm);                // reopens the communication handle
    DLLDIR void RDR_EmptyCommRcvBuffer(void* hComm);        // empty the serial receive buffer
    _CRT_INSECURE_DEPRECATE(RDR_AbortContinuousReadExt) DLLDIR void RDR_AbortContinuousRead(void* hComm);       // OBSOLETE: abort continuous read mode
    DLLDIR void RDR_AbortContinuousReadExt(void* hReader);  // abort continuous read mode
    DLLDIR void RDR_SetCommProtocol(void* hComm, char protocol);     // set the transfer Mode for serial communication (0 = ASCII, 1 = BIN)
    DLLDIR char RDR_GetCommProtocol(void* hComm);           // get the protocol for serial communication (0 = ASCII, 1 = BIN)
    DLLDIR void RDR_SetCommBaudRate(void* hComm, long bdRate);       // set Baud Rate for serial communication
    DLLDIR long RDR_GetCommBaudRate(void* hComm);           // get Baud Rate for serial communication
    DLLDIR void RDR_SetCommContRcv(void* hComm, char contReceiveMode);      // set continuous receive mode
    DLLDIR char RDR_GetCommContRcv(void* hComm);            // get continuous receive mode
    DLLDIR void RDR_SetCommTimeout(void* hComm, long timeout);       // set the timeout in msec for communication device for GetData in continuous mode OFF
    DLLDIR long RDR_GetCommTimeout(void* hComm);            // get the timeout of the communication device
    DLLDIR void RDR_CommExtFunction(void* hComm, long fkt);   // control of RTS and DTR pin
    DLLDIR void* RDR_GetCommDeviceHandle(void* hComm);       // returns the communication device handle
  // Reader communication
    DLLDIR char* RDR_DetectReader(void* hComm, char* return_buffer);  // detect readers on specified communication device
    DLLDIR void* RDR_OpenReader(void* hComm, unsigned char id, short knownReader); // open specified reader on specified communication device
    DLLDIR void  RDR_CloseReader(void* hReader);            // close reader
    DLLDIR void  RDR_ResetReader(void* hReader);            // reset reader
    DLLDIR long  RDR_SendCommand(void* hReader, char* command, char* data);     // send a command with data to reader
    DLLDIR char* RDR_SendCommandGetData(void* hReader, char* command, char* data, char* return_buffer); // send command and receive correct string/frame
    DLLDIR char* RDR_SendCommandGetDataTimeout(void* hReader, char* command, char* data, char* return_buffer, long timeout); // send command and receive correct string/frame with timeout
    DLLDIR char* RDR_GetData(void* hReader, char* return_buffer);    // receive data from reader
                                          // on BIN mode, the first character represent the length of th data
    DLLDIR char* RDR_GetDataTimeout(void* hReader, char* return_buffer, long timeout);  // wait until data received or timeout in ms exceeded
    DLLDIR void  RDR_SetReaderConfig(void* hReader, struct readerConfig* config); // set the reader protocol, baud rate and station id
    DLLDIR struct readerConfig RDR_GetReaderConfig(void* hReader);      // get the reader protocol, baud rate and station id
    DLLDIR char* RDR_GetReaderType(void* hReader, char* return_buffer); // get version string from reader
    DLLDIR unsigned char RDR_GetStationID(void* hReader);      // get the station id
    DLLDIR char  RDR_IsCommandAvailable(void* hReader, char* command);  // return 0: if script command is not available for the reader
                                                            // return 1: is available
    DLLDIR char* RDR_GetDeviceID(void* hReader, char* return_buffer);   // get the device id (serial number) from the reader
    DLLDIR void  RDR_SetBroadcast(void* hReader, char broadcast);       // in binary mode send broadcast (station id 0xFF) or to specified station id
    DLLDIR char  RDR_GetBroadcast(void* hReader);              // 1 = in broadcast mode, 0 = sending specified station id

  // 512 Byte Versions
    DLLDIR char* RDR_GetDataTimeout2(void* hReader, char* return_buffer, unsigned int* return_length, long timeout);  // wait until data received or timeout in ms exceeded
    DLLDIR char* RDR_GetData2(void* hReader, char* return_buffer, unsigned int* return_length); // receive data from reader
    DLLDIR char* RDR_SendCommandGetDataTimeout2(void* hReader, char* command, char* data, unsigned int length, char* return_buffer, unsigned int* return_length, long timeout);
    DLLDIR char* RDR_SendCommandGetData2(void* hReader, char* command, char* data, unsigned int length, char* return_buffer, unsigned int* return_length);
    DLLDIR long RDR_SendCommand2(void* hReader, char* command, char* data, unsigned int length);

  // Firmware Update
    DLLDIR long  RDR_LoadFirmware(void* hReader, char* data, long length, char* password, char option); // load firmware
    DLLDIR void  RDR_InitUpdateFirmware(); // set variables
    DLLDIR char  RDR_UpdateFirmware(void* hReader); // flash Firmware

  // debug output
    DLLDIR void  RDR_SetDebugOutputState(void* hReader, char state);
    DLLDIR char  RDR_GetDebugOutputState(void* hReader);
    DLLDIR char* RDR_GetDebugOutput(void* hReader, char* buffer);

  // timing
    DLLDIR void  RDR_StartTimer(void* hReader);
    DLLDIR float RDR_GetTiming(void* hReader);

  // binary protocol type 2
    DLLDIR char  RDR_GetBinFlag(void* hReader);
    DLLDIR char  RDR_GetBinProtocol(void* hReader);

  // detects all available serial ports
    DLLDIR char  RDR_DetectSerialPort(char* return_buffer, long bufLength);

  // DES Algorithm
    DLLDIR char* RDR_DESEncrypt(char options, char *key, char *data, long length, char *output);
    DLLDIR char* RDR_DESDecrypt(char options, char *key, char *data, long length, char *output);

  // DESFire
    DLLDIR char* RDR_DESFire(void* hReader, char command, char* data, char* output);

  // DESFire SAM
    DLLDIR void  RDR_SetDESFireSAMTimeout(char timeout);
    DLLDIR char  RDR_GetDESFireSAMTimeout();

};

#else
  // Version function
  DLLDIR  long  RDR_GetDLLVersion(void);                          // get version of reader DLL (obsolete, use GetDLLVersionStr)
  DLLDIR  char* RDR_GetDLLVersionStr(char* buffer);               // get version of reader DLL as string

  // Decive communication
	DLLDIR char  RDR_OpenSingle(char* commDevice, char autodetect, short knownReader, struct presetSettings* settings);
	DLLDIR char  RDR_OpenComm(char* commDevice, char autodetect, struct presetSettings* settings); // initialize communication
	DLLDIR  char  RDR_OpenComm_OxfordBoard(char* commDevice, char autodetect, struct presetSettings* settings);
   DLLDIR void  RDR_SetCommBaudRate_OxfordBoard(long bdRate);       // set Baud Rate for serial communication
   DLLDIR void  RDR_CloseComm();                 // close communication
   DLLDIR void  RDR_SleepComm();                 // closes the communication handle
   DLLDIR char  RDR_WakeupComm();                // reopens the communication handle
   DLLDIR void  RDR_EmptyCommRcvBuffer();        // empty the serial receive buffer
   DLLDIR void  RDR_AbortContinuousRead();       // OBSOLETE: abort continuous read mode
   DLLDIR void  RDR_AbortContinuousReadExt();    // abort continuous read mode
   DLLDIR void  RDR_SetCommProtocol(char protocol);     // set the transfer Mode for serial communication (0 = ASCII, 1 = BIN)
   DLLDIR char  RDR_GetCommProtocol();           // get the protocol for serial communication (0 = ASCII, 1 = BIN)
   DLLDIR void  RDR_SetCommBaudRate(long bdRate);       // set Baud Rate for serial communication
   DLLDIR long  RDR_GetCommBaudRate();           // get Baud Rate for serial communication
   DLLDIR void  RDR_SetCommContRcv(char contReceiveMode);      // set continuous receive mode
   DLLDIR char  RDR_GetCommContRcv();            // get continuous receive mode
   DLLDIR void  RDR_SetCommTimeout(long timeout);       // set the timeout in msec for communication device for GetData in continuous mode OFF
   DLLDIR long  RDR_GetCommTimeout();            // get the timeout of the communication device
   DLLDIR void  RDR_CommExtFunction(long fkt);     // control of RTS and DTR pin
   DLLDIR void* RDR_GetCommDeviceHandle();       // returns the communication device handle

  // Reader communication
   DLLDIR char  RDR_DetectReader();  // detect readers on specified communication device
   DLLDIR char  RDR_OpenReader(unsigned char id, short knownReader); // open specified reader on specified communication device
   DLLDIR void  RDR_CloseReader();            // close reader
   DLLDIR void  RDR_ResetReader();            // reset reader
   DLLDIR long  RDR_SendCommand(char* command, char* data);     // send a command with data to reader
   DLLDIR char* RDR_SendCommandGetData(char* command, char* data, char* return_buffer); // send command and receive correct string/frame
   DLLDIR char* RDR_SendCommandGetDataTimeout(char* command, char* data, char* return_buffer, long timeout); // send command and receive correct string/frame with timeout
   DLLDIR char* RDR_GetData(char* return_buffer);    // receive data from reader
                                          // on BIN mode, the first character represent the length of th data
   DLLDIR char* RDR_GetDataTimeout(char* return_buffer, long timeout);  // wait until data received or timeout in ms exceeded
   DLLDIR char  RDR_SetReaderConfig(struct readerConfig* config); // set the reader protocol, baud rate and station id
   DLLDIR struct readerConfig RDR_GetReaderConfig();      // get the reader protocol, baud rate and station id
   DLLDIR char* RDR_GetReaderType(char* return_buffer); // get version string from reader
   DLLDIR unsigned char RDR_GetStationID();      // get the station id
   DLLDIR char  RDR_IsCommandAvailable(char* command);  // return 0: if script command is not available for the reader
                                                            // return 1: is available
   DLLDIR char* RDR_GetDeviceID(char* return_buffer);   // get the device id (serial number) from the reader
   DLLDIR void  RDR_SetBroadcast(char broadcast);       // in binary mode send broadcast (station id 0xFF) or to specified station id
   DLLDIR char  RDR_GetBroadcast();              // 1 = in broadcast mode, 0 = sending specified station id

  // 512 Byte Versions 
   DLLDIR char* RDR_GetDataTimeout2(char* return_buffer, unsigned int* return_length, long timeout);  // wait until data received or timeout in ms exceeded
   DLLDIR char* RDR_GetData2(char* return_buffer, unsigned int* return_length); // receive data from reader
   DLLDIR char* RDR_SendCommandGetDataTimeout2(char* command, char* data, unsigned int length, char* return_buffer, unsigned int* return_length, long timeout);
   DLLDIR char* RDR_SendCommandGetData2(char* command, char* data, unsigned int length, char* return_buffer, unsigned int* return_length);
   DLLDIR long RDR_SendCommand2(char* command, char* data, unsigned int length);

  // Firmware Update
   DLLDIR long  RDR_LoadFirmware(char* data, long length, char* password, char option); // load firmware
   DLLDIR void  RDR_InitUpdateFirmware(); // initialize update process
   DLLDIR char  RDR_UpdateFirmware();     // update firmware

  // debug output
   DLLDIR void  RDR_SetDebugOutputState(char state);
   DLLDIR char  RDR_GetDebugOutputState();
   DLLDIR char* RDR_GetDebugOutput(char* buffer);

  // timing
   DLLDIR void  RDR_StartTimer();
   DLLDIR float RDR_GetTiming();

  // binary protocol type 2
   DLLDIR char  RDR_GetBinFlag();
   DLLDIR char  RDR_GetBinProtocol();

   DLLDIR char  RDR_GetResumeState();                      // 1 if in resume mode (all communication functions are freezed), 0 if in normal mode, -1 if error
   DLLDIR char* RDR_DetectSerialPort(char* return_buffer); // detects the com port

  // DES Algorithm
   DLLDIR char* RDR_DESEncrypt(char options, char *key, char *data, long length, char *output);
  DLLDIR  char* RDR_DESDecrypt(char options, char *key, char *data, long length, char *output);

  // DESFire
   DLLDIR char* RDR_DESFire(char command, char* data, char* output);

  // DESFire SAM
   DLLDIR void  RDR_SetDESFireSAMTimeout(char timeout);
	DLLDIR  char  RDR_GetDESFireSAMTimeout();

  // enable high baud rates (230400 + 460800 Baud)
  DLLDIR  void  RDR_SetHighBaudrates(char enable);
  DLLDIR char  RDR_GetHighBaudrates();

  // Int to Float (needed for C#)
    void  RDR_IntToFloat(float *dest, int src);
  // private functions
  DWORD WINAPI MessageThreadProc(LPVOID lpParameter);
  void PowerDeinit();
  bool PowerInit();

  // Power up detected windows message, sent to the application
  // by the driver
  #define WM_PWR_POWERUP	(WM_USER+1)
  #define IOCTL_PWR_GET_POWERUP_STATE		 	  0x00000001
  #define IOCTL_PWR_RESET_POWERUP_STATE	 	  0x00000002
  #define IOCTL_PWR_ENABLE_POWERUP_MESSAGE 	0x00000003
  #define IOCTL_PWR_DISABLE_POWERUP_MESSAGE 0x00000004
#endif

