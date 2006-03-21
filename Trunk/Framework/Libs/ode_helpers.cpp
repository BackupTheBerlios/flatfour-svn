#include "ode/ode/src/objects.h"
#include <ode/ode.h>

extern "C" ODE_API void dBodyCopyPosition(dBodyID b, dReal* pos);

void dBodyCopyPosition(dBodyID b, dReal* pos)
{
	dAASSERT (b);
	dReal* src = b->posr.pos;
	pos[0] = src[0];
	pos[1] = src[1];
	pos[2] = src[2];
}
