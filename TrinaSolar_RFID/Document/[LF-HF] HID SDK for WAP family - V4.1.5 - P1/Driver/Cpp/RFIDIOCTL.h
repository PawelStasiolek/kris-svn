/* $Revision 1.0 */
/* Copyright Psion Teklogix Inc. 2010 */
/*
 * File: RFIDDriver.h
 *
 * Description:
 *  Header file that contains the definitions to manage the RFID driver.
 *
 */

#ifndef RFIDIOCTL_H
#define RFIDIOCTL_H

/* Error codes: LONG
 */
#define     RFID_SUCCESS						0
#define     RFID_ERR_OPENING_DRIVER				1
#define     RFID_ERR_CLOSING_DRIVER				2
#define     RFID_ERR_DRIVER_NOT_OPEN			3
#define     RFID_ERR_GETTING_CONNECTION_NUMBER	4
#define     RFID_ERR_ALREADY_ENABLED			5
#define     RFID_ERR_ALREADY_DISABLED			6

#define     RFID_ERR_UNKNOWN					10

#define     RFID_ERR_CONFIGURING_XMOD			50
#define     RFID_ERR_POWERING_XMOD				51

#define     RFID_ERR_POWERING_USB				100
#define     RFID_ERR_NO_USB_READER_FOUND		101
#define     RFID_ERR_DETECTING_REAL_PORT	    102
#define     RFID_ERR_ACTIVATING_VIRTUAL_PORT    103
#define     RFID_ERR_DEACTIVATING_VIRTUAL_PORT  104


// Supported Ioctl codes
#define TEK_CTL_CODE_FILE_DEVICE_RFID   0x8200

#define IOCTL_RFID_FUNCTION(idFunction) \
                                        CTL_CODE(TEK_CTL_CODE_FILE_DEVICE_RFID, \
                                                 0xa00 + idFunction, \
                                                 METHOD_NEITHER, FILE_ANY_ACCESS)

#define IOCTL_ENABLE_RFID_CONNECTION		IOCTL_RFID_FUNCTION( 1)
#define IOCTL_DISABLE_RFID_CONNECTION		IOCTL_RFID_FUNCTION( 2)

#endif  //  RFIDIOCTL_H
