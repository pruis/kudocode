using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
//https://stackoverflow.com/questions/44807836/loading-startup-configuration-from-json-located-in-memory/52405277#52405277

namespace KudoCode.Mobile.Infrastructure.Blazor
{
	public class InMemoryFileProvider : IFileProvider
	{
		private class InMemoryFile : IFileInfo
		{
			private readonly byte[] _data;
			public InMemoryFile(string json) => _data = Encoding.UTF8.GetBytes(json);
			public Stream CreateReadStream() => new MemoryStream(_data);
			public bool Exists { get; } = true;
			public long Length => _data.Length;
			public string PhysicalPath { get; } = string.Empty;
			public string Name { get; } = string.Empty;
			public DateTimeOffset LastModified { get; } = DateTimeOffset.UtcNow;
			public bool IsDirectory { get; } = false;
		}

		private readonly IFileInfo _fileInfo;
		public InMemoryFileProvider(string json) => _fileInfo = new InMemoryFile(json);
		public IFileInfo GetFileInfo(string _) => _fileInfo;
		public IDirectoryContents GetDirectoryContents(string _) => null;
		public IChangeToken Watch(string _) => NullChangeToken.Singleton;
	}
}