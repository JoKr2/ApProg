/*
 * Uart.c
 *
 * Created: 27. 11. 2011 10:38:22
 *  Author: Fezoj
 */

#include "../Headers/Shared.h"
#include <avr/io.h>
#include <util/setbaud.h>

void InitUart(void)
{
	// Set baud rate
	UBRRH = UBRRH_VALUE;
	UBRRL = UBRRL_VALUE;
	#if USE_2X
		UCSRA |= (1 << U2X);
	#else
		UCSRA &= ~(1 << U2X);
	#endif	
	
	// Enable receiver and transmitter but no interrupts
	UCSRB = (1 << RXEN) | (1 << TXEN);
	
	// Set frame format, 8data, 1stop
	UCSRC = (1 << URSEL) | (1 << UCSZ1) | (1 << UCSZ0);
}

void SendBuffer(unsigned char buffer[], unsigned char count)
{
	for(unsigned char index = 0; index < count; index++)
	{
		while ((UCSRA & (1 << UDRE)) == 0)
			; // Do nothing until UDR is ready for more data to be written to it 
		UDR = buffer[index]; // Send out the byte value in the variable "ByteToSend"
	}	
}

void ReceiveBuffer(unsigned char buffer[], unsigned char count)
{
	for(unsigned char index = 0; index < count; index++)
	{
		while ((UCSRA & (1 << RXC)) == 0)
			; // Do nothing until data have been received and is ready to be read from UDR
		buffer[index] = UDR;	
	}
}