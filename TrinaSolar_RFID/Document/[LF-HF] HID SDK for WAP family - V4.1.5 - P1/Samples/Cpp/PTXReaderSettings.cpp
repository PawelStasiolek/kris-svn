// PTXReaderSettings.cpp : implementation file
//

#include "stdafx.h"
#include "Reader Terminal.h"
#include "PTXReaderSettings.h"
#include "Reader TerminalDlg.h"
#include "PsionTeklogixWORKABOUTPROHDK.hpp"

#include <windows.h>                // For all that Windows stuff
#include <winioctl.h>                // Needed for CTLCODE macro
#include <winbase.h>

//#include <wchar.h>
// PTXReaderSettings dialog

IMPLEMENT_DYNAMIC(PTXReaderSettings, CDialog)

PTXReaderSettings::PTXReaderSettings(CWnd* pParent /*=NULL*/)
	: CDialog(PTXReaderSettings::IDD, pParent)
{

}

PTXReaderSettings::~PTXReaderSettings()
{
}

void PTXReaderSettings::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_COMBOCONNECTION, m_ctrlConnection);
	DDX_Control(pDX, IDC_COMBOCOMPORT, m_ctrlComPort);
	DDX_Control(pDX, IDC_BUTTON1, m_ctrlConnect);
	DDX_Control(pDX, IDC_LIST1, m_ctrlList);
}


BEGIN_MESSAGE_MAP(PTXReaderSettings, CDialog)
	ON_BN_CLICKED(IDC_BUTTON1, &PTXReaderSettings::OnBnClickedButton1)
END_MESSAGE_MAP()



TCHAR * IsPtxUsbSerial( HANDLE hDevice)
{
	DEVMGR_DEVICE_INFORMATION devInfo;
	devInfo.dwSize = sizeof(devInfo);

	TCHAR * readerType = NULL;

	if( GetDeviceInformationByDeviceHandle( hDevice, &devInfo ) )
	{
		if (wcscmp(devInfo.szDeviceKey, _T("Drivers\\USB\\ClientDrivers\\PtxRfidHF_UsbSerial")) == 0)
		{
			readerType = TEXT("HF");
		}
		else if (wcscmp(devInfo.szDeviceKey, _T("Drivers\\USB\\ClientDrivers\\PtxRfidLF_UsbSerial")) == 0)
		{
			readerType = TEXT("LF");
		}
		else if (wcscmp(devInfo.szDeviceKey, _T("Drivers\\USB\\ClientDrivers\\PtxRfidUHF_UsbSerial")) == 0)
		{
			readerType = TEXT("UHF");
		}
		else if (wcscmp(devInfo.szDeviceKey, _T("Drivers\\USB\\ClientDrivers\\PsionTeklogixUsbSerial")) == 0 ||
			wcscmp(devInfo.szDeviceKey, _T("Drivers\\USB\\ClientDrivers\\PsionTeklogixUsbSerial_A")) == 0)
		{				
			readerType = _T("USB");
		}

	}

	return readerType;
}

HANDLE SearchSerialPort(int iPort)
{
	HANDLE hDevice = NULL;
	DEVMGR_DEVICE_INFORMATION devInfo;
	devInfo.dwSize = sizeof(devInfo);

	TCHAR szSearchPattern[6];
	wsprintf(szSearchPattern, _T("COM%d"), iPort);	

	HANDLE hSearch = FindFirstDevice( DeviceSearchByDeviceName, szSearchPattern, &devInfo);


    if(hSearch == INVALID_HANDLE_VALUE)
    {
        switch(GetLastError())
        {
            case ERROR_NO_MORE_FILES:
				return NULL;
                break;
            default:
	           //TODO: display message in label 
               //DPRINT1("FindFirstDevice Failed - INVALID_HANDLE_VALUE, %x\n", GetLastError());
				break;
        }
    }
    else
    {
		hDevice = devInfo.hDevice;
	}
        
	if( !FindClose(hSearch) )
	{
            //TODO: display message in label 
			//DPRINT1("FindClose Failed, %d\n", GetLastError());
	}

	return hDevice;
}


void ActivateUSBReader(void)
{
	using namespace PsionTeklogix::WORKABOUTPRO_HDK;

	// Power on the hub
	USBHub::EnablePower(TRUE);

	// Power on the reader
	ExpansionUSB::EnablePower(TRUE);
}

void DeactivateUSBReader(void)
{
	using namespace PsionTeklogix::WORKABOUTPRO_HDK;

	// Power on the reader
	ExpansionUSB::EnablePower(FALSE);

	// Power on the hub - not sure the hub is only used for RFID
	//USBHub::EnablePower(TRUE);
}

bool DeactivateVirtualPort( HANDLE hDevice )
{
	if( DeactivateDevice(hDevice) )
		return true;
	else
		return false;
}

HANDLE ActivateVirtualPort(DWORD realPort, DWORD virtualPort)
{
	HKEY hKey;
	DWORD dwDisp = 0;
	DWORD dwDataSize = 0;
	DWORD dwType = REG_DWORD;
	DWORD value = 0;

	TCHAR szPortName[100];
	TCHAR * VPortRegEntry = _T("Drivers\\BuiltIn\\PtxRFIDvPort");
	DWORD dwDeviceArrayIndex = 0;
	TCHAR * szPrefix = _T("Prefix");
	TCHAR * szDll =  _T("Dll");

	HANDLE hDevice;

	// Set registry to create & active the virtual com port
	if( RegCreateKeyEx(HKEY_LOCAL_MACHINE, VPortRegEntry, 0, NULL, REG_OPTION_NON_VOLATILE, 0, NULL, &hKey, &dwDisp) != ERROR_SUCCESS)				
		return INVALID_HANDLE_VALUE;

	// Check virtual port availability
	hDevice = SearchSerialPort(virtualPort);
	if( hDevice != INVALID_HANDLE_VALUE && hDevice != NULL )
		if( !DeactivateVirtualPort( hDevice ) )
				return INVALID_HANDLE_VALUE;

	// Check if the virtual port is already present
	if( dwDisp == REG_OPENED_EXISTING_KEY )
	{
		// Unload virtual port if required
		dwDataSize = sizeof(DWORD);
		if( RegQueryValueEx( hKey, _T("Index"), 0, &dwType, (PBYTE)&value, &dwDataSize ) == ERROR_SUCCESS)
		{
			hDevice = SearchSerialPort(value);
			
			if( hDevice != INVALID_HANDLE_VALUE && hDevice != NULL )
				if( !DeactivateVirtualPort( hDevice ) )
					return INVALID_HANDLE_VALUE;
		}
	}

	// Write or update registry settings
	RegSetValueEx( hKey, _T("DeviceArrayIndex"), 0, REG_DWORD, (LPBYTE)&dwDeviceArrayIndex, sizeof(dwDeviceArrayIndex));

	if (realPort > 9)
	{
		wsprintf(szPortName, _T("%s%d"), _T("\\$device\\COM"), realPort);
		dwDataSize = wcslen(szPortName) * sizeof(TCHAR);
		RegSetValueEx( hKey, _T("RealPortName"), 0, REG_SZ, (LPBYTE)szPortName, dwDataSize);
	}
	else
	{
		wsprintf(szPortName, _T("COM%d:"), realPort);
		dwDataSize = wcslen(szPortName) * sizeof(TCHAR);
		RegSetValueEx( hKey, _T("RealPortName"), 0, REG_SZ, (LPBYTE)szPortName, dwDataSize);
	}

	RegSetValueEx( hKey, _T("Index"), 0, REG_DWORD, (LPBYTE)&virtualPort, sizeof(virtualPort));

	dwDataSize = wcslen(_T("COM")) * sizeof(TCHAR);
	RegSetValueEx( hKey, szPrefix, 0, REG_SZ, (LPBYTE)_T("COM"), dwDataSize);

	dwDataSize = wcslen(_T("vport.dll")) * sizeof(TCHAR);
	RegSetValueEx( hKey, szDll, 0, REG_SZ, (LPBYTE)_T("vport.dll"), dwDataSize);

	RegFlushKey(hKey);

	RegCloseKey(hKey);

	// Active the driver
	return ActivateDeviceEx(VPortRegEntry,NULL, 0, NULL);
}

bool ActivateXModReader(void)
{
	using namespace PsionTeklogix::WORKABOUTPRO_HDK::GPIO;
	
	GPIOResult result = Configure((GPIOpin) OutputPin72, true );
	if( result == GPIOSuccess )
	{
		result = SetPinState(static_cast<GPIOpin>(OutputPin72), false);
		Configure((GPIOpin) OutputPin72, false );
	}

	if( result != GPIOSuccess )
	{
		return false;
	}

	return true;
}

bool DeactivateXModReader(void)
{
	using namespace PsionTeklogix::WORKABOUTPRO_HDK::GPIO;
	
	GPIOResult result = Configure((GPIOpin) OutputPin72, true );
	if( result == GPIOSuccess )
	{
		result = SetPinState(static_cast<GPIOpin>(OutputPin72), false);
		Configure((GPIOpin) OutputPin72, false );
	}

	if( result != GPIOSuccess )
	{
		return false;
	}

	return true;
}

static void ResetWithSetSystemPowerState()
{
   typedef DWORD (*SetSystemPowerStateFunction)(LPCWSTR pwsSystemState, DWORD StateFlags, DWORD Options);
   HMODULE hModule = ::LoadLibrary(_T("Coredll.dll"));
   
   SetSystemPowerStateFunction f = (SetSystemPowerStateFunction)
      ::GetProcAddress(hModule, _T("SetSystemPowerState"));
   
#ifndef POWER_STATE_RESET
#define POWER_STATE_RESET DWORD(0x00800000)
#endif

   f(NULL, POWER_STATE_RESET, 0);
   ::FreeLibrary(hModule);
}

void PTXReaderSettings::DisplayComPort(bool searchRFIDUSBReader)
{
	DEVMGR_DEVICE_INFORMATION devInfo;
	devInfo.dwSize = sizeof(devInfo);

	HANDLE hSearch = FindFirstDevice( DeviceSearchByDeviceName, _T("COM*"), &devInfo);

    if(hSearch == INVALID_HANDLE_VALUE)
    {
        switch(GetLastError())
        {
            case ERROR_NO_MORE_FILES:
				m_ctrlList.AddString(_T("No serial port found!"));
                break;
            default:
	           //TODO: display message in label 
               //DPRINT1("FindFirstDevice Failed - INVALID_HANDLE_VALUE, %x\n", GetLastError());
				break;
        }
    }
    else
    {		
		m_ctrlList.AddString(_T("Please use one of the following ports:"));

        TCHAR szRFIDUsbSerial[255];
		TCHAR * readerType = NULL;

		do {
			// Use for debug
/*			WCHAR m_szDevice[MAX_PATH];
			wcscpy( m_szDevice, devInfo.szDeviceName);

			WCHAR m_szDeviceKey[MAX_PATH];
			wcscpy( m_szDeviceKey, devInfo.szDeviceKey);		*/	

			// Get the port name
			WCHAR comPort[5];
			int len = wcslen(devInfo.szDeviceName);
			wcsncpy(comPort, devInfo.szDeviceName + 8, len - 8);
			comPort[len - 8] = 0;

			if( searchRFIDUSBReader )
			{
				readerType = IsPtxUsbSerial( devInfo.hDevice );
				if( readerType != NULL )
				{					
					wsprintf(szRFIDUsbSerial, _T("%s reader on %s"), readerType ,comPort);

					m_ctrlList.AddString(szRFIDUsbSerial);
				}
			}
			else
			{				
				m_ctrlList.AddString(comPort);
			}
		}
        while( FindNextDevice(hSearch, &devInfo) );
        
		if( FindClose(hSearch) == 0 )
		{
            //TODO: display message in label 
			//DPRINT1("FindClose Failed, %d\n", GetLastError());  
        }
	}
}

// PTXReaderSettings message handlers

void PTXReaderSettings::OnBnClickedButton1()
{
	m_ctrlList.ResetContent();
	SetDlgItemText(IDC_STATICINFO, _T(""));

	HKEY hKey;
	DWORD dwType = REG_DWORD;
	DWORD dwDisp = 0;
	DWORD dwDataSize = 0; 
	DWORD value;

	HANDLE hDevice;

	int ret = -1;
	int len = -1;

	bool readerAvailable = false;
	TCHAR * readerType;

	int iVirtualPort = 8;

	int iConnection = m_ctrlConnection.GetCurSel();
	int iComPort = m_ctrlComPort.GetCurSel();
	int iComPortSaved = m_ctrlComPort.GetCurSel();


	// Active connection
	switch( iConnection )
	{
		case 0:		// XMod is selected

			// Check if FFUART is egual to 1
			if (RegOpenKeyEx(HKEY_LOCAL_MACHINE,
				_T("Drivers\\PsionTeklogix\\Expansion Slot"),
				0, KEY_ALL_ACCESS, &hKey) != ERROR_SUCCESS)
			{
				MessageBox(L"Registry error",L"CONNECTION FAILURE");
				return;
			}

			if (RegQueryValueEx( hKey, _T("FFUART"), 0, &dwType, (PBYTE) NULL, &dwDataSize ) == ERROR_SUCCESS)
			{
				RegQueryValueEx( hKey, _T("FFUART"), 0, &dwType, (PBYTE) &value, &dwDataSize );

				if (value != 1)
				{
					value = 1;

					// Set 1 to the key value
					RegSetValueEx(hKey, _T("FFUART"),0, dwType, (PBYTE) &value , sizeof(DWORD));
					RegCloseKey(hKey);

					MessageBox(_T("A reboot will be done to configure the Xmod connector like a serial port"));
					// reboot WAP
					ResetWithSetSystemPowerState();
				}
			}
			RegCloseKey(hKey);

			// Power on the reader
			ActivateXModReader();

			// slepp time for reader initialization
			Sleep(1000);

			// Select the COM1:
			iComPort = 1;
			m_ctrlComPort.SetCurSel(iComPort);
			hDevice = SearchSerialPort(iComPort);

			if( hDevice == INVALID_HANDLE_VALUE || hDevice == NULL )
			{
				MessageBox(_T("Port not available!"), _T("IO ERROR"));
				break;
			}
			else
			{
				readerAvailable = true;
			}
			
			break;

		case 1:		// USB is selected
			ActivateUSBReader();
			
			// Sleep time for USB and reader initialization
			Sleep(500);

			// Happens when no com port selected
			if( iComPort == -1 )
			{
				DisplayComPort( true );
				break;
			}

			// Check if the selected com port is available and match a HF reader
			hDevice  = SearchSerialPort(iComPort);
			if( hDevice == INVALID_HANDLE_VALUE || hDevice == NULL )
			{
				MessageBox(_T("Port not available!"), _T("IO ERROR"));
				DisplayComPort( true );
				break;
			}

			readerType = IsPtxUsbSerial(hDevice);
			if( readerType == NULL )
			{
				MessageBox(_T("No RFID reader detected on this port!"), _T("READER TYPE ERROR"));
				DisplayComPort( true );
				break;
			}

			SetDlgItemText(IDC_STATICINFO, _T("Connection in progress..."));

			// Create the virtual port to handle the communication with RFID reader during suspend
			// We choose to map this on COM8, because the COM8 is usually not used
			m_ctrlList.AddString(_T("Creating virtual port..."));

			hDevice = ActivateVirtualPort(iComPort, iVirtualPort);
			if( hDevice == INVALID_HANDLE_VALUE || hDevice == NULL )
			{
				MessageBox(_T("Virtual port activation fails!"), _T("VIRTUAL PORT CREATION FAILURE"));
				break;
			}

			m_ctrlList.AddString(_T("Select virtual port to handle connection"));
			m_ctrlList.AddString(_T("during suspend state."));

			// Select the COM8:
			iComPort = iVirtualPort;
			m_ctrlComPort.SetCurSel(iComPort);
			readerAvailable = true;
			break;

		case 2:		// CompactFlash is selected
			
			// Happens when no com port selected
			if( iComPort == -1 )
			{
				DisplayComPort( false );
				break;
			}

			// Nothing specific things to do
			readerAvailable = true;
			break;

		default:
			MessageBox (_T("Please select a connection"));
			return;
	}

	if( iComPort == -1 )
	{
		MessageBox (_T("Please select a com port"));
	}
	else if ( readerAvailable)
	{
		m_ctrlList.AddString(_T("Opening reader..."));
		
		// get the com port number and launch the AAITG window
		CReaderTerminalDlg dlg;
		dlg.portNumber = iComPort;
		int nResponse = dlg.DoModal();

		m_ctrlList.AddString(_T("Reader closed."));
		SetDlgItemText(IDC_STATICINFO, _T(""));
	}		

	
	// Deactive connection
	switch( iConnection )
	{
		case 0:
			DeactivateXModReader();
			break;
		case 1:		// USB is selected
			DeactivateUSBReader();

			// reload real com port
			m_ctrlComPort.SetCurSel(iComPortSaved);
			break;
		case 2:		// CompactFlash is selected
			break;
	}
}

