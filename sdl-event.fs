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

0 constant SDL-Released
1 constant SDL-Pressed

enum SDL-EventType
SDL-EventType SDL-NoEvent
SDL-EventType SDL-ActiveEvent
SDL-EventType SDL-KeyDown
SDL-EventType SDL-KeyUp
SDL-EventType SDL-MouseMotion
SDL-EventType SDL-MouseButtonDown
SDL-EventType SDL-MouseButtonUp
\ SDL-EventType SDL-JoyAxisMotion
\ SDL-EventType SDL-JoyBallMotion
\ SDL-EventType SDL-JoyHatMotion
\ SDL-EventType SDL-JoyButtonDown
\ SDL-EventType SDL-JoyButtonUp
SDL-EventType SDL-Quit
SDL-EventType SDL-SysWMEvent
\ SDL-EventType SDL-EventReservedA
\ SDL-EventType SDL-EventReservedB
SDL-EventType SDL-VideoResize
SDL-EventType SDL-VideoExpose
\ SDL-EventType SDL-EventReserved2
\ SDL-EventType SDL-EventReserved3
\ SDL-EventType SDL-EventReserved4
\ SDL-EventType SDL-EventReserved5
\ SDL-EventType SDL-EventReserved6
\ SDL-EventType SDL-EventReserved7
24 constant SDL-UserEvent
32 constant SDL-NumEvents

: SDL-EventMask 1 swap lshift constant
;

SDL-ActiveEvent 		SDL-EventMask 		SDL-ActiveEventMask
SDL-KeyDown				SDL-EventMask 		SDL-KeyDownMask
SDL-KeyUp				SDL-EventMask 		SDL-KeyUpMask
	SDL-KeyUpMask SDL-KeyDownMask
						or constant 		SDL-KeyMask
SDL-MouseMotion			SDL-EventMask		SDL-MouseMotionMask
SDL-MouseButtonDown		SDL-EventMask		SDL-MouseButtonDownMask
SDL-MouseButtonUp		SDL-EventMask		SDL-MouseButtonUpMask
	SDL-MouseMotionMask SDL-MouseButtonUpMask SDL-MouseButtonDownMask
						or or constant		SDL-MouseMask
\ SDL-JoyAxisMotion		SDL-EventMask		SDL-JoyAxisMotionMask
\ SDL-JoyBallMotion		SDL-EventMask		SDL-JoyBallMotionMask
\ SDL-JoyHatMotion		SDL-EventMask		SDL-JoyHatMotionMask
\ SDL-JoyButtonDown		SDL-EventMask		SDL-JoyButtonDownMask
\ SDL-JoyButtonUp			SDL-EventMask		SDL-JoyButtonUpMask
\     SDL-JoyAxisMotionMask SDL-JoyBallMotionMask SDL-JoyHatMotionMask
\     SDL-JoyButtonDownMask SDL-JoyButtonUpMask
\                     or or or or constant	SDL-JoyEventMask
SDL-VideoResize			SDL-EventMask		SDL-VideoResizeMask
SDL-VideoExpose			SDL-EventMask		SDL-VideoExposeMask
SDL-Quit				SDL-EventMask		SDL-QuitMask
SDL-SysWMEvent			SDL-EventMask		SDL-SysWMEventMask
32						SDL-EventMask		SDL-AllEvents

: SDL-Event create 10 cells allot 
	\ space for SDL_Event union
;

: SDL-EventType@  ( a -- n )
	c@
;
: SDL-ActiveEvent-gain     ( a -- n )
	1 chars + c@
;
: SDL-ActiveEvent-state    ( a -- n )
	2 chars + c@
;
: SDL-KeyboardEvent-which  ( a -- n )
	1 chars + c@
;
: SDL-KeyboardEvent-state  ( a -- n )
	2 chars + c@
;
: SDL-KeyboardEvent-keysym ( a -- n )
	8 chars + 2c@
;
: SDL-KeyboardEvent-mod  ( a -- n )
	12 chars + 2c@
;
\ : SDL-MouseMotionEvent-which  ( a -- n )
\     1 chars + c@
\ ;
\ : SDL-MouseMotionEvent-state  ( a -- n )
\     2 chars + c@
\ ;
\ : SDL-MouseMotionEvent-x  ( a -- n )
\     3 chars + @
\ ;
\ : SDL-MouseMotionEvent-y  ( a -- n )
\     5 chars + @
\ ;
\ : SDL-MouseMotionEvent-xrel  ( a -- n )
\     7 chars + @
\ ;
\ : SDL-MouseMotionEvent-yrel  ( a -- n )
\     9 chars + @
\ ;

( TODO Wrap the SDL-Event madness so stuff is put
	   on the stack and not in some sdl-event 
	ie.	: stack-sdl-event )


