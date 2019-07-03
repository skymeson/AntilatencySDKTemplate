#pragma warning disable IDE1006 // Do not warn about naming style violations
#pragma warning disable IDE0017 // Do not suggest to simplify object initialization
using System.Runtime.InteropServices;
namespace Antilatency.DeviceNetwork {

/// <summary>USB device identifier.</summary>
public struct UsbDeviceType {
	public ushort vid;
	public ushort pid;
}
/// <summary>Handle to Antilatency Device Network device. Every time device is connected, the unique handle will be applied to it, so, when device disconnects, NodeStatus for its node becomes Invalid, after reconnection this devices receives new NodeHandle.</summary>
public struct NodeHandle {
	public int value;
}
/// <summary>Defines different node conditions.</summary>
public enum NodeStatus : int {
	Idle = 0,
	TaskRunning = 1,
	Invalid = 2
}
/// <summary>Task interface with ability to send some data to task and stop task.</summary>
[Guid("d46039a6-dec4-4a0f-a0d6-89a4b53e700f")]
public interface IWriteStream : AntilatencyInterfaceContract.IInterface {
	/// <param name = "packetId">
	/// Packet ID
	/// </param>
	/// <returns>True if successfully sent to network, false if there are no empty buffer space or node is not valid or task does not support this packet ID or data size is not supported by this packet ID.</returns>
	/// <param name = "dataSize">
	/// Packet data size.
	/// </param>
	/// <param name = "data">
	/// Pointer to packet data that will be sended to task.
	/// </param>
	/// <summary>Non-blocking data send method, this data will be added to buffer and then sended in another thread.</summary>
	bool writePacket(byte packetId, System.IntPtr data, uint dataSize);
	/// <summary>Stop task. This method blocks until task finished.</summary>
	void stopTask();
}
namespace Details {
	public class IWriteStreamWrapper : AntilatencyInterfaceContract.Details.IInterfaceWrapper, IWriteStream {
		private IWriteStreamRemap.VMT _VMT = new IWriteStreamRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(IWriteStreamRemap.VMT).GetFields().Length;
		}
		public IWriteStreamWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<IWriteStreamRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public bool writePacket(byte packetId, System.IntPtr data, uint dataSize) {
			bool result;
			HandleExceptionCode(_VMT.writePacket(_object, packetId, data, dataSize, out result));
			return result;
		}
		public void stopTask() {
			HandleExceptionCode(_VMT.stopTask(_object));
		}
	}
	public class IWriteStreamRemap : AntilatencyInterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate AntilatencyInterfaceContract.ExceptionCode writePacketDelegate(System.IntPtr _this, byte packetId, System.IntPtr data, uint dataSize, out bool result);
			public delegate AntilatencyInterfaceContract.ExceptionCode stopTaskDelegate(System.IntPtr _this);
			#pragma warning disable 0649
			public writePacketDelegate writePacket;
			public stopTaskDelegate stopTask;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static IWriteStreamRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			AntilatencyInterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.writePacket = (System.IntPtr _this, byte packetId, System.IntPtr data, uint dataSize, out bool result) => {
				try {
					var obj = GetContext(_this) as IWriteStream;
					result = obj.writePacket(packetId, data, dataSize);
				}
				catch (System.Exception ex) {
					result = default(bool);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.stopTask = (System.IntPtr _this) => {
				try {
					var obj = GetContext(_this) as IWriteStream;
					obj.stopTask();
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public IWriteStreamRemap() { }
		public IWriteStreamRemap(System.IntPtr context) {
			AllocateNativeInterface(NativeVmt.Handle, context);
		}
	}
}
/// <summary>Data received callback.</summary>
[Guid("d46039a6-dec4-4a0f-a0d6-89a4b53e700f")]
public interface IReadCallback : AntilatencyInterfaceContract.IUnsafe {
	/// <param name = "packetId">
	/// Packet ID.
	/// </param>
	/// <param name = "data">
	/// Pointer to packet data received from task.
	/// </param>
	/// <param name = "dataSize">
	/// Received packet data size.
	/// </param>
	/// <summary>Will be executed on data receive.</summary>
	void onPacketReceived(byte packetId, System.IntPtr data, uint dataSize);
	/// <summary>Will be executed when task is finished.</summary>
	void onTaskFinished();
}
namespace Details {
	public class IReadCallbackWrapper : AntilatencyInterfaceContract.Details.IUnsafeWrapper, IReadCallback {
		private IReadCallbackRemap.VMT _VMT = new IReadCallbackRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(IReadCallbackRemap.VMT).GetFields().Length;
		}
		public IReadCallbackWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<IReadCallbackRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public void onPacketReceived(byte packetId, System.IntPtr data, uint dataSize) {
			HandleExceptionCode(_VMT.onPacketReceived(_object, packetId, data, dataSize));
		}
		public void onTaskFinished() {
			HandleExceptionCode(_VMT.onTaskFinished(_object));
		}
	}
	public class IReadCallbackRemap : AntilatencyInterfaceContract.Details.IUnsafeRemap {
		public new struct VMT {
			public delegate AntilatencyInterfaceContract.ExceptionCode onPacketReceivedDelegate(System.IntPtr _this, byte packetId, System.IntPtr data, uint dataSize);
			public delegate AntilatencyInterfaceContract.ExceptionCode onTaskFinishedDelegate(System.IntPtr _this);
			#pragma warning disable 0649
			public onPacketReceivedDelegate onPacketReceived;
			public onTaskFinishedDelegate onTaskFinished;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static IReadCallbackRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			AntilatencyInterfaceContract.Details.IUnsafeRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.onPacketReceived = (System.IntPtr _this, byte packetId, System.IntPtr data, uint dataSize) => {
				try {
					var obj = GetContext(_this) as IReadCallback;
					obj.onPacketReceived(packetId, data, dataSize);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.onTaskFinished = (System.IntPtr _this) => {
				try {
					var obj = GetContext(_this) as IReadCallback;
					obj.onTaskFinished();
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public IReadCallbackRemap() { }
		public IReadCallbackRemap(System.IntPtr context) {
			AllocateNativeInterface(NativeVmt.Handle, context);
		}
	}
}
/// <summary>Task receive stream packet.</summary>
public struct StreamPacket {
	public byte id;
	public System.IntPtr data;
	public uint dataSize;
}
/// <summary>Synchronous task read/write stream.</summary>
[Guid("97a8e3dc-cc0e-4c58-8d91-8649b116db64")]
public interface IBlockingIOStream : Antilatency.DeviceNetwork.IWriteStream {
	/// <summary>Get received packets. Blocks until any packets received or task finished.</summary>
	/// <returns>Received packets array. Zero packets count if task is finished.</returns>
	Antilatency.DeviceNetwork.StreamPacket[] getPackets();
	/// <returns>Received packets array. Zero packets count if no packets received.</returns>
	/// <summary>Get received packets.</summary>
	/// <param name = "taskFinished">
	/// Is task finished.
	/// </param>
	Antilatency.DeviceNetwork.StreamPacket[] getAvailablePackets(out bool taskFinished);
}
namespace Details {
	public class IBlockingIOStreamWrapper : Antilatency.DeviceNetwork.Details.IWriteStreamWrapper, IBlockingIOStream {
		private IBlockingIOStreamRemap.VMT _VMT = new IBlockingIOStreamRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(IBlockingIOStreamRemap.VMT).GetFields().Length;
		}
		public IBlockingIOStreamWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<IBlockingIOStreamRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public Antilatency.DeviceNetwork.StreamPacket[] getPackets() {
			Antilatency.DeviceNetwork.StreamPacket[] result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create<Antilatency.DeviceNetwork.StreamPacket>();
			HandleExceptionCode(_VMT.getPackets(_object, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public Antilatency.DeviceNetwork.StreamPacket[] getAvailablePackets(out bool taskFinished) {
			Antilatency.DeviceNetwork.StreamPacket[] result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create<Antilatency.DeviceNetwork.StreamPacket>();
			HandleExceptionCode(_VMT.getAvailablePackets(_object, out taskFinished, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
	}
	public class IBlockingIOStreamRemap : Antilatency.DeviceNetwork.Details.IWriteStreamRemap {
		public new struct VMT {
			public delegate AntilatencyInterfaceContract.ExceptionCode getPacketsDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate AntilatencyInterfaceContract.ExceptionCode getAvailablePacketsDelegate(System.IntPtr _this, out bool taskFinished, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			#pragma warning disable 0649
			public getPacketsDelegate getPackets;
			public getAvailablePacketsDelegate getAvailablePackets;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static IBlockingIOStreamRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.DeviceNetwork.Details.IWriteStreamRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.getPackets = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IBlockingIOStream;
					result.assign(obj.getPackets());
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.getAvailablePackets = (System.IntPtr _this, out bool taskFinished, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IBlockingIOStream;
					result.assign(obj.getAvailablePackets(out taskFinished));
				}
				catch (System.Exception ex) {
					taskFinished = default(bool);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public IBlockingIOStreamRemap() { }
		public IBlockingIOStreamRemap(System.IntPtr context) {
			AllocateNativeInterface(NativeVmt.Handle, context);
		}
	}
}
/// <summary>Object providing methods to work with nodes.</summary>
[Guid("24ee2bc6-58e3-41ee-a670-1c08d7e9a754")]
public interface IFactory : AntilatencyInterfaceContract.IInterface {
	/// <summary>Every time any supported device is connected or disconnected, update ID will be incremented. You can use this method to check if there are any changes in ADN.</summary>
	/// <returns>Current factory update ID.</returns>
	uint getUpdateId();
	/// <returns>Array of USB device identifiers which this factory instance is working with.</returns>
	/// <summary>Get USB device types selected to work with this factory instance.</summary>
	Antilatency.DeviceNetwork.UsbDeviceType[] getDeviceTypes();
	/// <summary>Get all currently connected nodes.</summary>
	Antilatency.DeviceNetwork.NodeHandle[] getNodes();
	/// <param name = "node">
	/// Node handle to get status of.
	/// </param>
	/// <summary>Get current NodeStatus for node.</summary>
	Antilatency.DeviceNetwork.NodeStatus nodeGetStatus(Antilatency.DeviceNetwork.NodeHandle node);
	/// <param name = "node">
	/// Node handle.
	/// </param>
	/// <param name = "interfaceId">
	/// Task interface ID.
	/// </param>
	/// <returns>True if node supports such task, otherwise false.</returns>
	/// <summary>Checks if task is supported by node.</summary>
	bool nodeIsInterfaceSupported(Antilatency.DeviceNetwork.NodeHandle node, System.Guid interfaceId);
	/// <param name = "node">
	/// Node handle.
	/// </param>
	/// <summary>Get parent for node, in case of USB node this method will return Antilatency.DeviceNetwork.Constants.RootNode</summary>
	Antilatency.DeviceNetwork.NodeHandle nodeGetParent(Antilatency.DeviceNetwork.NodeHandle node);
	/// <summary>Physical address path to first level device that contains this node in network tree.</summary>
	/// <returns>String represents physical path to first level device (connected via USB).</returns>
	/// <param name = "node">
	/// Node handle.
	/// </param>
	string nodeGetPhysicalPath(Antilatency.DeviceNetwork.NodeHandle node);
	/// <summary>Run task on node with asynchronous packet receive API.</summary>
	/// <param name = "node">
	/// Node handle to start task on.
	/// </param>
	/// <param name = "readCallback">
	/// Packet received callback. Method will be invoked from internal RX thread.
	/// </param>
	/// <param name = "interfaceId">
	/// Task interface ID.
	/// </param>
	Antilatency.DeviceNetwork.IWriteStream nodeStartTask(Antilatency.DeviceNetwork.NodeHandle node, System.Guid interfaceId, Antilatency.DeviceNetwork.IReadCallback readCallback);
	/// <summary>Run task on node with synchronous packet receive API.</summary>
	/// <param name = "interfaceId">
	/// Task interface ID.
	/// </param>
	/// <param name = "node">
	/// Node handle to start task on.
	/// </param>
	Antilatency.DeviceNetwork.IBlockingIOStream nodeStartTask2(Antilatency.DeviceNetwork.NodeHandle node, System.Guid interfaceId);
	/// <param name = "node">
	/// Node handle to get property from.
	/// </param>
	/// <param name = "key">
	/// Property key. List of predefined properties you can find in documentation, also there are some properties defined in Antilatency.DeviceNetwork.Constants that is valid for every Antilatency device
	/// </param>
	/// <returns>Synchronous task read/write stream interface.</returns>
	/// <summary>Get node property.</summary>
	string nodeGetProperty(Antilatency.DeviceNetwork.NodeHandle node, string key);
	/// <param name = "value">
	/// Property value.
	/// </param>
	/// <param name = "key">
	/// Property key. Setting predefined property such as Serial Number is not allowed.
	/// </param>
	/// <summary>Set node property. Setting properties defined in Antilatency.DeviceNetwork.Constants is not allowed. This method execution currently leads to node reboot.</summary>
	/// <param name = "node">
	/// Node handle to set property to.
	/// </param>
	bool nodeSetProperty(Antilatency.DeviceNetwork.NodeHandle node, string key, string value);
	/// <param name = "node">
	/// Node handle to get serial number from.
	/// </param>
	/// <summary>Deprecated. Use nodeGetProperty(node, Antilatency.DeviceNetwork.Constants.SerialNumberKey) instead.</summary>
	byte[] nodeGetSerialNumber(Antilatency.DeviceNetwork.NodeHandle node);
	/// <summary>Deprecated. Use nodeGetProperty(node, Antilatency.DeviceNetwork.Constants.SoftwareVersionKey) instead.</summary>
	/// <param name = "node">
	/// Node handle to get software version from.
	/// </param>
	string nodeGetSoftwareVersion(Antilatency.DeviceNetwork.NodeHandle node);
	/// <summary>Deprecated. Use nodeGetProperty(node, Antilatency.DeviceNetwork.Constants.HardwareVersionKey) instead.</summary>
	/// <param name = "node">
	/// Node handle to get hardware version from.
	/// </param>
	string nodeGetHardwareVersion(Antilatency.DeviceNetwork.NodeHandle node);
}
namespace Details {
	public class IFactoryWrapper : AntilatencyInterfaceContract.Details.IInterfaceWrapper, IFactory {
		private IFactoryRemap.VMT _VMT = new IFactoryRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(IFactoryRemap.VMT).GetFields().Length;
		}
		public IFactoryWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<IFactoryRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public uint getUpdateId() {
			uint result;
			HandleExceptionCode(_VMT.getUpdateId(_object, out result));
			return result;
		}
		public Antilatency.DeviceNetwork.UsbDeviceType[] getDeviceTypes() {
			Antilatency.DeviceNetwork.UsbDeviceType[] result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create<Antilatency.DeviceNetwork.UsbDeviceType>();
			HandleExceptionCode(_VMT.getDeviceTypes(_object, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public Antilatency.DeviceNetwork.NodeHandle[] getNodes() {
			Antilatency.DeviceNetwork.NodeHandle[] result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create<Antilatency.DeviceNetwork.NodeHandle>();
			HandleExceptionCode(_VMT.getNodes(_object, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public Antilatency.DeviceNetwork.NodeStatus nodeGetStatus(Antilatency.DeviceNetwork.NodeHandle node) {
			Antilatency.DeviceNetwork.NodeStatus result;
			HandleExceptionCode(_VMT.nodeGetStatus(_object, node, out result));
			return result;
		}
		public bool nodeIsInterfaceSupported(Antilatency.DeviceNetwork.NodeHandle node, System.Guid interfaceId) {
			bool result;
			HandleExceptionCode(_VMT.nodeIsInterfaceSupported(_object, node, interfaceId, out result));
			return result;
		}
		public Antilatency.DeviceNetwork.NodeHandle nodeGetParent(Antilatency.DeviceNetwork.NodeHandle node) {
			Antilatency.DeviceNetwork.NodeHandle result;
			HandleExceptionCode(_VMT.nodeGetParent(_object, node, out result));
			return result;
		}
		public string nodeGetPhysicalPath(Antilatency.DeviceNetwork.NodeHandle node) {
			string result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create();
			HandleExceptionCode(_VMT.nodeGetPhysicalPath(_object, node, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public Antilatency.DeviceNetwork.IWriteStream nodeStartTask(Antilatency.DeviceNetwork.NodeHandle node, System.Guid interfaceId, Antilatency.DeviceNetwork.IReadCallback readCallback) {
			Antilatency.DeviceNetwork.IWriteStream result;
			System.IntPtr resultMarshaler;
			var readCallbackMarshaler = AntilatencyInterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.IReadCallback>(readCallback);
			HandleExceptionCode(_VMT.nodeStartTask(_object, node, interfaceId, readCallbackMarshaler, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.DeviceNetwork.Details.IWriteStreamWrapper(resultMarshaler);
			return result;
		}
		public Antilatency.DeviceNetwork.IBlockingIOStream nodeStartTask2(Antilatency.DeviceNetwork.NodeHandle node, System.Guid interfaceId) {
			Antilatency.DeviceNetwork.IBlockingIOStream result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.nodeStartTask2(_object, node, interfaceId, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.DeviceNetwork.Details.IBlockingIOStreamWrapper(resultMarshaler);
			return result;
		}
		public string nodeGetProperty(Antilatency.DeviceNetwork.NodeHandle node, string key) {
			string result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create();
			var keyMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(key);
			HandleExceptionCode(_VMT.nodeGetProperty(_object, node, keyMarshaler, resultMarshaler));
			keyMarshaler.Dispose();
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public bool nodeSetProperty(Antilatency.DeviceNetwork.NodeHandle node, string key, string value) {
			bool result;
			var keyMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(key);
			var valueMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(value);
			HandleExceptionCode(_VMT.nodeSetProperty(_object, node, keyMarshaler, valueMarshaler, out result));
			keyMarshaler.Dispose();
			valueMarshaler.Dispose();
			return result;
		}
		public byte[] nodeGetSerialNumber(Antilatency.DeviceNetwork.NodeHandle node) {
			byte[] result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create<byte>();
			HandleExceptionCode(_VMT.nodeGetSerialNumber(_object, node, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public string nodeGetSoftwareVersion(Antilatency.DeviceNetwork.NodeHandle node) {
			string result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create();
			HandleExceptionCode(_VMT.nodeGetSoftwareVersion(_object, node, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public string nodeGetHardwareVersion(Antilatency.DeviceNetwork.NodeHandle node) {
			string result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create();
			HandleExceptionCode(_VMT.nodeGetHardwareVersion(_object, node, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
	}
	public class IFactoryRemap : AntilatencyInterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate AntilatencyInterfaceContract.ExceptionCode getUpdateIdDelegate(System.IntPtr _this, out uint result);
			public delegate AntilatencyInterfaceContract.ExceptionCode getDeviceTypesDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate AntilatencyInterfaceContract.ExceptionCode getNodesDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate AntilatencyInterfaceContract.ExceptionCode nodeGetStatusDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, out Antilatency.DeviceNetwork.NodeStatus result);
			public delegate AntilatencyInterfaceContract.ExceptionCode nodeIsInterfaceSupportedDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, System.Guid interfaceId, out bool result);
			public delegate AntilatencyInterfaceContract.ExceptionCode nodeGetParentDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, out Antilatency.DeviceNetwork.NodeHandle result);
			public delegate AntilatencyInterfaceContract.ExceptionCode nodeGetPhysicalPathDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate AntilatencyInterfaceContract.ExceptionCode nodeStartTaskDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, System.Guid interfaceId, System.IntPtr readCallback, out System.IntPtr result);
			public delegate AntilatencyInterfaceContract.ExceptionCode nodeStartTask2Delegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, System.Guid interfaceId, out System.IntPtr result);
			public delegate AntilatencyInterfaceContract.ExceptionCode nodeGetPropertyDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate key, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate AntilatencyInterfaceContract.ExceptionCode nodeSetPropertyDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate key, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate value, out bool result);
			public delegate AntilatencyInterfaceContract.ExceptionCode nodeGetSerialNumberDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate AntilatencyInterfaceContract.ExceptionCode nodeGetSoftwareVersionDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate AntilatencyInterfaceContract.ExceptionCode nodeGetHardwareVersionDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			#pragma warning disable 0649
			public getUpdateIdDelegate getUpdateId;
			public getDeviceTypesDelegate getDeviceTypes;
			public getNodesDelegate getNodes;
			public nodeGetStatusDelegate nodeGetStatus;
			public nodeIsInterfaceSupportedDelegate nodeIsInterfaceSupported;
			public nodeGetParentDelegate nodeGetParent;
			public nodeGetPhysicalPathDelegate nodeGetPhysicalPath;
			public nodeStartTaskDelegate nodeStartTask;
			public nodeStartTask2Delegate nodeStartTask2;
			public nodeGetPropertyDelegate nodeGetProperty;
			public nodeSetPropertyDelegate nodeSetProperty;
			public nodeGetSerialNumberDelegate nodeGetSerialNumber;
			public nodeGetSoftwareVersionDelegate nodeGetSoftwareVersion;
			public nodeGetHardwareVersionDelegate nodeGetHardwareVersion;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static IFactoryRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			AntilatencyInterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.getUpdateId = (System.IntPtr _this, out uint result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					result = obj.getUpdateId();
				}
				catch (System.Exception ex) {
					result = default(uint);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.getDeviceTypes = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					result.assign(obj.getDeviceTypes());
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.getNodes = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					result.assign(obj.getNodes());
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeGetStatus = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, out Antilatency.DeviceNetwork.NodeStatus result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					result = obj.nodeGetStatus(node);
				}
				catch (System.Exception ex) {
					result = default(Antilatency.DeviceNetwork.NodeStatus);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeIsInterfaceSupported = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, System.Guid interfaceId, out bool result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					result = obj.nodeIsInterfaceSupported(node, interfaceId);
				}
				catch (System.Exception ex) {
					result = default(bool);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeGetParent = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, out Antilatency.DeviceNetwork.NodeHandle result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					result = obj.nodeGetParent(node);
				}
				catch (System.Exception ex) {
					result = default(Antilatency.DeviceNetwork.NodeHandle);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeGetPhysicalPath = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					result.assign(obj.nodeGetPhysicalPath(node));
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeStartTask = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, System.Guid interfaceId, System.IntPtr readCallback, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					var readCallbackMarshaler = readCallback == System.IntPtr.Zero ? null : new Antilatency.DeviceNetwork.Details.IReadCallbackWrapper(readCallback);
					var resultMarshaler = obj.nodeStartTask(node, interfaceId, readCallbackMarshaler);
					result = AntilatencyInterfaceContract.Details.InterfaceMarshaler.ManagedToNative<IWriteStream>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeStartTask2 = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, System.Guid interfaceId, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					var resultMarshaler = obj.nodeStartTask2(node, interfaceId);
					result = AntilatencyInterfaceContract.Details.InterfaceMarshaler.ManagedToNative<IBlockingIOStream>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeGetProperty = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate key, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					result.assign(obj.nodeGetProperty(node, key));
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeSetProperty = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate key, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate value, out bool result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					result = obj.nodeSetProperty(node, key, value);
				}
				catch (System.Exception ex) {
					result = default(bool);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeGetSerialNumber = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					result.assign(obj.nodeGetSerialNumber(node));
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeGetSoftwareVersion = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					result.assign(obj.nodeGetSoftwareVersion(node));
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeGetHardwareVersion = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IFactory;
					result.assign(obj.nodeGetHardwareVersion(node));
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public IFactoryRemap() { }
		public IFactoryRemap(System.IntPtr context) {
			AllocateNativeInterface(NativeVmt.Handle, context);
		}
	}
}
/// <summary>Antilatency Device Network log verbosity level.</summary>
public enum LogLevel : int {
	Trace = 0,
	Debug = 1,
	Info = 2,
	Warning = 3,
	Error = 4,
	Critical = 5,
	Off = 6
}
/// <summary>Antilatency Device Network library entry point.</summary>
[Guid("cb1853b6-32a2-4f95-8eca-f999e36d3176")]
public interface ILibrary : AntilatencyInterfaceContract.IInterface {
	/// <summary>Create Antilatency Device Network factory object</summary>
	/// <param name = "deviceTypes">
	/// Array of USB device identifiers which will be used by factory.
	/// </param>
	Antilatency.DeviceNetwork.IFactory createFactory(Antilatency.DeviceNetwork.UsbDeviceType[] deviceTypes);
	/// <summary>Get Antilatency Device Network library version.</summary>
	string getVersion();
	/// <summary>Set Antilatency Device Network log verbosity level</summary>
	void setLogLevel(Antilatency.DeviceNetwork.LogLevel level);
}
public static class Library{
    [DllImport("AntilatencyDeviceNetwork")]
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
		public Antilatency.DeviceNetwork.IFactory createFactory(Antilatency.DeviceNetwork.UsbDeviceType[] deviceTypes) {
			Antilatency.DeviceNetwork.IFactory result;
			System.IntPtr resultMarshaler;
			var deviceTypesMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(deviceTypes);
			HandleExceptionCode(_VMT.createFactory(_object, deviceTypesMarshaler, out resultMarshaler));
			deviceTypesMarshaler.Dispose();
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.DeviceNetwork.Details.IFactoryWrapper(resultMarshaler);
			return result;
		}
		public string getVersion() {
			string result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create();
			HandleExceptionCode(_VMT.getVersion(_object, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public void setLogLevel(Antilatency.DeviceNetwork.LogLevel level) {
			HandleExceptionCode(_VMT.setLogLevel(_object, level));
		}
	}
	public class ILibraryRemap : AntilatencyInterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate AntilatencyInterfaceContract.ExceptionCode createFactoryDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate deviceTypes, out System.IntPtr result);
			public delegate AntilatencyInterfaceContract.ExceptionCode getVersionDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate AntilatencyInterfaceContract.ExceptionCode setLogLevelDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.LogLevel level);
			#pragma warning disable 0649
			public createFactoryDelegate createFactory;
			public getVersionDelegate getVersion;
			public setLogLevelDelegate setLogLevel;
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
			vmt.createFactory = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate deviceTypes, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					var resultMarshaler = obj.createFactory(deviceTypes.toArray<Antilatency.DeviceNetwork.UsbDeviceType>());
					result = AntilatencyInterfaceContract.Details.InterfaceMarshaler.ManagedToNative<IFactory>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.getVersion = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					result.assign(obj.getVersion());
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.setLogLevel = (System.IntPtr _this, Antilatency.DeviceNetwork.LogLevel level) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					obj.setLogLevel(level);
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
[Guid("d35cd224-a8b7-48a9-8726-6297b7758aa9")]
public interface ITask : AntilatencyInterfaceContract.IInterface {
	bool isTaskFinished();
	void stopTask();
}
namespace Details {
	public class ITaskWrapper : AntilatencyInterfaceContract.Details.IInterfaceWrapper, ITask {
		private ITaskRemap.VMT _VMT = new ITaskRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ITaskRemap.VMT).GetFields().Length;
		}
		public ITaskWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ITaskRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public bool isTaskFinished() {
			bool result;
			HandleExceptionCode(_VMT.isTaskFinished(_object, out result));
			return result;
		}
		public void stopTask() {
			HandleExceptionCode(_VMT.stopTask(_object));
		}
	}
	public class ITaskRemap : AntilatencyInterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate AntilatencyInterfaceContract.ExceptionCode isTaskFinishedDelegate(System.IntPtr _this, out bool result);
			public delegate AntilatencyInterfaceContract.ExceptionCode stopTaskDelegate(System.IntPtr _this);
			#pragma warning disable 0649
			public isTaskFinishedDelegate isTaskFinished;
			public stopTaskDelegate stopTask;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ITaskRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			AntilatencyInterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.isTaskFinished = (System.IntPtr _this, out bool result) => {
				try {
					var obj = GetContext(_this) as ITask;
					result = obj.isTaskFinished();
				}
				catch (System.Exception ex) {
					result = default(bool);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.stopTask = (System.IntPtr _this) => {
				try {
					var obj = GetContext(_this) as ITask;
					obj.stopTask();
				}
				catch (System.Exception ex) {
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
/// <summary>Antilatency Device Network predefined constants.</summary>
public static partial class Constants {
	/// <summary>Root device in Antilatency Device Network hierarchy, any socket node connected directly by USB to PC, smartphone or HMD, will have RootNode as its parent.</summary>
	public static Antilatency.DeviceNetwork.NodeHandle RootNode {
		get {
			byte[] data = new byte[]{0, 0, 0, 0};
			var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
			Antilatency.DeviceNetwork.NodeHandle result = (Antilatency.DeviceNetwork.NodeHandle)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Antilatency.DeviceNetwork.NodeHandle));
			handle.Free();
			return result;
		}
	}
	/// <summary>Predefined constant value for invalid node.</summary>
	public static Antilatency.DeviceNetwork.NodeHandle InvalidNode {
		get {
			byte[] data = new byte[]{255, 255, 255, 255};
			var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
			Antilatency.DeviceNetwork.NodeHandle result = (Antilatency.DeviceNetwork.NodeHandle)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Antilatency.DeviceNetwork.NodeHandle));
			handle.Free();
			return result;
		}
	}
	/// <summary>Serial number key, can be used with IFactory.nodeGetProperty method to get serial number of node. All Antilatency devices has unique serial number.</summary>
	public const string SerialNumberKey = "SerialNumber";
	/// <summary>Software version key, can be used with IFactory.nodeGetProperty method to get software version of node.</summary>
	public const string SoftwareVersionKey = "SoftwareV";
	/// <summary>Hardware version key, can be used with IFactory.nodeGetProperty method to get hardware version of node.</summary>
	public const string HardwareVersionKey = "HardwareV";
}
}
