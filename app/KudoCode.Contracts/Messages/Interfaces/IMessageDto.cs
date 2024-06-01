namespace  KudoCode.Contracts
{
    public interface IMessageDto
    {
        string Key { get; set; }
        string Message { get; set; }
        MessageDtoType Type { get; set; }
    }
}