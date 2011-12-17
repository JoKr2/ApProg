/*
 * Icsp.c
 *
 * Created: 26. 11. 2011 10:46:08
 *  Author: Fezoj
 */
 
#include <avr/io.h>

#define nop() asm volatile("nop")

// MCLR	0x04 (100)
// PGD	0x02 (010)
// PGC	0x01 (001)

void SetMclr(uint8_t value)
{
	if((value & 0x0F))
		PORTB |= 0x04; // MCLR High
	else
		PORTB &= ~0x04; // MCLR Low
}

void ClockControlBits(uint8_t value)
{
	DDRB |= 0x02;
	uint8_t mask = 0x01;
	while (mask != 0x10)
	{
		if(value & mask)
			PORTB = (PORTB & ~0x01) | 0x02;
		else
			PORTB &= 0xFC;	
		mask <<= 1;
		nop();
		PORTB |= 0x01; //pop clock
		nop();			
	}
	PORTB &= ~0x03; // drop clock & PGD
}

void ClockLowXTimes(uint8_t value)
{
	DDRB |= 0x02;
	uint8_t length = value & 0x0F;
	while(length)
	{
		PORTB &= ~0x03; //PGD + PGC low
		length--;
		nop();
		PORTB |= 0x01;
		nop();
	}
	PORTB &= ~0x03;
}

void ClockByte(uint8_t value)
{
	DDRB |= 0x02; // switch PGD to output
	
	uint8_t mask = 0x01;
	while(mask)
	{
		if(value & mask)
			PORTB = (PORTB & ~0x01) | 0x02;
		else
			PORTB &= ~0x03;	
		mask <<= 1;
		nop();
		PORTB |= 0x01; //pop clock
		nop();
	}
	PORTB &= ~0x03;
}

void PinByte(uint8_t *value)
{
	DDRB &= ~0x02; // Switch PGD to input
	PORTB |= 0x02; // activate pull-up...
	
	uint8_t mask = 0x01;
	while(mask)
	{
		nop();
		PORTB |= 0x01; //pop clock
		nop();
		if(PINB & 0x02)
			*value |= mask;
		else
			*value &= ~mask;
		PORTB &= ~0x01; //drop clock
		mask <<= 1;	
	}
	PORTB &= ~0x02; //deactivate pull-up...
}