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

\c #include <SDL/SDL_video.h>

0x00000000 constant SDL_SWSURFACE \ surface is in system memory
0x00000001 constant SDL_HWSURFACE \ surface is in video memory
0x00000004 constant SDL_ASYNCBLIT \ use async blits if possible

0x10000000 constant SDL_ANYFORMAT \ allow any videa depth/pixel format
0x20000000 constant SDL_HWPALETTE \ surface has exclusive palette 
0x40000000 constant SDL_DOUBLEBUF \ set up double-buffered video mode
0x80000000 constant SDL_FULLSCREEN \ surface is a full screen display

0x00000002 constant SDL_OPENGL    \ create an opengl rendering context
0x0000000a constant SDL_OPENGLBLIT \ create an opengl rendeing context for blit

0x00000010 constant SDL_RESIZABLE \ this video mode may be resized
0x00000020 constant SDL_NOFRAME   \ no window caption or edge frame

c-function c-SDL-SetVideoMode SDL_SetVideoMode n n n n -- a
	( width height bpp flags -- addr )

c-function SDL-getvideoinfo SDL_GetVideoInfo -- a
	( -- addr )

c-function c-SDL-FillRect SDL_FillRect a a n -- n

c-function c-SDL-Flip SDL_Flip a -- n

c-function c-SDL-BlitSurface SDL_BlitSurface a a a a -- n
	( src srcrect dst dstrect -- n )

c-function SDL-UpdateRect SDL_UpdateRect a n n n n -- void

: SDL-rect  ( -- )
	create 8 chars allot
;
: SDL-rect-x  ( a -- 'a ) ;
: SDL-rect-y  ( a -- 'a ) [ 2 chars ] literal + ;
: SDL-rect-w  ( a -- 'a ) [ 4 chars ] literal + ;
: SDL-rect-h  ( a -- 'a ) [ 6 chars ] literal + ;

: SDL-colour  ( -- )
	create 4 chars allot
;
: SDL-colour-r  ( a -- a )
;
: SDL-colour-g  ( a -- 'a )
	1 chars +
;
: SDL-colour-b  ( a -- 'a )
	2 chars +
;
: SDL-colour-unused
	3 chars +
;

: SDL-fillrect  ( a a n -- )
	c-SDL-FillRect 0= invert if s" SDL FillRect failing" sdlerror then ;
: SDL-setvideomode  ( n n n n -- a )
	c-sdl-setvideomode dup 0= if drop s" SDL set video mode failing" sdlerror
						      then ;
: SDL-flip  ( a -- )
	c-SDL-Flip 0= invert if s" SDL Flip failing" sdlerror then ;
: SDL-blitsurface  ( a a a a -- )
	c-SDL-BlitSurface 0= invert if s" SDL BlitSurface failing" sdlerror then ;

