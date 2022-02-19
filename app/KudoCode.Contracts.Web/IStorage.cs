using System;

namespace KudoCode.Contracts.Web
{
	public class AppState
	{
		public AppState()
		{
		}
		public void SetTableConfigId(int value)
		{
			TableConfigId = value;
			NotifyStateChanged();
		}
		public int TableConfigId { get; private set; }
		public event Action OnChange;
		private void NotifyStateChanged() => OnChange?.Invoke();

	}
	public interface IStorage
	{
		void Set(string key, object result);
		T Get<T>(string key);
		void Remove(string key);
	}
}