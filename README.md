# OperatorTest

A small game about being the telephone switch operator at an evil corporation as a crisis breaks out of containment.

---

## References

- [Orion](feiss.be/games/play_orion) by Diego Goberna
- [Stories Untold](http://storiesuntoldgame.com/) by No Code, published by Devolver Digital
- [Quadrilateral Cowboy](http://blendogames.com/qc/) by Brendon Chung

---

## Art Specifications for Dakota

### Asset List

- CRT Monitor
	+ Call monitor = shows who is calling who and prompts for access codes.
	+ 4-5 line CRT monitor?
- Call Line Selector
	+ 4 light-up buttons that display if a line is being used (green glow) or not (red)
		- Each button needs to be labeled (1,2,3,4)
		- Each button has a correlating light that can change
	+ Click on the buttons to switch line is active
	+ 19-inch / 1U server rack hardware
- Call Scrambler
	+ Hardware for applying a type of call scrambling to a line
	+ Power Button, Line Selector dial, Type Selector dial
	+ 19-inch / 1U server rack hardware, but thicker than Call Line selector, goes on bottom
- Call Interceptor
	+ Kind of janky business phone intercepted to put a dial pad in between incoming and outgoing, which the player uses to punch in access codes that they either are given directly or find in the Codebook
	+ Speaker for hearing the call
- Codebook
	+ Manual the player is given by corporate overlords for special codewords that the player then looks up to connect special persons like the CEO

### Guidelines

- PSD files for Textures can be as high as 2K, finals probably more like 512x512
- Pretty low poly, but doesn't have to be so low as to forego any details (aiming for web release, but if not possible not the biggest deal)
- Buttons and Dials as separate objects so that they can be animated
- Emissive maps for LEDs under buttons and the CRT screen