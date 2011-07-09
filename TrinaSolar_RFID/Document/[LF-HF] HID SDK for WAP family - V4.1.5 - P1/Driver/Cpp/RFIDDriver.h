/* $Revision 1.0 */
/* Copyright Psion Teklogix Inc. 2010 */
/*
 * File: RFIDDriver.h
 *
 * Description:
 *  Header file that contains the definitions to manage the RFID driver.
 *
 */
#ifndef __RFIDDRIVER_H
#define __RFIDDRIVER_H

/**
@brief This is the Psion Teklogix root namespace.  It has no publicly-accessible
members or functions.  All SDK functionality is contained within other
namespaces nested within this one.
*/
namespace PsionTeklogix
{
	namespace RFID
	{
		class RFIDDriver
		{
			public:
                /**
                 Class constructor. 
                */
				RFIDDriver();
                /**
                 Class constructor. 
                */
				RFIDDriver(int driverNumber);
                /**
                Checks if the RFID driver is well installed
                @return BOOL (true: installed / false: not installed)
                */
				BOOL IsInstalled();
                /**
                Checks if the RFID driver is enabled (powered and com port assigned)
                @return BOOL (true: enabled / false: disabled)
                */
				BOOL IsEnabled();
                /**
                Checks if the RFID driver is enabled (powered and com port assigned)
                @return DWORD > 0 (value of com port assigned)
						DWORD == -1 (impossbile to get the com port number)
                */
				DWORD ComPort();

                /**
                Enables RFID driver 
                @return DWORD == 0 (Success)
						DWORD > 0 (refer RFID_ERR in RFIDIOCTL to get error messages)
                */
				DWORD Enable ();
                /**
                Disables RFID driver 
                @return DWORD == 0 (Success)
						DWORD > 0 (refer RFID_ERR in RFIDIOCTL to get error messages)
                */
				DWORD Disable ();
		};
	}
}
#endif // __RFIDDRIVER_H
