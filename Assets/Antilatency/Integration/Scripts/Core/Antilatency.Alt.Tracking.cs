#pragma warning disable IDE1006 // Do not warn about naming style violations
#pragma warning disable IDE0017 // Do not suggest to simplify object initialization
using System.Runtime.InteropServices;
namespace Antilatency.Alt.Tracking {

public enum MarkerIndex : uint {
	Unknown = 4294967295
}
[Guid("c257c858-f296-43b7-b6b5-c14b9afb1a13")]
public interface IEnvironment : AntilatencyInterfaceContract.IInterface {
	bool isMutable();
	int getUpdateId();
	UnityEngine.Vector2[] getMarkers();
	bool filterRay(UnityEngine.Vector3 up, UnityEngine.Vector3 ray);
	bool match(UnityEngine.Vector3[] raysUpSpace, out Antilatency.Alt.Tracking.MarkerIndex[] markersIndices, out UnityEngine.Pose poseOfUpSpace);
	Antilatency.Alt.Tracking.MarkerIndex[] matchProjections(UnityEngine.Vector2[] projections);
}
namespace Details {
	public class IEnvironmentWrapper : AntilatencyInterfaceContract.Details.IInterfaceWrapper, IEnvironment {
		private IEnvironmentRemap.VMT _VMT = new IEnvironmentRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(IEnvironmentRemap.VMT).GetFields().Length;
		}
		public IEnvironmentWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<IEnvironmentRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public bool isMutable() {
			bool result;
			HandleExceptionCode(_VMT.isMutable(_object, out result));
			return result;
		}
		public int getUpdateId() {
			int result;
			HandleExceptionCode(_VMT.getUpdateId(_object, out result));
			return result;
		}
		public UnityEngine.Vector2[] getMarkers() {
			UnityEngine.Vector2[] result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create<UnityEngine.Vector2>();
			HandleExceptionCode(_VMT.getMarkers(_object, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public bool filterRay(UnityEngine.Vector3 up, UnityEngine.Vector3 ray) {
			bool result;
			HandleExceptionCode(_VMT.filterRay(_object, up, ray, out result));
			return result;
		}
		public bool match(UnityEngine.Vector3[] raysUpSpace, out Antilatency.Alt.Tracking.MarkerIndex[] markersIndices, out UnityEngine.Pose poseOfUpSpace) {
			bool result;
			var raysUpSpaceMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(raysUpSpace);
			var markersIndicesMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create<Antilatency.Alt.Tracking.MarkerIndex>();
			HandleExceptionCode(_VMT.match(_object, raysUpSpaceMarshaler, markersIndicesMarshaler, out poseOfUpSpace, out result));
			raysUpSpaceMarshaler.Dispose();
			markersIndices = markersIndicesMarshaler.value;
			markersIndicesMarshaler.Dispose();
			return result;
		}
		public Antilatency.Alt.Tracking.MarkerIndex[] matchProjections(UnityEngine.Vector2[] projections) {
			Antilatency.Alt.Tracking.MarkerIndex[] result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create<Antilatency.Alt.Tracking.MarkerIndex>();
			var projectionsMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(projections);
			HandleExceptionCode(_VMT.matchProjections(_object, projectionsMarshaler, resultMarshaler));
			projectionsMarshaler.Dispose();
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
	}
	public class IEnvironmentRemap : AntilatencyInterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate AntilatencyInterfaceContract.ExceptionCode isMutableDelegate(System.IntPtr _this, out bool result);
			public delegate AntilatencyInterfaceContract.ExceptionCode getUpdateIdDelegate(System.IntPtr _this, out int result);
			public delegate AntilatencyInterfaceContract.ExceptionCode getMarkersDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate AntilatencyInterfaceContract.ExceptionCode filterRayDelegate(System.IntPtr _this, UnityEngine.Vector3 up, UnityEngine.Vector3 ray, out bool result);
			public delegate AntilatencyInterfaceContract.ExceptionCode matchDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate raysUpSpace, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate markersIndices, out UnityEngine.Pose poseOfUpSpace, out bool result);
			public delegate AntilatencyInterfaceContract.ExceptionCode matchProjectionsDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate projections, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			#pragma warning disable 0649
			public isMutableDelegate isMutable;
			public getUpdateIdDelegate getUpdateId;
			public getMarkersDelegate getMarkers;
			public filterRayDelegate filterRay;
			public matchDelegate match;
			public matchProjectionsDelegate matchProjections;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static IEnvironmentRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			AntilatencyInterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.isMutable = (System.IntPtr _this, out bool result) => {
				try {
					var obj = GetContext(_this) as IEnvironment;
					result = obj.isMutable();
				}
				catch (System.Exception ex) {
					result = default(bool);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.getUpdateId = (System.IntPtr _this, out int result) => {
				try {
					var obj = GetContext(_this) as IEnvironment;
					result = obj.getUpdateId();
				}
				catch (System.Exception ex) {
					result = default(int);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.getMarkers = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IEnvironment;
					result.assign(obj.getMarkers());
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.filterRay = (System.IntPtr _this, UnityEngine.Vector3 up, UnityEngine.Vector3 ray, out bool result) => {
				try {
					var obj = GetContext(_this) as IEnvironment;
					result = obj.filterRay(up, ray);
				}
				catch (System.Exception ex) {
					result = default(bool);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.match = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate raysUpSpace, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate markersIndices, out UnityEngine.Pose poseOfUpSpace, out bool result) => {
				try {
					var obj = GetContext(_this) as IEnvironment;
					Antilatency.Alt.Tracking.MarkerIndex[] markersIndicesMarshaler;
					result = obj.match(raysUpSpace.toArray<UnityEngine.Vector3>(), out markersIndicesMarshaler, out poseOfUpSpace);
					markersIndices.assign(markersIndicesMarshaler);
				}
				catch (System.Exception ex) {
					result = default(bool);
					poseOfUpSpace = default(UnityEngine.Pose);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.matchProjections = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate projections, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IEnvironment;
					result.assign(obj.matchProjections(projections.toArray<UnityEngine.Vector2>()));
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public IEnvironmentRemap() { }
		public IEnvironmentRemap(System.IntPtr context) {
			AllocateNativeInterface(NativeVmt.Handle, context);
		}
	}
}
public enum Stage : int {
	InertialDataInitialization = 0,
	Tracking3Dof = 1,
	TrackingBlind6Dof = 2,
	PositionRotationByOptics = 3,
	PositionOptimization = 4,
	PositionVelocityOptimization = 5,
	PositionVelocityRotationOptimization = 6,
	FullOptimization = 7
}
public struct Stability {
	public Antilatency.Alt.Tracking.Stage stage;
	public float value;
}
public struct State {
	public UnityEngine.Pose pose;
	public UnityEngine.Vector3 velocity;
	public UnityEngine.Vector3 localAngularVelocity;
	public Antilatency.Alt.Tracking.Stability stability;
}
[Guid("7f8b603c-fa91-4168-92b7-af1644d087db")]
public interface ITask : Antilatency.DeviceNetwork.ITask {
	/// <param name = "placement">
	/// Position (meters) and orientation (quaternion) of tracker relative to origin of tracked object.
	/// </param>
	/// <param name = "deltaTime">
	/// Extrapolation time (seconds).
	/// </param>
	Antilatency.Alt.Tracking.State getExtrapolatedState(UnityEngine.Pose placement, float deltaTime);
	Antilatency.Alt.Tracking.State getState();
}
namespace Details {
	public class ITaskWrapper : Antilatency.DeviceNetwork.Details.ITaskWrapper, ITask {
		private ITaskRemap.VMT _VMT = new ITaskRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ITaskRemap.VMT).GetFields().Length;
		}
		public ITaskWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ITaskRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public Antilatency.Alt.Tracking.State getExtrapolatedState(UnityEngine.Pose placement, float deltaTime) {
			Antilatency.Alt.Tracking.State result;
			HandleExceptionCode(_VMT.getExtrapolatedState(_object, placement, deltaTime, out result));
			return result;
		}
		public Antilatency.Alt.Tracking.State getState() {
			Antilatency.Alt.Tracking.State result;
			HandleExceptionCode(_VMT.getState(_object, out result));
			return result;
		}
	}
	public class ITaskRemap : Antilatency.DeviceNetwork.Details.ITaskRemap {
		public new struct VMT {
			public delegate AntilatencyInterfaceContract.ExceptionCode getExtrapolatedStateDelegate(System.IntPtr _this, UnityEngine.Pose placement, float deltaTime, out Antilatency.Alt.Tracking.State result);
			public delegate AntilatencyInterfaceContract.ExceptionCode getStateDelegate(System.IntPtr _this, out Antilatency.Alt.Tracking.State result);
			#pragma warning disable 0649
			public getExtrapolatedStateDelegate getExtrapolatedState;
			public getStateDelegate getState;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ITaskRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.DeviceNetwork.Details.ITaskRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.getExtrapolatedState = (System.IntPtr _this, UnityEngine.Pose placement, float deltaTime, out Antilatency.Alt.Tracking.State result) => {
				try {
					var obj = GetContext(_this) as ITask;
					result = obj.getExtrapolatedState(placement, deltaTime);
				}
				catch (System.Exception ex) {
					result = default(Antilatency.Alt.Tracking.State);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.getState = (System.IntPtr _this, out Antilatency.Alt.Tracking.State result) => {
				try {
					var obj = GetContext(_this) as ITask;
					result = obj.getState();
				}
				catch (System.Exception ex) {
					result = default(Antilatency.Alt.Tracking.State);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public ITaskRemap() { }
		public ITaskRemap(System.IntPtr context) {
			AllocateNativeInterface(NativeVmt.Handle, context);
		}
	}
}
[Guid("e7871523-f719-48e9-9891-07d1c9fb1e49")]
public interface ILibrary : AntilatencyInterfaceContract.IInterface {
	Antilatency.Alt.Tracking.IEnvironment createEnvironment(string code);
	UnityEngine.Pose createPlacement(string code);
	Antilatency.Alt.Tracking.ITask createTracking(Antilatency.DeviceNetwork.IFactory factory, Antilatency.DeviceNetwork.NodeHandle nodeHandle, Antilatency.Alt.Tracking.IEnvironment environment);
	string encodePlacement(UnityEngine.Vector3 position, UnityEngine.Vector3 rotation);
}
public static class Library{
    [DllImport("AntilatencyAltTracking")]
    private static extern AntilatencyInterfaceContract.ExceptionCode getLibraryInterface(System.IntPtr unloader, out System.IntPtr result);
    public static ILibrary load(){
        System.IntPtr libraryAsIInterfaceIntermediate;
        getLibraryInterface(System.IntPtr.Zero, out libraryAsIInterfaceIntermediate);
        AntilatencyInterfaceContract.IInterface libraryAsIInterface = new AntilatencyInterfaceContract.Details.IInterfaceWrapper(libraryAsIInterfaceIntermediate);
        var library = libraryAsIInterface.QueryInterface<ILibrary>();
        libraryAsIInterface.Dispose();
        return library;
    }
}
namespace Details {
	public class ILibraryWrapper : AntilatencyInterfaceContract.Details.IInterfaceWrapper, ILibrary {
		private ILibraryRemap.VMT _VMT = new ILibraryRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ILibraryRemap.VMT).GetFields().Length;
		}
		public ILibraryWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ILibraryRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public Antilatency.Alt.Tracking.IEnvironment createEnvironment(string code) {
			Antilatency.Alt.Tracking.IEnvironment result;
			System.IntPtr resultMarshaler;
			var codeMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(code);
			HandleExceptionCode(_VMT.createEnvironment(_object, codeMarshaler, out resultMarshaler));
			codeMarshaler.Dispose();
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.Alt.Tracking.Details.IEnvironmentWrapper(resultMarshaler);
			return result;
		}
		public UnityEngine.Pose createPlacement(string code) {
			UnityEngine.Pose result;
			var codeMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(code);
			HandleExceptionCode(_VMT.createPlacement(_object, codeMarshaler, out result));
			codeMarshaler.Dispose();
			return result;
		}
		public Antilatency.Alt.Tracking.ITask createTracking(Antilatency.DeviceNetwork.IFactory factory, Antilatency.DeviceNetwork.NodeHandle nodeHandle, Antilatency.Alt.Tracking.IEnvironment environment) {
			Antilatency.Alt.Tracking.ITask result;
			System.IntPtr resultMarshaler;
			var factoryMarshaler = AntilatencyInterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.IFactory>(factory);
			var environmentMarshaler = AntilatencyInterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.Alt.Tracking.IEnvironment>(environment);
			HandleExceptionCode(_VMT.createTracking(_object, factoryMarshaler, nodeHandle, environmentMarshaler, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.Alt.Tracking.Details.ITaskWrapper(resultMarshaler);
			return result;
		}
		public string encodePlacement(UnityEngine.Vector3 position, UnityEngine.Vector3 rotation) {
			string result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create();
			HandleExceptionCode(_VMT.encodePlacement(_object, position, rotation, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
	}
	public class ILibraryRemap : AntilatencyInterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate AntilatencyInterfaceContract.ExceptionCode createEnvironmentDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate code, out System.IntPtr result);
			public delegate AntilatencyInterfaceContract.ExceptionCode createPlacementDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate code, out UnityEngine.Pose result);
			public delegate AntilatencyInterfaceContract.ExceptionCode createTrackingDelegate(System.IntPtr _this, System.IntPtr factory, Antilatency.DeviceNetwork.NodeHandle nodeHandle, System.IntPtr environment, out System.IntPtr result);
			public delegate AntilatencyInterfaceContract.ExceptionCode encodePlacementDelegate(System.IntPtr _this, UnityEngine.Vector3 position, UnityEngine.Vector3 rotation, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			#pragma warning disable 0649
			public createEnvironmentDelegate createEnvironment;
			public createPlacementDelegate createPlacement;
			public createTrackingDelegate createTracking;
			public encodePlacementDelegate encodePlacement;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ILibraryRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			AntilatencyInterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.createEnvironment = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate code, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					var resultMarshaler = obj.createEnvironment(code);
					result = AntilatencyInterfaceContract.Details.InterfaceMarshaler.ManagedToNative<IEnvironment>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.createPlacement = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate code, out UnityEngine.Pose result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					result = obj.createPlacement(code);
				}
				catch (System.Exception ex) {
					result = default(UnityEngine.Pose);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.createTracking = (System.IntPtr _this, System.IntPtr factory, Antilatency.DeviceNetwork.NodeHandle nodeHandle, System.IntPtr environment, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					var factoryMarshaler = factory == System.IntPtr.Zero ? null : new Antilatency.DeviceNetwork.Details.IFactoryWrapper(factory);
					var environmentMarshaler = environment == System.IntPtr.Zero ? null : new Antilatency.Alt.Tracking.Details.IEnvironmentWrapper(environment);
					var resultMarshaler = obj.createTracking(factoryMarshaler, nodeHandle, environmentMarshaler);
					result = AntilatencyInterfaceContract.Details.InterfaceMarshaler.ManagedToNative<ITask>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.encodePlacement = (System.IntPtr _this, UnityEngine.Vector3 position, UnityEngine.Vector3 rotation, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					result.assign(obj.encodePlacement(position, rotation));
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public ILibraryRemap() { }
		public ILibraryRemap(System.IntPtr context) {
			AllocateNativeInterface(NativeVmt.Handle, context);
		}
	}
}
public static partial class Constants {
	/// <example><code>Antilatency.DeviceNetwork.IFactory.nodeIsInterfaceSupported(node,Antilatency.Alt.Tracking.Constants.TaskID);</code></example>
	/// <summary>TaskID is required to check if task is supported by device.</summary>
	public static System.Guid TaskID {
		get {
			byte[] data = new byte[]{58, 145, 119, 100, 172, 30, 161, 77, 181, 128, 153, 75, 13, 212, 246, 200};
			var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
			System.Guid result = (System.Guid)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(System.Guid));
			handle.Free();
			return result;
		}
	}
}
}
