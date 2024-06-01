namespace KudoCode.Contracts.Api
{
	public interface IDynamicInterceptor
	{
		object Execute(dynamic data);
		void Validate(object data);
	}
}