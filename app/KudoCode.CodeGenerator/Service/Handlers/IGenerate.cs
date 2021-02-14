using KudoCode.CodeGenerator.Logic.Settings;

namespace KudoCode.CodeGenerator.Service.Handlers
{
    public interface IGenerate
    {
        void Generate(IGenSettings settings);
    }
}