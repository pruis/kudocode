namespace KudoCode.LogicLayer.Infrastructure.Dtos.Messages.Interfaces
{
    public interface IMessageDto
    {
        string Key { get; set; }
        string Message { get; set; }
        MessageDtoType Type { get; set; }
    }
}