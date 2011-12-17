/*
PROTOCOL:
0x0X -> Reply X
0x1X -> Set MCLR to X
0x2X -> Clock next 4 bits
0x3X -> Clock Low X times
0x4X -> Clock High X times
0x5X -> Clock next X bytes
0x6X -> Read next X bytes

4 + 24: SIX + NOP
5 + 4 + 24: FORCED SIX + NOP - only after enter to ICSP 
*/

#ifndef SHARED_H_
#define SHARED_H_

#define F_CPU	16000000
#define BAUD	57600

#define RX_SIZE 4

#endif /* SHARED_H_ */