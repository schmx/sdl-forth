\ Copyright (c) 2009 Marcus Eskilsson. All rights reserved.

\ Redistribution and use in source and binary forms, with or without
\ modification, are permitted provided that the following conditions
\ are met:
\ 1. Redistributions of source code must retain the above copyright
\    notice, this list of conditions and the following disclaimer.
\ 2. Redistributions in binary form must reproduce the above copyright
\    notice, this list of conditions and the following disclaimer in the
\    documentation and/or other materials provided with the distribution.

\ THIS SOFTWARE IS PROVIDED BY AUTHOR AND CONTRIBUTORS ``AS IS'' AND
\ ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
\ IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
\ ARE DISCLAIMED.  IN NO EVENT SHALL AUTHOR OR CONTRIBUTORS BE LIABLE
\ FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
\ DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS
\ OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
\ HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
\ LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
\ OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
\ SUCH DAMAGE.

s" SDL" add-lib
\c #include <SDL/SDL.h>

0x00000001 constant SDL_INIT_TIMER
0x00000010 constant SDL_INIT_AUDIO
0x00000020 constant SDL_INIT_VIDEO
0x00000100 constant SDL_INIT_CDROM
0x00000200 constant SDL_INIT_JOYSTICK
0x00100000 constant SDL_INIT_NOPARACHUTE
0x01000000 constant SDL_INIT_EVENTTHREAD
0x0000ffff constant SDL_INIT_EVERYTHING

c-function c-SDL-init SDL_Init n -- n   ( flags -- return value )
c-function c-SDL-WaitEvent SDL_WaitEvent a -- n

: sdl-init  ( flags -- )
	c-sdl-init 0= invert if
		s" SDL initialization failing " sdlerror 
	then
;
: SDL-WaitEvent  ( a -- )
	\ Store next event in a, or remove if 0.
	c-SDL-WaitEvent 0= if
		s" SDL WaitEvent failing " sdlerror
	then
;

