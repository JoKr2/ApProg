/*
 * AvrBoard.c
 *
 * Created: 26. 11. 2011 10:45:05
 *  Author: Fezoj
 */

#include "../Headers/Shared.h"
#include <avr/io.h>
#include <util/delay.h>

static uint8_t Reply[2];
static uint8_t RxBuff[RX_SIZE];
static uint8_t Invitation[] = "Avr Board"; 

extern void InitUart(void);
extern void SendBuffer(uint8_t[], uint8_t);
extern void ReceiveBuffer(uint8_t[], uint8_t); 

extern void SetMclr(uint8_t value); // 0x1X
extern void ClockControlBits(uint8_t value); // 0x2X
extern void ClockLowXTimes(uint8_t value); // 0x3X
extern void ClockByte(uint8_t value); // partially 0x5X
extern void PinByte(uint8_t *value); // partially 0x6X

// MCLR	0x04 (100)
// PGD	0x02 (010)
// PGC	0x01 (001)
	
int main()
{
	Initialize();
	while(1)
    {		
		ReceiveBuffer(RxBuff, 1);
		uint8_t command = RxBuff[0] & 0xF0;
		switch(command)
		{
			case 0x00:
				SendBuffer(RxBuff, 1);	
			break;
			case 0x10:
				SetMclr(RxBuff[0]);
				SendBuffer(Reply, 1);
			break;
			case 0x20:
				ClockControlBits(RxBuff[0]);
				SendBuffer(Reply, 1);
			break;
			case 0x30:
				ClockLowXTimes(RxBuff[0]);
				SendBuffer(Reply, 1);
			break;
			case 0x50:
				WriteIcsp(RxBuff[0] & 0x0F);				
			break;
			case 0x60:
				ReadIcsp(RxBuff[0] & 0x0F);
			break;
		}					
    }
}

void Initialize(void)
{
	Reply[0] = 0x01;
	Reply[1] = 0x00;
	
	DDRB = 0x07;	// output
	PORTB &= 0xF8;  // low	
		
	InitUart();
	SendBuffer(Invitation, 9);
}

void WriteIcsp(uint8_t length)
{
	if(length > 4)
	{
		SendBuffer(Reply + 1, 1);
		return;
	}
			
	ReceiveBuffer(RxBuff, length);
	for(uint8_t index = 0; index < length; index++)
	{
		ClockByte(RxBuff[index]);
	}	
	SendBuffer(Reply, 1);
}

void ReadIcsp(uint8_t length)
{
	if(length > 4)
	{
		SendBuffer(Reply + 1, 1);
		return;
	}
	
	for(uint8_t index = 0; index < length; index++)
	{
		PinByte(RxBuff + index);	
	}
	SendBuffer(RxBuff, length);
}
