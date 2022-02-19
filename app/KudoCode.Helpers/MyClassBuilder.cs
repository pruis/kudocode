using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
namespace KudoCode.Helpers
{
	public class MyClassBuilder
	{
		AssemblyName asemblyName;
		public MyClassBuilder()
		{
		}
		public object CreateObject<T>(string ClassName, List<(string, Type)> PropertyNames)
		{
			this.asemblyName = new AssemblyName(ClassName);

			TypeBuilder DynamicClass = this.CreateClass<T>();
			this.CreateConstructor(DynamicClass);
			for (int ind = 0; ind < PropertyNames.Count(); ind++)
				CreateProperty(DynamicClass, PropertyNames[ind].Item1, PropertyNames[ind].Item2);
			Type type = DynamicClass.CreateType();

			return Activator.CreateInstance(type);
		}
		public Type CreateType<T>(string ClassName, List<(string, Type)> PropertyNames)
		{
			this.asemblyName = new AssemblyName(ClassName);

			TypeBuilder DynamicClass = this.CreateClass<T>();
			this.CreateConstructor(DynamicClass);
			for (int ind = 0; ind < PropertyNames.Count(); ind++)
				CreateProperty(DynamicClass, PropertyNames[ind].Item1, PropertyNames[ind].Item2);
			Type type = DynamicClass.CreateType();

			return type;
		}
		private TypeBuilder CreateClass<T>()
		{
			AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(this.asemblyName, AssemblyBuilderAccess.Run);
			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
			TypeBuilder typeBuilder = moduleBuilder.DefineType(this.asemblyName.FullName
								, TypeAttributes.Public |
								TypeAttributes.Class |
								TypeAttributes.AutoClass |
								TypeAttributes.AnsiClass |
								TypeAttributes.BeforeFieldInit |
								TypeAttributes.AutoLayout
								, typeof(T));
			return typeBuilder;
		}
		private void CreateConstructor(TypeBuilder typeBuilder)
		{
			typeBuilder.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
		}
		private void CreateProperty(TypeBuilder typeBuilder, string propertyName, Type propertyType)
		{
			FieldBuilder fieldBuilder = typeBuilder.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);

			PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);
			MethodBuilder getPropMthdBldr = typeBuilder.DefineMethod("get_" + propertyName,
				MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);

			ILGenerator getIl = getPropMthdBldr.GetILGenerator();

			getIl.Emit(OpCodes.Ldarg_0);
			getIl.Emit(OpCodes.Ldfld, fieldBuilder);
			getIl.Emit(OpCodes.Ret);

			MethodBuilder setPropMthdBldr = typeBuilder.DefineMethod("set_" + propertyName,
				  MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, null, new[] { propertyType });

			ILGenerator setIl = setPropMthdBldr.GetILGenerator();
			Label modifyProperty = setIl.DefineLabel();
			Label exitSet = setIl.DefineLabel();

			setIl.MarkLabel(modifyProperty);
			setIl.Emit(OpCodes.Ldarg_0);
			setIl.Emit(OpCodes.Ldarg_1);
			setIl.Emit(OpCodes.Stfld, fieldBuilder);

			setIl.Emit(OpCodes.Nop);
			setIl.MarkLabel(exitSet);
			setIl.Emit(OpCodes.Ret);

			propertyBuilder.SetGetMethod(getPropMthdBldr);
			propertyBuilder.SetSetMethod(setPropMthdBldr);
		}
	}
}