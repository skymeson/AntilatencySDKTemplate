#pragma warning disable IDE1006 // Do not warn about naming style violations
#pragma warning disable IDE0017 // Do not suggest to simplify object initialization
using System.Runtime.InteropServices;
namespace AntilatencyStorageClient {

[Guid("792d9d14-a2d2-42ad-aeec-7f8a6ba62bd0")]
public interface IStorage : AntilatencyInterfaceContract.IInterface {
	string read(string group, string key);
	void write(string group, string key, string data);
	void remove(string group, string key);
	string next(string group, string key);
	bool exists();
}
namespace Details {
	public class IStorageWrapper : AntilatencyInterfaceContract.Details.IInterfaceWrapper, IStorage {
		private IStorageRemap.VMT _VMT = new IStorageRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(IStorageRemap.VMT).GetFields().Length;
		}
		public IStorageWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<IStorageRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public string read(string group, string key) {
			string result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create();
			var groupMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(group);
			var keyMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(key);
			HandleExceptionCode(_VMT.read(_object, groupMarshaler, keyMarshaler, resultMarshaler));
			groupMarshaler.Dispose();
			keyMarshaler.Dispose();
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public void write(string group, string key, string data) {
			var groupMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(group);
			var keyMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(key);
			var dataMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(data);
			HandleExceptionCode(_VMT.write(_object, groupMarshaler, keyMarshaler, dataMarshaler));
			groupMarshaler.Dispose();
			keyMarshaler.Dispose();
			dataMarshaler.Dispose();
		}
		public void remove(string group, string key) {
			var groupMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(group);
			var keyMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(key);
			HandleExceptionCode(_VMT.remove(_object, groupMarshaler, keyMarshaler));
			groupMarshaler.Dispose();
			keyMarshaler.Dispose();
		}
		public string next(string group, string key) {
			string result;
			var resultMarshaler = AntilatencyInterfaceContract.Details.ArrayOutMarshaler.create();
			var groupMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(group);
			var keyMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(key);
			HandleExceptionCode(_VMT.next(_object, groupMarshaler, keyMarshaler, resultMarshaler));
			groupMarshaler.Dispose();
			keyMarshaler.Dispose();
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public bool exists() {
			bool result;
			HandleExceptionCode(_VMT.exists(_object, out result));
			return result;
		}
	}
	public class IStorageRemap : AntilatencyInterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate AntilatencyInterfaceContract.ExceptionCode readDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate group, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate key, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate AntilatencyInterfaceContract.ExceptionCode writeDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate group, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate key, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate data);
			public delegate AntilatencyInterfaceContract.ExceptionCode removeDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate group, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate key);
			public delegate AntilatencyInterfaceContract.ExceptionCode nextDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate group, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate key, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate AntilatencyInterfaceContract.ExceptionCode existsDelegate(System.IntPtr _this, out bool result);
			#pragma warning disable 0649
			public readDelegate read;
			public writeDelegate write;
			public removeDelegate remove;
			public nextDelegate next;
			public existsDelegate exists;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static IStorageRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			AntilatencyInterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.read = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate group, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate key, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IStorage;
					result.assign(obj.read(group, key));
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.write = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate group, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate key, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate data) => {
				try {
					var obj = GetContext(_this) as IStorage;
					obj.write(group, key, data);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.remove = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate group, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate key) => {
				try {
					var obj = GetContext(_this) as IStorage;
					obj.remove(group, key);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.next = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate group, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate key, AntilatencyInterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IStorage;
					result.assign(obj.next(group, key));
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.exists = (System.IntPtr _this, out bool result) => {
				try {
					var obj = GetContext(_this) as IStorage;
					result = obj.exists();
				}
				catch (System.Exception ex) {
					result = default(bool);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public IStorageRemap() { }
		public IStorageRemap(System.IntPtr context) {
			AllocateNativeInterface(NativeVmt.Handle, context);
		}
	}
}
[Guid("85abab02-be0f-4836-9c1c-3c730bbd0251")]
public interface ILibrary : AntilatencyInterfaceContract.IInterface {
	AntilatencyStorageClient.IStorage getRemoteStorage(string ipAddress, uint port);
	AntilatencyStorageClient.IStorage getLocalStorage();
}
public static class Library{
    [DllImport("AntilatencyStorageClient")]
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
		public AntilatencyStorageClient.IStorage getRemoteStorage(string ipAddress, uint port) {
			AntilatencyStorageClient.IStorage result;
			System.IntPtr resultMarshaler;
			var ipAddressMarshaler = AntilatencyInterfaceContract.Details.ArrayInMarshaler.create(ipAddress);
			HandleExceptionCode(_VMT.getRemoteStorage(_object, ipAddressMarshaler, port, out resultMarshaler));
			ipAddressMarshaler.Dispose();
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new AntilatencyStorageClient.Details.IStorageWrapper(resultMarshaler);
			return result;
		}
		public AntilatencyStorageClient.IStorage getLocalStorage() {
			AntilatencyStorageClient.IStorage result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.getLocalStorage(_object, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new AntilatencyStorageClient.Details.IStorageWrapper(resultMarshaler);
			return result;
		}
	}
	public class ILibraryRemap : AntilatencyInterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate AntilatencyInterfaceContract.ExceptionCode getRemoteStorageDelegate(System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate ipAddress, uint port, out System.IntPtr result);
			public delegate AntilatencyInterfaceContract.ExceptionCode getLocalStorageDelegate(System.IntPtr _this, out System.IntPtr result);
			#pragma warning disable 0649
			public getRemoteStorageDelegate getRemoteStorage;
			public getLocalStorageDelegate getLocalStorage;
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
			vmt.getRemoteStorage = (System.IntPtr _this, AntilatencyInterfaceContract.Details.ArrayInMarshaler.Intermediate ipAddress, uint port, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					var resultMarshaler = obj.getRemoteStorage(ipAddress, port);
					result = AntilatencyInterfaceContract.Details.InterfaceMarshaler.ManagedToNative<IStorage>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return AntilatencyInterfaceContract.ExceptionCode.Ok;
			};
			vmt.getLocalStorage = (System.IntPtr _this, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					var resultMarshaler = obj.getLocalStorage();
					result = AntilatencyInterfaceContract.Details.InterfaceMarshaler.ManagedToNative<IStorage>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
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
}
