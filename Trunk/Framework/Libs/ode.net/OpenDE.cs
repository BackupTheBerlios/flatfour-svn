#region License
/*
 */ 
#endregion

using System;
using System.Runtime.InteropServices;

namespace OpenDE
{
	public class d
	{
#if dSINGLE
#else
		[DllImport("ode", EntryPoint = "dGeomDestroy")]
		public static extern void GeomDestroy (IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomSetData")]
		public static extern void GeomSetData (IntPtr geom, IntPtr data);

		[DllImport("ode", EntryPoint = "dGeomGetData")]
		public static extern IntPtr GeomGetData (IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomSetBody")]
		public static extern void GeomSetBody (IntPtr geom, IntPtr body);

		[DllImport("ode", EntryPoint = "dGeomGetBody")]
		public static extern IntPtr GeomGetBody (IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomSetPosition")]
		public static extern void GeomSetPosition (IntPtr geom, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dGeomSetRotation")]
		public static extern void GeomSetRotation (IntPtr geom, ref double R);

		[DllImport("ode", EntryPoint = "dGeomSetQuaternion")]
		public static extern void GeomSetQuaternion (IntPtr geom, ref double q);

//		out double  dGeomGetPosition (IntPtr geom);
//		out double  dGeomGetRotation (IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomGetQuaternion")]
		public static extern void GeomGetQuaternion (IntPtr geom, out double result);

		[DllImport("ode", EntryPoint = "dGeomGetAABB")]
		public static extern void GeomGetAABB (IntPtr geom, out double aabb);

		[DllImport("ode", EntryPoint = "dGeomIsSpace")]
		public static extern int GeomIsSpace (IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomGetSpace")]
		public static extern IntPtr GeomGetSpace (IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomGetClass")]
		public static extern int GeomGetClass (IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomSetCategoryBits")]
		public static extern void GeomSetCategoryBits (IntPtr geom, uint bits);

		[DllImport("ode", EntryPoint = "dGeomSetCollideBits")]
		public static extern void GeomSetCollideBits (IntPtr geom, uint bits);

		[DllImport("ode", EntryPoint = "dGeomGetCategoryBits")]
		public static extern uint GeomGetCategoryBits (IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomGetCollideBits")]
		public static extern uint GeomGetCollideBits (IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomEnable")]
		public static extern void GeomEnable (IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomDisable")]
		public static extern void GeomDisable (IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomIsEnabled")]
		public static extern int GeomIsEnabled (IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomSetOffsetPosition")]
		public static extern void GeomSetOffsetPosition (IntPtr geom, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dGeomSetOffsetRotation")]
		public static extern void GeomSetOffsetRotation (IntPtr geom, ref double R);

		[DllImport("ode", EntryPoint = "dGeomSetOffsetQuaternion")]
		public static extern void GeomSetOffsetQuaternion (IntPtr geom, ref double q);

		[DllImport("ode", EntryPoint = "dGeomSetOffsetWorldPosition")]
		public static extern void GeomSetOffsetWorldPosition (IntPtr geom, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dGeomSetOffsetWorldRotation")]
		public static extern void GeomSetOffsetWorldRotation (IntPtr geom, ref double R);

		[DllImport("ode", EntryPoint = "dGeomSetOffsetWorldQuaternion")]
		public static extern void GeomSetOffsetWorldQuaternion (IntPtr geom, ref double q);

		[DllImport("ode", EntryPoint = "dGeomClearOffse")]
		public static extern void GeomClearOffset(IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomIsOffse")]
		public static extern int GeomIsOffset(IntPtr geom);

//		out double  dGeomGetOffsetPosition (IntPtr geom);
//		out double  dGeomGetOffsetRotation (IntPtr geom);

		[DllImport("ode", EntryPoint = "dGeomGetOffsetQuaternion")]
		public static extern void GeomGetOffsetQuaternion (IntPtr geom, out double result);


//		int dCollide (IntPtr o1, IntPtr o2, int flags, dContactGeom *contact, int skip);
//		void dSpaceCollide (IntPtr space, void *data, dNearCallback *callback);
//		void dSpaceCollide2 (IntPtr o1, IntPtr o2, void *data, dNearCallback *callback);


		[DllImport("ode", EntryPoint = "dCreateSphere")]
		public static extern IntPtr CreateSphere (IntPtr space, double radius);

		[DllImport("ode", EntryPoint = "dGeomSphereSetRadius")]
		public static extern void GeomSphereSetRadius (IntPtr sphere, double radius);

		[DllImport("ode", EntryPoint = "dGeomSphereGetRadius")]
		public static extern double GeomSphereGetRadius (IntPtr sphere);

		[DllImport("ode", EntryPoint = "dGeomSpherePointDepth")]
		public static extern double GeomSpherePointDepth (IntPtr sphere, double x, double y, double z);


		[DllImport("ode", EntryPoint = "dCreateBox")]
		public static extern IntPtr CreateBox (IntPtr space, double lx, double ly, double lz);

		[DllImport("ode", EntryPoint = "dGeomBoxSetLengths")]
		public static extern void GeomBoxSetLengths (IntPtr box, double lx, double ly, double lz);

		[DllImport("ode", EntryPoint = "dGeomBoxGetLengths")]
		public static extern void GeomBoxGetLengths (IntPtr box, out double result);

		[DllImport("ode", EntryPoint = "dGeomBoxPointDepth")]
		public static extern double GeomBoxPointDepth (IntPtr box, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dCreatePlane")]
		public static extern IntPtr CreatePlane (IntPtr space, double a, double b, double c, double d);

		[DllImport("ode", EntryPoint = "dGeomPlaneSetParams")]
		public static extern void GeomPlaneSetParams (IntPtr plane, double a, double b, double c, double d);

		[DllImport("ode", EntryPoint = "dGeomPlaneGetParams")]
		public static extern void GeomPlaneGetParams (IntPtr plane, out double result);

		[DllImport("ode", EntryPoint = "dGeomPlanePointDepth")]
		public static extern double GeomPlanePointDepth (IntPtr plane, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dCreateCapsule")]
		public static extern IntPtr CreateCapsule (IntPtr space, double radius, double length);

		[DllImport("ode", EntryPoint = "dGeomCapsuleSetParams")]
		public static extern void GeomCapsuleSetParams (IntPtr ccylinder, double radius, double length);

		[DllImport("ode", EntryPoint = "dGeomCapsuleGetParams")]
		public static extern void GeomCapsuleGetParams (IntPtr ccylinder, out double radius, out double length);

		[DllImport("ode", EntryPoint = "dGeomCapsulePointDepth")]
		public static extern double GeomCapsulePointDepth (IntPtr ccylinder, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dCreateCylinder")]
		public static extern IntPtr CreateCylinder (IntPtr space, double radius, double length);

		[DllImport("ode", EntryPoint = "dGeomCylinderSetParams")]
		public static extern void GeomCylinderSetParams (IntPtr cylinder, double radius, double length);

		[DllImport("ode", EntryPoint = "dGeomCylinderGetParams")]
		public static extern void GeomCylinderGetParams (IntPtr cylinder, out double radius, out double length);

		[DllImport("ode", EntryPoint = "dCreateRay")]
		public static extern IntPtr CreateRay (IntPtr space, double length);

		[DllImport("ode", EntryPoint = "dGeomRaySetLength")]
		public static extern void GeomRaySetLength (IntPtr ray, double length);

		[DllImport("ode", EntryPoint = "dGeomRayGetLength")]
		public static extern double GeomRayGetLength (IntPtr ray);

		[DllImport("ode", EntryPoint = "dGeomRaySet")]
		public static extern void GeomRaySet (IntPtr ray, double px, double py, double pz, double dx, double dy, double dz);

		[DllImport("ode", EntryPoint = "dGeomRayGet")]
		public static extern void GeomRayGet (IntPtr ray, out double start, out double dir);

		[DllImport("ode", EntryPoint = "dGeomRaySetParams")]
		public static extern void GeomRaySetParams (IntPtr g, int FirstContact, int BackfaceCull);

		[DllImport("ode", EntryPoint = "dGeomRayGetParams")]
		public static extern void GeomRayGetParams (IntPtr g, out int FirstContact, out int BackfaceCull);

		[DllImport("ode", EntryPoint = "dGeomRaySetClosestHit")]
		public static extern void GeomRaySetClosestHit (IntPtr g, int closestHit);

		[DllImport("ode", EntryPoint = "dGeomRayGetClosestHit")]
		public static extern int GeomRayGetClosestHit (IntPtr g);

		[DllImport("ode", EntryPoint = "dCreateGeomTransform")]
		public static extern IntPtr CreateGeomTransform (IntPtr space);

		[DllImport("ode", EntryPoint = "dGeomTransformSetGeom")]
		public static extern void GeomTransformSetGeom (IntPtr g, IntPtr obj);

		[DllImport("ode", EntryPoint = "dGeomTransformGetGeom")]
		public static extern IntPtr GeomTransformGetGeom (IntPtr g);

		[DllImport("ode", EntryPoint = "dGeomTransformSetCleanup")]
		public static extern void GeomTransformSetCleanup (IntPtr g, int mode);

		[DllImport("ode", EntryPoint = "dGeomTransformGetCleanup")]
		public static extern int GeomTransformGetCleanup (IntPtr g);

		[DllImport("ode", EntryPoint = "dGeomTransformSetInfo")]
		public static extern void GeomTransformSetInfo (IntPtr g, int mode);

		[DllImport("ode", EntryPoint = "dGeomTransformGetInfo")]
		public static extern int GeomTransformGetInfo (IntPtr g);

		[DllImport("ode", EntryPoint = "dClosestLineSegmentPoints")]
		public static extern void ClosestLineSegmentPoints (ref double a1, ref double a2, ref double b1, ref double b2, out double cp1, out double cp2);

		[DllImport("ode", EntryPoint = "dBoxTouchesBox")]
		public static extern int BoxTouchesBox (ref double _p1, ref double R1, ref double side1, ref double _p2, ref double R2, ref double side2);

//		int dBoxBox (ref double p1, ref double R1, ref double side1, ref double p2, ref double R2, ref double side2, out double normal, out double depth, out int return_code, int maxc, dContactGeom *contact, int skip);

		[DllImport("ode", EntryPoint = "dInfiniteAABB")]
		public static extern void InfiniteAABB (IntPtr geom, out double aabb);

		[DllImport("ode", EntryPoint = "dCloseOD")]
		public static extern void CloseODE();

//		int dCreateGeomClass (const dGeomClass *classptr);

		[DllImport("ode", EntryPoint = "dGeomGetClassData")]
		public static extern IntPtr GeomGetClassData (IntPtr geom);

		[DllImport("ode", EntryPoint = "dCreateGeom")]
		public static extern IntPtr CreateGeom (int classnum);

		[DllImport("ode", EntryPoint = "dSimpleSpaceCreate")]
		public static extern IntPtr SimpleSpaceCreate (IntPtr space);

		[DllImport("ode", EntryPoint = "dHashSpaceCreate")]
		public static extern IntPtr HashSpaceCreate (IntPtr space);

		[DllImport("ode", EntryPoint = "dQuadTreeSpaceCreate")]
		public static extern IntPtr QuadTreeSpaceCreate (IntPtr space, ref double Center, ref double Extents, int Depth);

		[DllImport("ode", EntryPoint = "dSpaceDestroy")]
		public static extern void SpaceDestroy (IntPtr space);

		[DllImport("ode", EntryPoint = "dHashSpaceSetLevels")]
		public static extern void HashSpaceSetLevels (IntPtr space, int minlevel, int maxlevel);

		[DllImport("ode", EntryPoint = "dHashSpaceGetLevels")]
		public static extern void HashSpaceGetLevels (IntPtr space, out int minlevel, out int maxlevel);

		[DllImport("ode", EntryPoint = "dSpaceSetCleanup")]
		public static extern void SpaceSetCleanup (IntPtr space, int mode);

		[DllImport("ode", EntryPoint = "dSpaceGetCleanup")]
		public static extern int SpaceGetCleanup (IntPtr space);

		[DllImport("ode", EntryPoint = "dSpaceAdd")]
		public static extern void SpaceAdd (IntPtr space, IntPtr geom);

		[DllImport("ode", EntryPoint = "dSpaceRemove")]
		public static extern void SpaceRemove (IntPtr space, IntPtr geom);

		[DllImport("ode", EntryPoint = "dSpaceQuery")]
		public static extern int SpaceQuery (IntPtr space, IntPtr geom);

		[DllImport("ode", EntryPoint = "dSpaceClean")]
		public static extern void SpaceClean (IntPtr space);

		[DllImport("ode", EntryPoint = "dSpaceGetNumGeoms")]
		public static extern int SpaceGetNumGeoms (IntPtr space);

		[DllImport("ode", EntryPoint = "dSpaceGetGeom")]
		public static extern IntPtr SpaceGetGeom (IntPtr space, int i);

		[DllImport("ode", EntryPoint = "dGeomTriMeshDataCreate")]
		public static extern IntPtr GeomTriMeshDataCreate();

		[DllImport("ode", EntryPoint = "dGeomTriMeshDataDestroy")]
		public static extern void GeomTriMeshDataDestroy(IntPtr g);

		[DllImport("ode", EntryPoint = "dGeomTriMeshDataSet")]
		public static extern void GeomTriMeshDataSet(IntPtr g, int data_id, IntPtr in_data);

		[DllImport("ode", EntryPoint = "dGeomTriMeshDataGet")]
		public static extern IntPtr GeomTriMeshDataGet(IntPtr g, int data_id);

//		void dGeomTriMeshDataBuildSingle(IntPtr g, const void* Vertices, int VertexStride, int VertexCount, const void* Indices, int IndexCount, int TriStride);
//		void dGeomTriMeshDataBuildSingle1(IntPtr g, const void* Vertices, int VertexStride, int VertexCount, const void* Indices, int IndexCount, int TriStride, const void* Normals);
//		void dGeomTriMeshDataBuildDouble(IntPtr g, const void* Vertices,  int VertexStride, int VertexCount, const void* Indices, int IndexCount, int TriStride);
//		void dGeomTriMeshDataBuildDouble1(IntPtr g, const void* Vertices,  int VertexStride, int VertexCount, const void* Indices, int IndexCount, int TriStride, const void* Normals);

//		void dGeomTriMeshDataBuildSimple(IntPtr g, const double* Vertices, int VertexCount, const int* Indices, int IndexCount);
//		void dGeomTriMeshDataBuildSimple1(IntPtr g, const double* Vertices, int VertexCount, const int* Indices, int IndexCount, const int* Normals);

		[DllImport("ode", EntryPoint = "dGeomTriMeshDataPreprocess")]
		public static extern void GeomTriMeshDataPreprocess(IntPtr g);

//		void dGeomTriMeshDataGetBuffer(IntPtr g, unsigned char** buf, int* bufLen);
//		void dGeomTriMeshDataSetBuffer(IntPtr g, unsigned char* buf);

//		void dGeomTriMeshSetCallback(IntPtr g, dTriCallback* Callback);
//		dTriCallback* dGeomTriMeshGetCallback(IntPtr g);

//		void dGeomTriMeshSetArrayCallback(IntPtr g, dTriArrayCallback* ArrayCallback);
//		dTriArrayCallback* dGeomTriMeshGetArrayCallback(IntPtr g);

//		void dGeomTriMeshSetRayCallback(IntPtr g, dTriRayCallback* Callback);
//		dTriRayCallback* dGeomTriMeshGetRayCallback(IntPtr g);

//		IntPtr dCreateTriMesh(IntPtr space, IntPtr Data, dTriCallback* Callback, dTriArrayCallback* ArrayCallback, dTriRayCallback* RayCallback);

		[DllImport("ode", EntryPoint = "dGeomTriMeshSetData")]
		public static extern void GeomTriMeshSetData (IntPtr g, IntPtr Data);

		[DllImport("ode", EntryPoint = "dGeomTriMeshGetData")]
		public static extern IntPtr GeomTriMeshGetData (IntPtr g);

		[DllImport("ode", EntryPoint = "dGeomTriMeshEnableTC")]
		public static extern void GeomTriMeshEnableTC (IntPtr g, int geomClass, int enable);

		[DllImport("ode", EntryPoint = "dGeomTriMeshIsTCEnabled")]
		public static extern int GeomTriMeshIsTCEnabled (IntPtr g, int geomClass);

		[DllImport("ode", EntryPoint = "dGeomTriMeshClearTCCache")]
		public static extern void GeomTriMeshClearTCCache (IntPtr g);

		[DllImport("ode", EntryPoint = "dGeomTriMeshGetTriMeshDataID")]
		public static extern IntPtr GeomTriMeshGetTriMeshDataID (IntPtr g);

		[DllImport("ode", EntryPoint = "dGeomTriMeshGetTriangle")]
		public static extern void GeomTriMeshGetTriangle(IntPtr g, int Index, out double v0, out double v1, out double v2);

		[DllImport("ode", EntryPoint = "dGeomTriMeshGetPoint")]
		public static extern void GeomTriMeshGetPoint(IntPtr g, int Index, double u, double v, out double Out);

		[DllImport("ode", EntryPoint = "dGeomTriMeshGetTriangleCount")]
		public static extern int GeomTriMeshGetTriangleCount (IntPtr g);

		[DllImport("ode", EntryPoint = "dGeomTriMeshDataUpdate")]
		public static extern void GeomTriMeshDataUpdate (IntPtr g);

//		void dWorldExportDIF (IntPtr w, FILE *file, const char *world_name);

		[DllImport("ode", EntryPoint = "dMassSetParameters")]
		public static extern void MassSetParameters (IntPtr mass, double themass, double cgx, double cgy, double cgz, double I11, double I22, double I33, double I12, double I13, double I23);

		[DllImport("ode", EntryPoint = "dMassSetSphere")]
		public static extern void MassSetSphere (IntPtr mass, double density, double radius);

		[DllImport("ode", EntryPoint = "dMassSetSphereTotal")]
		public static extern void MassSetSphereTotal (IntPtr mass, double total_mass, double radius);

		[DllImport("ode", EntryPoint = "dMassSetCapsule")]
		public static extern void MassSetCapsule (IntPtr mass, double density, int direction, double radius, double length);

		[DllImport("ode", EntryPoint = "dMassSetCapsuleTotal")]
		public static extern void MassSetCapsuleTotal (IntPtr mass, double total_mass, int direction, double radius, double length);

		[DllImport("ode", EntryPoint = "dMassSetCylinder")]
		public static extern void MassSetCylinder (IntPtr mass, double density, int direction, double radius, double length);

		[DllImport("ode", EntryPoint = "dMassSetCylinderTotal")]
		public static extern void MassSetCylinderTotal (IntPtr mass, double total_mass, int direction, double radius, double length);

		[DllImport("ode", EntryPoint = "dMassSetBox")]
		public static extern void MassSetBox (IntPtr mass, double density, double lx, double ly, double lz); 

		[DllImport("ode", EntryPoint = "dMassSetBoxTotal")]
		public static extern void MassSetBoxTotal (IntPtr mass, double total_mass, double lx, double ly, double lz);

		[DllImport("ode", EntryPoint = "dMassAdjust")]
		public static extern void MassAdjust (IntPtr mass, double newmass);

		[DllImport("ode", EntryPoint = "dMassTranslate")]
		public static extern void MassTranslate (IntPtr mass, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dMassRotate")]
		public static extern void MassRotate (IntPtr mass, ref double R);

		[DllImport("ode", EntryPoint = "dMassAdd")]
		public static extern void MassAdd (IntPtr a, IntPtr b);

		[DllImport("ode", EntryPoint = "dSetZero")]
		public static extern void SetZero (out double a, int n);

		[DllImport("ode", EntryPoint = "dSetValue")]
		public static extern void SetValue (out double a, int n, double value);

		[DllImport("ode", EntryPoint = "dDot")]
		public static extern double Dot (out double a, out double b, int n);

//		void dMultiply0(out double A, out double B, out double C, int p,int q,int r);
//		void dMultiply1(out double A, out double B, out double C, int p, int q, int r);
//		void dMultiply2(out double A, out double B, out double C, int p, int q, int r);

//		int dFactorCholesky (double *A, int n);
//		void dSolveCholesky (out double L, double *b, int n);
//		int dInvertPDMatrix (out double A, double *Ainv, int n);
//		int dIsPositiveDefinite (out double A, int n);
//		void dFactorLDLT (double *A, double *d, int n, int nskip);
//		void dSolveL1 (out double L, double *b, int n, int nskip);
//		void dSolveL1T (out double L, double *b, int n, int nskip);
//		void dVectorScale (double *a, out double d, int n);
//		void dSolveLDLT (out double L, out double d, double *b, int n, int nskip);
//		void dLDLTAddTL (double *L, double *d, out double a, int n, int nskip);
//		void dLDLTRemove (double **A, const int *p, double *L, double *d, int n1, int n2, int r, int nskip);
//		void dRemoveRowCol (double *A, int n, int nskip, int r);

		[DllImport("ode", EntryPoint = "dWorldCreate")]
		public static extern IntPtr WorldCreate();

		[DllImport("ode", EntryPoint = "dWorldDestroy")]
		public static extern void WorldDestroy (IntPtr world);

		[DllImport("ode", EntryPoint = "dWorldSetGravity")]
		public static extern void WorldSetGravity (IntPtr world, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dWorldGetGravity")]
		public static extern void WorldGetGravity (IntPtr world, out double gravity);

		[DllImport("ode", EntryPoint = "dWorldSetERP")]
		public static extern void WorldSetERP (IntPtr world, double erp);

		[DllImport("ode", EntryPoint = "dWorldGetERP")]
		public static extern double WorldGetERP (IntPtr world);

		[DllImport("ode", EntryPoint = "dWorldSetCFM")]
		public static extern void WorldSetCFM (IntPtr world, double cfm);

		[DllImport("ode", EntryPoint = "dWorldGetCFM")]
		public static extern double WorldGetCFM (IntPtr world);

		[DllImport("ode", EntryPoint = "dWorldStep")]
		public static extern void WorldStep (IntPtr world, double stepsize);

		[DllImport("ode", EntryPoint = "dWorldImpulseToForce")]
		public static extern void WorldImpulseToForce (IntPtr world, double stepsize, double ix, double iy, double iz, out double force);

		[DllImport("ode", EntryPoint = "dWorldQuickStep")]
		public static extern void WorldQuickStep (IntPtr w, double stepsize);

		[DllImport("ode", EntryPoint = "dWorldSetQuickStepNumIterations")]
		public static extern void WorldSetQuickStepNumIterations (IntPtr world, int num);

		[DllImport("ode", EntryPoint = "dWorldGetQuickStepNumIterations")]
		public static extern int WorldGetQuickStepNumIterations (IntPtr world);

		[DllImport("ode", EntryPoint = "dWorldSetQuickStepW")]
		public static extern void WorldSetQuickStepW (IntPtr world, double param);

		[DllImport("ode", EntryPoint = "dWorldGetQuickStepW")]
		public static extern double WorldGetQuickStepW (IntPtr world);

		[DllImport("ode", EntryPoint = "dWorldSetContactMaxCorrectingVel")]
		public static extern void WorldSetContactMaxCorrectingVel (IntPtr world, double vel);

		[DllImport("ode", EntryPoint = "dWorldGetContactMaxCorrectingVel")]
		public static extern double WorldGetContactMaxCorrectingVel (IntPtr world);

		[DllImport("ode", EntryPoint = "dWorldSetContactSurfaceLayer")]
		public static extern void WorldSetContactSurfaceLayer (IntPtr world, double depth);

		[DllImport("ode", EntryPoint = "dWorldGetContactSurfaceLayer")]
		public static extern double WorldGetContactSurfaceLayer (IntPtr world);

		[DllImport("ode", EntryPoint = "dWorldStepFast")]
		public static extern void WorldStepFast1(IntPtr world, double stepsize, int maxiterations);

		[DllImport("ode", EntryPoint = "dWorldSetAutoEnableDepthSF")]
		public static extern void WorldSetAutoEnableDepthSF1(IntPtr world, int autoEnableDepth);

		[DllImport("ode", EntryPoint = "dWorldGetAutoEnableDepthSF")]
		public static extern int WorldGetAutoEnableDepthSF1(IntPtr world);

		[DllImport("ode", EntryPoint = "dWorldGetAutoDisableLinearThreshold")]
		public static extern double WorldGetAutoDisableLinearThreshold (IntPtr world);

		[DllImport("ode", EntryPoint = "dWorldSetAutoDisableLinearThreshold")]
		public static extern void  WorldSetAutoDisableLinearThreshold (IntPtr world, double linear_threshold);

		[DllImport("ode", EntryPoint = "dWorldGetAutoDisableAngularThreshold")]
		public static extern double WorldGetAutoDisableAngularThreshold (IntPtr world);

		[DllImport("ode", EntryPoint = "dWorldSetAutoDisableAngularThreshold")]
		public static extern void  WorldSetAutoDisableAngularThreshold (IntPtr world, double angular_threshold);

		[DllImport("ode", EntryPoint = "dWorldGetAutoDisableSteps")]
		public static extern int   WorldGetAutoDisableSteps (IntPtr world);

		[DllImport("ode", EntryPoint = "dWorldSetAutoDisableSteps")]
		public static extern void  WorldSetAutoDisableSteps (IntPtr world, int steps);

		[DllImport("ode", EntryPoint = "dWorldGetAutoDisableTime")]
		public static extern double WorldGetAutoDisableTime (IntPtr world);

		[DllImport("ode", EntryPoint = "dWorldSetAutoDisableTime")]
		public static extern void  WorldSetAutoDisableTime (IntPtr world, double time);

		[DllImport("ode", EntryPoint = "dWorldGetAutoDisableFlag")]
		public static extern int   WorldGetAutoDisableFlag (IntPtr world);

		[DllImport("ode", EntryPoint = "dWorldSetAutoDisableFlag")]
		public static extern void  WorldSetAutoDisableFlag (IntPtr world, int do_auto_disable);

		[DllImport("ode", EntryPoint = "double")]
		public static extern double dBodyGetAutoDisableLinearThreshold (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodySetAutoDisableLinearThreshold")]
		public static extern void BodySetAutoDisableLinearThreshold (IntPtr body, double linear_threshold);

		[DllImport("ode", EntryPoint = "dBodyGetAutoDisableAngularThreshold")]
		public static extern double BodyGetAutoDisableAngularThreshold (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodySetAutoDisableAngularThreshold")]
		public static extern void  BodySetAutoDisableAngularThreshold (IntPtr body, double angular_threshold);

		[DllImport("ode", EntryPoint = "dBodyGetAutoDisableSteps")]
		public static extern int   BodyGetAutoDisableSteps (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodySetAutoDisableSteps")]
		public static extern void  BodySetAutoDisableSteps (IntPtr body, int steps);

		[DllImport("ode", EntryPoint = "dBodyGetAutoDisableTime")]
		public static extern double BodyGetAutoDisableTime (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodySetAutoDisableTime")]
		public static extern void  BodySetAutoDisableTime (IntPtr body, double time);

		[DllImport("ode", EntryPoint = "dBodyGetAutoDisableFlag")]
		public static extern int   BodyGetAutoDisableFlag (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodySetAutoDisableFlag")]
		public static extern void  BodySetAutoDisableFlag (IntPtr body, int do_auto_disable);

		[DllImport("ode", EntryPoint = "dBodySetAutoDisableDefaults")]
		public static extern void  BodySetAutoDisableDefaults (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodyCreate")]
		public static extern IntPtr BodyCreate (IntPtr world);

		[DllImport("ode", EntryPoint = "dBodyDestroy")]
		public static extern void BodyDestroy (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodySetData")]
		public static extern void  BodySetData (IntPtr body, IntPtr data);

		[DllImport("ode", EntryPoint = "dBodyGetData")]
		public static extern IntPtr BodyGetData (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodySetPosition  ")]
		public static extern void BodySetPosition   (IntPtr body, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dBodySetRotation  ")]
		public static extern void BodySetRotation   (IntPtr body, ref double R);

		[DllImport("ode", EntryPoint = "dBodySetQuaternion")]
		public static extern void BodySetQuaternion (IntPtr body, ref double q);

		[DllImport("ode", EntryPoint = "dBodySetLinearVel ")]
		public static extern void BodySetLinearVel  (IntPtr body, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dBodySetAngularVel")]
		public static extern void BodySetAngularVel (IntPtr body, double x, double y, double z);

//		out double  dBodyGetPosition   (IntPtr body);
//		out double  dBodyGetRotation   (IntPtr body);	/* ptr to 4x3 rot matrix */
//		out double  dBodyGetQuaternion (IntPtr body);
//		out double  dBodyGetLinearVel  (IntPtr body);
//		out double  dBodyGetAngularVel (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodySetMass")]
		public static extern void BodySetMass (IntPtr body, IntPtr mass);

//		void dBodyGetMass (IntPtr body, dMass *mass);

		[DllImport("ode", EntryPoint = "dBodyAddForce")]
		public static extern void BodyAddForce(IntPtr body, double fx, double fy, double fz);

		[DllImport("ode", EntryPoint = "dBodyAddTorque")]
		public static extern void BodyAddTorque(IntPtr body, double fx, double fy, double fz);

		[DllImport("ode", EntryPoint = "dBodyAddRelForce")]
		public static extern void BodyAddRelForce(IntPtr body, double fx, double fy, double fz);

		[DllImport("ode", EntryPoint = "dBodyAddRelTorque")]
		public static extern void BodyAddRelTorque(IntPtr body, double fx, double fy, double fz);

		[DllImport("ode", EntryPoint = "dBodyAddForceAtPos")]
		public static extern void BodyAddForceAtPos (IntPtr body, double fx, double fy, double fz, double px, double py, double pz);

		[DllImport("ode", EntryPoint = "dBodyAddForceAtRelPos")]
		public static extern void BodyAddForceAtRelPos (IntPtr body, double fx, double fy, double fz, double px, double py, double pz);

		[DllImport("ode", EntryPoint = "dBodyAddRelForceAtPos")]
		public static extern void BodyAddRelForceAtPos (IntPtr body, double fx, double fy, double fz, double px, double py, double pz);

		[DllImport("ode", EntryPoint = "dBodyAddRelForceAtRelPos")]
		public static extern void BodyAddRelForceAtRelPos (IntPtr body, double fx, double fy, double fz, double px, double py, double pz);

//		out double  dBodyGetForce   (IntPtr body);
//		out double  dBodyGetTorque  (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodySetForce")]
		public static extern void BodySetForce (IntPtr b, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dBodySetTorque")]
		public static extern void BodySetTorque (IntPtr b, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dBodyGetRelPointPos")]
		public static extern void BodyGetRelPointPos (IntPtr body, double px, double py, double pz, out double result);

		[DllImport("ode", EntryPoint = "dBodyGetRelPointVel")]
		public static extern void BodyGetRelPointVel (IntPtr body, double px, double py, double pz, out double result);

		[DllImport("ode", EntryPoint = "dBodyGetPointVel")]
		public static extern void BodyGetPointVel (IntPtr body, double px, double py, double pz, out double result);

		[DllImport("ode", EntryPoint = "dBodyGetPosRelPoint")]
		public static extern void BodyGetPosRelPoint (IntPtr body, double px, double py, double pz, out double result);

		[DllImport("ode", EntryPoint = "dBodyVectorToWorld")]
		public static extern void BodyVectorToWorld (IntPtr body, double px, double py, double pz, out double result);

		[DllImport("ode", EntryPoint = "dBodyVectorFromWorld")]
		public static extern void BodyVectorFromWorld (IntPtr body, double px, double py, double pz, out double result);

		[DllImport("ode", EntryPoint = "dBodySetFiniteRotationMode")]
		public static extern void BodySetFiniteRotationMode (IntPtr body, int mode);

		[DllImport("ode", EntryPoint = "dBodySetFiniteRotationAxis")]
		public static extern void BodySetFiniteRotationAxis (IntPtr body, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dBodyGetFiniteRotationMode")]
		public static extern int BodyGetFiniteRotationMode (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodyGetFiniteRotationAxis")]
		public static extern void BodyGetFiniteRotationAxis (IntPtr body, out double result);

		[DllImport("ode", EntryPoint = "dBodyGetNumJoints")]
		public static extern int BodyGetNumJoints (IntPtr b);

		[DllImport("ode", EntryPoint = "dBodyGetJoint")]
		public static extern IntPtr BodyGetJoint (IntPtr body, int index);

		[DllImport("ode", EntryPoint = "dBodyEnable")]
		public static extern void BodyEnable (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodyDisable")]
		public static extern void BodyDisable (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodyIsEnabled")]
		public static extern int BodyIsEnabled (IntPtr body);

		[DllImport("ode", EntryPoint = "dBodySetGravityMode")]
		public static extern void BodySetGravityMode (IntPtr b, int mode);

		[DllImport("ode", EntryPoint = "dBodyGetGravityMode")]
		public static extern int BodyGetGravityMode (IntPtr b);

		[DllImport("ode", EntryPoint = "dJointCreateBall")]
		public static extern IntPtr JointCreateBall (IntPtr world, IntPtr group);

		[DllImport("ode", EntryPoint = "dJointCreateHinge")]
		public static extern IntPtr JointCreateHinge (IntPtr world, IntPtr group);

		[DllImport("ode", EntryPoint = "dJointCreateSlider")]
		public static extern IntPtr JointCreateSlider (IntPtr world, IntPtr group);

//		IntPtr dJointCreateContact (IntPtr world, IntPtr group, const dContact *);

		[DllImport("ode", EntryPoint = "dJointCreateHinge2")]
		public static extern IntPtr JointCreateHinge2 (IntPtr world, IntPtr group);

		[DllImport("ode", EntryPoint = "dJointCreateUniversal")]
		public static extern IntPtr JointCreateUniversal (IntPtr world, IntPtr group);

		[DllImport("ode", EntryPoint = "dJointCreateFixed")]
		public static extern IntPtr JointCreateFixed (IntPtr world, IntPtr group);

		[DllImport("ode", EntryPoint = "dJointCreateNull")]
		public static extern IntPtr JointCreateNull (IntPtr world, IntPtr group);

		[DllImport("ode", EntryPoint = "dJointCreateAMotor")]
		public static extern IntPtr JointCreateAMotor (IntPtr world, IntPtr group);

		[DllImport("ode", EntryPoint = "dJointCreateLMotor")]
		public static extern IntPtr JointCreateLMotor (IntPtr world, IntPtr group);

		[DllImport("ode", EntryPoint = "dJointDestroy")]
		public static extern void JointDestroy (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGroupCreate")]
		public static extern IntPtr JointGroupCreate (int max_size);

		[DllImport("ode", EntryPoint = "dJointGroupDestroy")]
		public static extern void JointGroupDestroy (IntPtr group);

		[DllImport("ode", EntryPoint = "dJointGroupEmpty")]
		public static extern void JointGroupEmpty (IntPtr group);

		[DllImport("ode", EntryPoint = "dJointAttach")]
		public static extern void JointAttach (IntPtr joint, IntPtr body1, IntPtr body2);

		[DllImport("ode", EntryPoint = "dJointSetData")]
		public static extern void JointSetData (IntPtr joint, IntPtr data);

		[DllImport("ode", EntryPoint = "dJointGetData")]
		public static extern IntPtr JointGetData (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetType")]
		public static extern int JointGetType (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetBody")]
		public static extern IntPtr JointGetBody (IntPtr joint, int index);

//		void dJointSetFeedback (IntPtr joint, dJointFeedback *);
//		dJointFeedback *dJointGetFeedback (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointSetBallAnchor")]
		public static extern void JointSetBallAnchor (IntPtr joint, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dJointSetBallAnchor2")]
		public static extern void JointSetBallAnchor2 (IntPtr joint, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dJointSetHingeAnchor")]
		public static extern void JointSetHingeAnchor (IntPtr joint, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dJointSetHingeAnchorDelta")]
		public static extern void JointSetHingeAnchorDelta (IntPtr joint, double x, double y, double z, double ax, double ay, double az);

		[DllImport("ode", EntryPoint = "dJointSetHingeAxis")]
		public static extern void JointSetHingeAxis (IntPtr joint, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dJointSetHingeParam")]
		public static extern void JointSetHingeParam (IntPtr joint, int parameter, double value);

		[DllImport("ode", EntryPoint = "dJointAddHingeTorqu")]
		public static extern void JointAddHingeTorque(IntPtr joint, double torque);

		[DllImport("ode", EntryPoint = "dJointSetSliderAxis")]
		public static extern void JointSetSliderAxis (IntPtr joint, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dJointSetSliderAxisDelta")]
		public static extern void JointSetSliderAxisDelta (IntPtr joint, double x, double y, double z, double ax, double ay, double az);

		[DllImport("ode", EntryPoint = "dJointSetSliderParam")]
		public static extern void JointSetSliderParam (IntPtr joint, int parameter, double value);

		[DllImport("ode", EntryPoint = "dJointAddSliderForc")]
		public static extern void JointAddSliderForce(IntPtr joint, double force);

		[DllImport("ode", EntryPoint = "dJointSetHinge2Anchor")]
		public static extern void JointSetHinge2Anchor (IntPtr joint, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dJointSetHinge2Axis1")]
		public static extern void JointSetHinge2Axis1 (IntPtr joint, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dJointSetHinge2Axis2")]
		public static extern void JointSetHinge2Axis2 (IntPtr joint, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dJointSetHinge2Param")]
		public static extern void JointSetHinge2Param (IntPtr joint, int parameter, double value);

		[DllImport("ode", EntryPoint = "dJointAddHinge2Torque")]
		public static extern void JointAddHinge2Torques(IntPtr joint, double torque1, double torque2);

		[DllImport("ode", EntryPoint = "dJointSetUniversalAnchor")]
		public static extern void JointSetUniversalAnchor (IntPtr joint, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dJointSetUniversalAxis1")]
		public static extern void JointSetUniversalAxis1 (IntPtr joint, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dJointSetUniversalAxis2")]
		public static extern void JointSetUniversalAxis2 (IntPtr joint, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dJointSetUniversalParam")]
		public static extern void JointSetUniversalParam (IntPtr joint, int parameter, double value);

		[DllImport("ode", EntryPoint = "dJointAddUniversalTorques")]
		public static extern void JointAddUniversalTorques (IntPtr joint, double torque1, double torque2);

		[DllImport("ode", EntryPoint = "dJointSetFixed")]
		public static extern void JointSetFixed (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointSetAMotorNumAxes")]
		public static extern void JointSetAMotorNumAxes (IntPtr joint, int num);

		[DllImport("ode", EntryPoint = "dJointSetAMotorAxis")]
		public static extern void JointSetAMotorAxis (IntPtr joint, int anum, int rel, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dJointSetAMotorAngle")]
		public static extern void JointSetAMotorAngle (IntPtr joint, int anum, double angle);

		[DllImport("ode", EntryPoint = "dJointSetAMotorParam")]
		public static extern void JointSetAMotorParam (IntPtr joint, int parameter, double value);

		[DllImport("ode", EntryPoint = "dJointSetAMotorMode")]
		public static extern void JointSetAMotorMode (IntPtr joint, int mode);

		[DllImport("ode", EntryPoint = "dJointAddAMotorTorques")]
		public static extern void JointAddAMotorTorques (IntPtr joint, double torque1, double torque2, double torque3);

		[DllImport("ode", EntryPoint = "dJointSetLMotorNumAxes")]
		public static extern void JointSetLMotorNumAxes (IntPtr joint, int num);

		[DllImport("ode", EntryPoint = "dJointSetLMotorAxis")]
		public static extern void JointSetLMotorAxis (IntPtr joint, int anum, int rel, double x, double y, double z);

		[DllImport("ode", EntryPoint = "dJointSetLMotorParam")]
		public static extern void JointSetLMotorParam (IntPtr joint, int parameter, double value);

		[DllImport("ode", EntryPoint = "dJointGetBallAnchor")]
		public static extern void JointGetBallAnchor (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetBallAnchor2")]
		public static extern void JointGetBallAnchor2 (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetHingeAnchor")]
		public static extern void JointGetHingeAnchor (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetHingeAnchor2")]
		public static extern void JointGetHingeAnchor2 (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetHingeAxis")]
		public static extern void JointGetHingeAxis (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetHingeParam")]
		public static extern double JointGetHingeParam (IntPtr joint, int parameter);

		[DllImport("ode", EntryPoint = "dJointGetHingeAngle")]
		public static extern double JointGetHingeAngle (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetHingeAngleRate")]
		public static extern double JointGetHingeAngleRate (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetSliderPosition")]
		public static extern double JointGetSliderPosition (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetSliderPositionRate")]
		public static extern double JointGetSliderPositionRate (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetSliderAxis")]
		public static extern void JointGetSliderAxis (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetSliderParam")]
		public static extern double JointGetSliderParam (IntPtr joint, int parameter);

		[DllImport("ode", EntryPoint = "dJointGetHinge2Anchor")]
		public static extern void JointGetHinge2Anchor (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetHinge2Anchor2")]
		public static extern void JointGetHinge2Anchor2 (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetHinge2Axis1")]
		public static extern void JointGetHinge2Axis1 (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetHinge2Axis2")]
		public static extern void JointGetHinge2Axis2 (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetHinge2Param")]
		public static extern double JointGetHinge2Param (IntPtr joint, int parameter);

		[DllImport("ode", EntryPoint = "dJointGetHinge2Angle1")]
		public static extern double JointGetHinge2Angle1 (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetHinge2Angle1Rate")]
		public static extern double JointGetHinge2Angle1Rate (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetHinge2Angle2Rate")]
		public static extern double JointGetHinge2Angle2Rate (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetUniversalAnchor")]
		public static extern void JointGetUniversalAnchor (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetUniversalAnchor2")]
		public static extern void JointGetUniversalAnchor2 (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetUniversalAxis1")]
		public static extern void JointGetUniversalAxis1 (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetUniversalAxis2")]
		public static extern void JointGetUniversalAxis2 (IntPtr joint, out double result);

		[DllImport("ode", EntryPoint = "dJointGetUniversalParam")]
		public static extern double JointGetUniversalParam (IntPtr joint, int parameter);

		[DllImport("ode", EntryPoint = "dJointGetUniversalAngle1")]
		public static extern double JointGetUniversalAngle1 (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetUniversalAngle2")]
		public static extern double JointGetUniversalAngle2 (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetUniversalAngle1Rate")]
		public static extern double JointGetUniversalAngle1Rate (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetUniversalAngle2Rate")]
		public static extern double JointGetUniversalAngle2Rate (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetAMotorNumAxes")]
		public static extern int JointGetAMotorNumAxes (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetAMotorAxis")]
		public static extern void JointGetAMotorAxis (IntPtr joint, int anum, out double result);

		[DllImport("ode", EntryPoint = "dJointGetAMotorAxisRel")]
		public static extern int JointGetAMotorAxisRel (IntPtr joint, int anum);

		[DllImport("ode", EntryPoint = "dJointGetAMotorAngle")]
		public static extern double JointGetAMotorAngle (IntPtr joint, int anum);

		[DllImport("ode", EntryPoint = "dJointGetAMotorAngleRate")]
		public static extern double JointGetAMotorAngleRate (IntPtr joint, int anum);

		[DllImport("ode", EntryPoint = "dJointGetAMotorParam")]
		public static extern double JointGetAMotorParam (IntPtr joint, int parameter);

		[DllImport("ode", EntryPoint = "dJointGetAMotorMode")]
		public static extern int JointGetAMotorMode (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetLMotorNumAxes")]
		public static extern int JointGetLMotorNumAxes (IntPtr joint);

		[DllImport("ode", EntryPoint = "dJointGetLMotorAxis")]
		public static extern void JointGetLMotorAxis (IntPtr joint, int anum, out double result);

		[DllImport("ode", EntryPoint = "dJointGetLMotorParam")]
		public static extern double JointGetLMotorParam (IntPtr joint, int parameter);

		[DllImport("ode", EntryPoint = "dConnectingJoint")]
		public static extern IntPtr ConnectingJoint (IntPtr body0, IntPtr body1);

//		int dConnectingJointList (IntPtr body, IntPtr body, IntPtr*);

		[DllImport("ode", EntryPoint = "dAreConnected")]
		public static extern int AreConnected (IntPtr body0, IntPtr body1);

		[DllImport("ode", EntryPoint = "dAreConnectedExcluding")]
		public static extern int AreConnectedExcluding (IntPtr body0, IntPtr body1, int joint_type);

		[DllImport("ode", EntryPoint = "dBodyCopyPosition")]
		public static extern void BodyCopyPosition(IntPtr body, out double pos);

#endif
	}
}
